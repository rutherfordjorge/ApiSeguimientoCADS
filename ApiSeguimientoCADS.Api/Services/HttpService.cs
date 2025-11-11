// <copyright file="HttpService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Models.Requests.Http;
    using ApiSeguimientoCADS.Api.Models.Responses.Http;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using ApiSeguimientoCADS.Api.Services.Models;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// HttpService - Servicio genérico para realizar llamadas HTTP a APIs externas
    /// </summary>
    public class HttpService : IHttpService
    {
        private const string _getWithCircuitBreaker = "GET with Circuit Breaker";
        private const string _postWithCircuitBreaker = "POST with Circuit Breaker";
        private readonly IHttpClientService _httpClientService;
        private readonly IAppLogger<HttpService> _logger;
        private readonly IResiliencePolicyService _resiliencePolicyService;

        /// <summary>
        /// Constructor de HttpService
        /// </summary>
        /// <param name="httpClientService">Servicio de cliente HTTP</param>
        /// <param name="logger">Logger de la aplicación</param>
        /// <param name="resiliencePolicyService">Servicio de políticas de resiliencia</param>
        public HttpService(
            IHttpClientService httpClientService,
            IAppLogger<HttpService> logger,
            IResiliencePolicyService resiliencePolicyService)
        {
            this._httpClientService = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._resiliencePolicyService = resiliencePolicyService ?? throw new ArgumentNullException(nameof(resiliencePolicyService));
        }

        /// <summary>
        /// Realiza una petición HTTP GET a una URL específica
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL completa del endpoint</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <returns>Respuesta deserializada del tipo especificado</returns>
        public async Task<TResponse?> GetAsync<TResponse>(Uri url, string? bearerToken = null)
            where TResponse : class
        {
            ArgumentNullException.ThrowIfNull(url);

            var apiRequest = new ApiRequest
            {
                Url = url,
                BearerToken = bearerToken,
                Method = HttpMethod.Get,
            };

            return await this.ExecuteSimpleRequestAsync<TResponse>(apiRequest, "GET").ConfigureAwait(false);
        }

        /// <summary>
        /// Realiza una petición HTTP POST a una URL específica
        /// </summary>
        /// <typeparam name="TRequest">Tipo de datos a enviar en el body</typeparam>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL completa del endpoint</param>
        /// <param name="body">Datos a enviar en el body</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <returns>Respuesta deserializada del tipo especificado</returns>
        public async Task<TResponse?> PostAsync<TRequest, TResponse>(Uri url, TRequest body, string? bearerToken = null)
            where TRequest : class
            where TResponse : class
        {
            ArgumentNullException.ThrowIfNull(url);
            ArgumentNullException.ThrowIfNull(body);

            var apiRequest = new ApiRequest
            {
                Url = url,
                BearerToken = bearerToken,
                Body = body,
                Method = HttpMethod.Post,
            };

            return await this.ExecuteSimpleRequestAsync<TResponse>(apiRequest, "POST").ConfigureAwait(false);
        }

        /// <summary>
        /// Realiza una petición HTTP PUT a una URL específica
        /// </summary>
        /// <typeparam name="TRequest">Tipo de datos a enviar en el body</typeparam>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL completa del endpoint</param>
        /// <param name="body">Datos a enviar en el body</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <returns>Respuesta deserializada del tipo especificado</returns>
        public async Task<TResponse?> PutAsync<TRequest, TResponse>(Uri url, TRequest body, string? bearerToken = null)
            where TRequest : class
            where TResponse : class
        {
            ArgumentNullException.ThrowIfNull(url);
            ArgumentNullException.ThrowIfNull(body);

            var apiRequest = new ApiRequest
            {
                Url = url,
                BearerToken = bearerToken,
                Body = body,
                Method = HttpMethod.Put,
            };

            return await this.ExecuteSimpleRequestAsync<TResponse>(apiRequest, "PUT").ConfigureAwait(false);
        }

        /// <summary>
        /// Realiza una petición HTTP DELETE a una URL específica
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL completa del endpoint</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <returns>Respuesta deserializada del tipo especificado</returns>
        public async Task<TResponse?> DeleteAsync<TResponse>(Uri url, string? bearerToken = null)
            where TResponse : class
        {
            ArgumentNullException.ThrowIfNull(url);

            var apiRequest = new ApiRequest
            {
                Url = url,
                BearerToken = bearerToken,
                Method = HttpMethod.Delete,
            };

            return await this.ExecuteSimpleRequestAsync<TResponse>(apiRequest, "DELETE").ConfigureAwait(false);
        }

        /// <summary>
        /// Realiza una petición HTTP con configuración personalizada
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="request">Configuración de la petición HTTP</param>
        /// <returns>Respuesta HTTP completa con datos y metadata</returns>
        public async Task<HttpApiResponse<TResponse>> SendCustomAsync<TResponse>(HttpRequest request)
            where TResponse : class
        {
            ArgumentNullException.ThrowIfNull(request);
            ArgumentNullException.ThrowIfNull(request.Url);

            var (processId, stopwatch) = this._logger.StartProcess(new
            {
                Operation = "SendCustomAsync",
                Method = request.Method.ToString(),
                Url = request.Url.ToString(),
            });

            var response = new HttpApiResponse<TResponse>();

            try
            {
                this._logger.Info($"{request.Method} custom request to: {request.Url}");

                var apiRequest = CreateApiRequest(request.Url, request.BearerToken, request.Body, request.Method);
                var result = await this._httpClientService.SendAsync<TResponse>(apiRequest).ConfigureAwait(false);

                PopulateResponse(response, result, stopwatch);
                this.LogRequestResult(request.Method.ToString(), result, stopwatch);
                this._logger.EndProcess(processId, stopwatch, new { Success = result.IsSuccess, result.StatusCode });

                return response;
            }
            catch (OutOfMemoryException ex)
            {
                return this.HandleOutOfMemoryException(ex, response, processId, stopwatch, request.Url, request.Method.ToString());
            }
            catch (StackOverflowException ex)
            {
                return this.HandleStackOverflowException(ex, response, processId, stopwatch, request.Url, request.Method.ToString());
            }
            catch (UriFormatException ex)
            {
                return this.HandleUriFormatException(ex, response, processId, stopwatch, request.Url, request.Method.ToString());
            }
            catch (TaskCanceledException ex)
            {
                return this.HandleTaskCanceledException(ex, response, processId, stopwatch, request.Url, request.Method.ToString());
            }
            catch (HttpRequestException ex)
            {
                return this.HandleHttpRequestException(ex, response, processId, stopwatch, request.Url, request.Method.ToString());
            }
        }

        /// <summary>
        /// Realiza una petición HTTP GET con headers personalizados
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL completa del endpoint</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <param name="customHeaders">Headers personalizados adicionales (opcional)</param>
        /// <returns>Respuesta deserializada del tipo especificado</returns>
        public async Task<TResponse?> GetWithHeadersAsync<TResponse>(
            Uri url,
            string? bearerToken = null,
            Dictionary<string, string>? customHeaders = null)
            where TResponse : class
        {
            ArgumentNullException.ThrowIfNull(url);

            var apiRequest = new ApiRequest
            {
                Url = url,
                BearerToken = bearerToken,
                Method = HttpMethod.Get,
            };

            if (customHeaders != null)
            {
                foreach (var header in customHeaders)
                {
                    apiRequest.Headers[header.Key] = header.Value;
                }
            }

            return await this.ExecuteSimpleRequestAsync<TResponse>(apiRequest, "GET").ConfigureAwait(false);
        }

        /// <summary>
        /// Realiza una petición HTTP POST con headers personalizados
        /// </summary>
        /// <typeparam name="TRequest">Tipo de datos a enviar en el body</typeparam>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL completa del endpoint</param>
        /// <param name="body">Datos a enviar en el body</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <param name="customHeaders">Headers personalizados adicionales (opcional)</param>
        /// <returns>Respuesta deserializada del tipo especificado</returns>
        public async Task<TResponse?> PostWithHeadersAsync<TRequest, TResponse>(
            Uri url,
            TRequest body,
            string? bearerToken = null,
            Dictionary<string, string>? customHeaders = null)
            where TRequest : class
            where TResponse : class
        {
            ArgumentNullException.ThrowIfNull(url);
            ArgumentNullException.ThrowIfNull(body);

            var apiRequest = new ApiRequest
            {
                Url = url,
                BearerToken = bearerToken,
                Body = body,
                Method = HttpMethod.Post,
            };

            if (customHeaders != null)
            {
                foreach (var header in customHeaders)
                {
                    apiRequest.Headers[header.Key] = header.Value;
                }
            }

            return await this.ExecuteSimpleRequestAsync<TResponse>(apiRequest, "POST").ConfigureAwait(false);
        }

        /// <summary>
        /// Realiza una petición HTTP GET con Circuit Breaker para servicios críticos
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL completa del endpoint</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <param name="customHeaders">Headers personalizados adicionales (opcional)</param>
        /// <returns>Respuesta HTTP completa con datos y metadata</returns>
        public async Task<HttpApiResponse<TResponse>> GetWithCircuitBreakerAsync<TResponse>(
            Uri url,
            string? bearerToken = null,
            Dictionary<string, string>? customHeaders = null)
            where TResponse : class
        {
            ArgumentNullException.ThrowIfNull(url);

            var (processId, stopwatch) = this._logger.StartProcess(new
            {
                Operation = "GetWithCircuitBreakerAsync",
                Url = url.ToString(),
            });

            var response = new HttpApiResponse<TResponse>();

            try
            {
                this._logger.Info($"GET with Circuit Breaker request to: {url}");

                var apiRequest = new ApiRequest
                {
                    Url = url,
                    BearerToken = bearerToken,
                    Method = HttpMethod.Get,
                };

                if (customHeaders != null)
                {
                    foreach (var header in customHeaders)
                    {
                        apiRequest.Headers[header.Key] = header.Value;
                    }
                }

                // Ejecutar con Circuit Breaker para proteger servicios críticos
                // NOTA: CircuitBreakerPipeline ya incluye retry interno (2 intentos rápidos)
                // Se usa SendWithoutRetryAsync para evitar doble retry (2x3=6 intentos)
                var result = await this._resiliencePolicyService.CircuitBreakerPipeline.ExecuteAsync(
                    async _ => await this._httpClientService.SendWithoutRetryAsync<TResponse>(apiRequest).ConfigureAwait(false),
                    CancellationToken.None).ConfigureAwait(false);

                response.Data = result.Data;
                response.StatusCode = result.StatusCode;
                response.IsSuccess = result.IsSuccess;
                response.ResponseTimeMs = stopwatch.ElapsedMilliseconds;

                if (result.IsSuccess)
                {
                    this._logger.Info($"GET with Circuit Breaker successful. Status: {result.StatusCode}, Time: {stopwatch.ElapsedMilliseconds}ms");
                }
                else
                {
                    this._logger.Info($"GET with Circuit Breaker failed. Status: {result.StatusCode}");
                    response.ErrorMessage = $"Request failed with status {result.StatusCode}";
                }

                this._logger.EndProcess(processId, stopwatch, new { Success = result.IsSuccess, result.StatusCode });
                return response;
            }
            catch (OutOfMemoryException ex)
            {
                return this.HandleOutOfMemoryException(ex, response, processId, stopwatch, url, _getWithCircuitBreaker);
            }
            catch (StackOverflowException ex)
            {
                return this.HandleStackOverflowException(ex, response, processId, stopwatch, url, _getWithCircuitBreaker);
            }
            catch (Polly.CircuitBreaker.BrokenCircuitException ex)
            {
                return this.HandleBrokenCircuitException(ex, response, processId, stopwatch, url);
            }
            catch (TaskCanceledException ex)
            {
                return this.HandleTaskCanceledException(ex, response, processId, stopwatch, url, _getWithCircuitBreaker);
            }
            catch (HttpRequestException ex)
            {
                return this.HandleHttpRequestException(ex, response, processId, stopwatch, url, _getWithCircuitBreaker);
            }
        }

        /// <summary>
        /// Realiza una petición HTTP POST con Circuit Breaker para servicios críticos
        /// </summary>
        /// <typeparam name="TRequest">Tipo de datos a enviar en el body</typeparam>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL completa del endpoint</param>
        /// <param name="body">Datos a enviar en el body</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <param name="customHeaders">Headers personalizados adicionales (opcional)</param>
        /// <returns>Respuesta HTTP completa con datos y metadata</returns>
        public async Task<HttpApiResponse<TResponse>> PostWithCircuitBreakerAsync<TRequest, TResponse>(
            Uri url,
            TRequest body,
            string? bearerToken = null,
            Dictionary<string, string>? customHeaders = null)
            where TRequest : class
            where TResponse : class
        {
            ArgumentNullException.ThrowIfNull(url);
            ArgumentNullException.ThrowIfNull(body);

            var (processId, stopwatch) = this._logger.StartProcess(new
            {
                Operation = "PostWithCircuitBreakerAsync",
                Url = url.ToString(),
                HasBody = true,
            });

            var response = new HttpApiResponse<TResponse>();

            try
            {
                this._logger.Info($"POST with Circuit Breaker request to: {url}");

                var apiRequest = new ApiRequest
                {
                    Url = url,
                    BearerToken = bearerToken,
                    Body = body,
                    Method = HttpMethod.Post,
                };

                if (customHeaders != null)
                {
                    foreach (var header in customHeaders)
                    {
                        apiRequest.Headers[header.Key] = header.Value;
                    }
                }

                // Ejecutar con Circuit Breaker para proteger servicios críticos
                // NOTA: CircuitBreakerPipeline ya incluye retry interno (2 intentos rápidos)
                // Se usa SendWithoutRetryAsync para evitar doble retry (2x3=6 intentos)
                var result = await this._resiliencePolicyService.CircuitBreakerPipeline.ExecuteAsync(
                    async _ => await this._httpClientService.SendWithoutRetryAsync<TResponse>(apiRequest).ConfigureAwait(false),
                    CancellationToken.None).ConfigureAwait(false);

                response.Data = result.Data;
                response.StatusCode = result.StatusCode;
                response.IsSuccess = result.IsSuccess;
                response.ResponseTimeMs = stopwatch.ElapsedMilliseconds;

                if (result.IsSuccess)
                {
                    this._logger.Info($"POST with Circuit Breaker successful. Status: {result.StatusCode}, Time: {stopwatch.ElapsedMilliseconds}ms");
                }
                else
                {
                    this._logger.Info($"POST with Circuit Breaker failed. Status: {result.StatusCode}");
                    response.ErrorMessage = $"Request failed with status {result.StatusCode}";
                }

                this._logger.EndProcess(processId, stopwatch, new { Success = result.IsSuccess, result.StatusCode });
                return response;
            }
            catch (OutOfMemoryException ex)
            {
                return this.HandleOutOfMemoryException(ex, response, processId, stopwatch, url, _getWithCircuitBreaker);
            }
            catch (StackOverflowException ex)
            {
                return this.HandleStackOverflowException(ex, response, processId, stopwatch, url, _getWithCircuitBreaker);
            }
            catch (Polly.CircuitBreaker.BrokenCircuitException ex)
            {
                return this.HandleBrokenCircuitException(ex, response, processId, stopwatch, url);
            }
            catch (TaskCanceledException ex)
            {
                return this.HandleTaskCanceledException(ex, response, processId, stopwatch, url, _postWithCircuitBreaker);
            }
            catch (HttpRequestException ex)
            {
                return this.HandleHttpRequestException(ex, response, processId, stopwatch, url, _postWithCircuitBreaker);
            }
        }

        private static ApiRequest CreateApiRequest(Uri url, string? bearerToken, object? body, HttpMethod method)
        {
            return new ApiRequest
            {
                Url = url,
                BearerToken = bearerToken,
                Body = body,
                Method = method,
            };
        }

        private static void PopulateResponse<TResponse>(
            HttpApiResponse<TResponse> response,
            ApiSeguimientoCADS.Api.Services.Models.ApiResponse<TResponse> result,
            System.Diagnostics.Stopwatch stopwatch)
            where TResponse : class
        {
            response.Data = result.Data;
            response.StatusCode = result.StatusCode;
            response.IsSuccess = result.IsSuccess;
            response.ResponseTimeMs = stopwatch.ElapsedMilliseconds;

            if (!result.IsSuccess)
            {
                response.ErrorMessage = $"Request failed with status {result.StatusCode}";
            }
        }

        private async Task<TResponse?> ExecuteSimpleRequestAsync<TResponse>(ApiRequest apiRequest, string methodName)
            where TResponse : class
        {
            var (processId, stopwatch) = this._logger.StartProcess(new
            {
                Operation = $"{methodName}Async",
                Url = apiRequest.Url.ToString(),
                HasBody = apiRequest.Body != null,
            });

            try
            {
                this._logger.Info($"{methodName} request to: {apiRequest.Url}");

                var result = await this._httpClientService.SendAsync<TResponse>(apiRequest).ConfigureAwait(false);

                if (result.IsSuccess)
                {
                    this._logger.Info($"{methodName} request successful. Status: {result.StatusCode}");
                    this._logger.EndProcess(processId, stopwatch, new { Success = true, result.StatusCode });
                    return result.Data;
                }

                this._logger.Info($"{methodName} request failed. Status: {result.StatusCode}");
                this._logger.EndProcess(processId, stopwatch, new { Success = false, result.StatusCode });
                return null;
            }
            catch (OutOfMemoryException ex)
            {
                this._logger.LogError(ex, $"Error crítico de memoria durante {methodName} a: {apiRequest.Url}");
                this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = "OutOfMemoryException" });
                throw new InvalidOperationException("Error crítico de memoria insuficiente durante la ejecución de la solicitud.", ex);
            }
            catch (StackOverflowException ex)
            {
                this._logger.LogError(ex, $"Error crítico de desbordamiento de pila durante {methodName} a: {apiRequest.Url}");
                this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = "StackOverflowException" });
                throw new InvalidOperationException("Error crítico de desbordamiento de pila durante la ejecución de la solicitud.", ex);
            }
            catch (UriFormatException ex)
            {
                this._logger.LogError(ex, $"Error al construir la URL: {apiRequest.Url}");
                this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = "UriFormatException" });
                throw new InvalidOperationException($"Error al construir la URL de la petición {methodName}", ex);
            }
            catch (TaskCanceledException ex)
            {
                this._logger.LogError(ex, $"Timeout en petición {methodName} a: {apiRequest.Url}");
                this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = "TaskCanceledException" });
                throw;
            }
            catch (HttpRequestException ex)
            {
                this._logger.LogError(ex, $"Error en petición {methodName} a: {apiRequest.Url}");
                this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = "HttpRequestException" });
                throw;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error inesperado en petición {methodName} a: {apiRequest.Url}");
                this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = "UnexpectedException" });
                throw;
            }
        }

        private void LogRequestResult<TResponse>(
            string methodName,
            ApiResponse<TResponse> result,
            System.Diagnostics.Stopwatch stopwatch)
            where TResponse : class
        {
            if (result.IsSuccess)
            {
                this._logger.Info($"{methodName} request successful. Status: {result.StatusCode}, Time: {stopwatch.ElapsedMilliseconds}ms");
            }
            else
            {
                this._logger.Info($"{methodName} request failed. Status: {result.StatusCode}");
            }
        }

        private HttpApiResponse<TResponse> HandleOutOfMemoryException<TResponse>(
             OutOfMemoryException ex,
             HttpApiResponse<TResponse> response,
             Guid processId,
             System.Diagnostics.Stopwatch stopwatch,
             Uri url,
             string methodName)
             where TResponse : class
        {
            this._logger.LogError(ex, $"Error crítico de memoria en {methodName} a: {url}");
            this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = "OutOfMemoryException" });

            response.IsSuccess = false;
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.ErrorMessage = "Error crítico: memoria insuficiente para completar la operación.";
            response.ResponseTimeMs = stopwatch.ElapsedMilliseconds;
            return response;
        }

        private HttpApiResponse<TResponse> HandleStackOverflowException<TResponse>(
            StackOverflowException ex,
            HttpApiResponse<TResponse> response,
            Guid processId,
            System.Diagnostics.Stopwatch stopwatch,
            Uri url,
            string methodName)
            where TResponse : class
        {
            this._logger.LogError(ex, $"Error crítico de desbordamiento de pila en {methodName} a: {url}");
            this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = "StackOverflowException" });

            response.IsSuccess = false;
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.ErrorMessage = "Error crítico: desbordamiento de pila detectado durante la ejecución.";
            response.ResponseTimeMs = stopwatch.ElapsedMilliseconds;
            return response;
        }

        private HttpApiResponse<TResponse> HandleUriFormatException<TResponse>(
            UriFormatException ex,
            HttpApiResponse<TResponse> response,
            Guid processId,
            System.Diagnostics.Stopwatch stopwatch,
            Uri url,
            string methodName)
            where TResponse : class
        {
            this._logger.LogError(ex, $"Error al construir la URL: {url} a {methodName}");
            this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = "UriFormatException" });

            response.IsSuccess = false;
            response.StatusCode = HttpStatusCode.BadRequest;
            response.ErrorMessage = $"URL inválida: {ex.Message}";
            response.ResponseTimeMs = stopwatch.ElapsedMilliseconds;
            return response;
        }

        private HttpApiResponse<TResponse> HandleTaskCanceledException<TResponse>(
            TaskCanceledException ex,
            HttpApiResponse<TResponse> response,
            Guid processId,
            System.Diagnostics.Stopwatch stopwatch,
            Uri url,
            string methodName)
            where TResponse : class
        {
            this._logger.LogError(ex, $"Timeout en petición {methodName} a: {url}");
            this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = "TaskCanceledException" });

            response.IsSuccess = false;
            response.StatusCode = HttpStatusCode.RequestTimeout;
            response.ErrorMessage = "La petición excedió el tiempo de espera";
            response.ResponseTimeMs = stopwatch.ElapsedMilliseconds;
            return response;
        }

        private HttpApiResponse<TResponse> HandleHttpRequestException<TResponse>(
            HttpRequestException ex,
            HttpApiResponse<TResponse> response,
            Guid processId,
            System.Diagnostics.Stopwatch stopwatch,
            Uri url,
            string methodName)
            where TResponse : class
        {
            this._logger.LogError(ex, $"Error en petición {methodName} a: {url}");
            this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = "HttpRequestException" });

            response.IsSuccess = false;
            response.StatusCode = HttpStatusCode.ServiceUnavailable;
            response.ErrorMessage = $"Error de red: {ex.Message}";
            response.ResponseTimeMs = stopwatch.ElapsedMilliseconds;
            return response;
        }

        private HttpApiResponse<TResponse> HandleBrokenCircuitException<TResponse>(
            Polly.CircuitBreaker.BrokenCircuitException ex,
            HttpApiResponse<TResponse> response,
            Guid processId,
            System.Diagnostics.Stopwatch stopwatch,
            Uri url)
            where TResponse : class
        {
            this._logger.LogError(ex, $"Circuit breaker abierto para: {url}");
            this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = "BrokenCircuitException" });

            response.IsSuccess = false;
            response.StatusCode = HttpStatusCode.ServiceUnavailable;
            response.ErrorMessage = "El servicio está temporalmente fuera de servicio (circuit breaker abierto)";
            response.ResponseTimeMs = stopwatch.ElapsedMilliseconds;
            return response;
        }
    }
}