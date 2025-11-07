// <copyright file="HttpClientService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using ApiSeguimientoCADS.Api.Services.Models;
    using System.Net;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Text.RegularExpressions;

    /// <summary>
    /// HttpClientService
    /// </summary>
    public partial class HttpClientService : IHttpClientService
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        [GeneratedRegex(@"""data""\s*:\s*""""", RegexOptions.None)]
        private static partial Regex EmptyDataPattern();

        private readonly HttpClient _http;
        private readonly IAppLogger<HttpClientService> _logger;
        private readonly IResiliencePolicyService _resiliencePolicyService;

        /// <summary>
        /// HttpClientService
        /// </summary>
        /// <param name="http">http</param>
        /// <param name="logger">logger</param>
        /// <param name="resiliencePolicyService">resiliencePolicyService</param>
        public HttpClientService(
            HttpClient http,
            IAppLogger<HttpClientService> logger,
            IResiliencePolicyService resiliencePolicyService)
        {
            this._http = http ?? throw new ArgumentNullException(nameof(http));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._resiliencePolicyService = resiliencePolicyService ?? throw new ArgumentNullException(nameof(resiliencePolicyService));
        }

        /// <summary>
        /// SendAsync
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="request">ApiRequest</param>
        /// <returns>ApiResponse</returns>
        public async Task<ApiResponse<T>> SendAsync<T>(ApiRequest request)
        {
            return await this.SendRequestAsync<T>(request, useRetry: true).ConfigureAwait(false);
        }

        /// <summary>
        /// SendWithoutRetryAsync - Envía una solicitud HTTP SIN aplicar RetryPipeline
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="request">ApiRequest</param>
        /// <returns>ApiResponse</returns>
        public async Task<ApiResponse<T>> SendWithoutRetryAsync<T>(ApiRequest request)
        {
            return await this.SendRequestAsync<T>(request, useRetry: false).ConfigureAwait(false);
        }

        private static bool IsMethodWithBody(HttpMethod method)
        {
            return method == HttpMethod.Post ||
                   method == HttpMethod.Put ||
                   method == HttpMethod.Patch ||
                   method == HttpMethod.Delete;
        }

        private static HttpRequestMessage CreateHttpRequestMessage(ApiRequest request, string? serializedBody)
        {
            var httpRequest = new HttpRequestMessage(request.Method, request.Url);

            if (request.Headers != null)
            {
                foreach (var header in request.Headers)
                {
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            if (!string.IsNullOrWhiteSpace(request.BearerToken))
            {
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", request.BearerToken);
            }

            if (serializedBody != null)
            {
                httpRequest.Content = new StringContent(serializedBody, Encoding.UTF8, "application/json");
            }

            return httpRequest;
        }

        /// <summary>
        /// Preprocesa el JSON para normalizar respuestas inconsistentes
        /// </summary>
        private static string PreprocessJsonResponse(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return json;
            }

            if (json.Contains("\"data\":\"\"", StringComparison.Ordinal))
            {
                return EmptyDataPattern().Replace(json, "\"data\":[]");
            }

            return json;
        }

        /// <summary>
        /// Método central que procesa las solicitudes HTTP con o sin retry
        /// </summary>
        private async Task<ApiResponse<T>> SendRequestAsync<T>(ApiRequest request, bool useRetry)
        {
            ArgumentNullException.ThrowIfNull(request);
            ArgumentNullException.ThrowIfNull(request.Url);

            var responseEntity = new ApiResponse<T>();
            CancellationTokenSource? cts = null;

            try
            {
                cts = new CancellationTokenSource(TimeSpan.FromSeconds(180));

                this.LogRequestStart(request, withoutRetry: !useRetry);
                var serializedBody = this.PrepareRequestBody(request);

                var result = useRetry
                    ? await this.ExecuteRequestWithRetry(request, serializedBody, cts.Token).ConfigureAwait(false)
                    : await this.ExecuteRequestWithoutRetry(request, serializedBody, cts.Token).ConfigureAwait(false);

                return await this.ProcessResponse<T>(result, responseEntity, cts.Token).ConfigureAwait(false);
            }
            catch (OutOfMemoryException)
            {
                throw;
            }
            catch (StackOverflowException)
            {
                throw;
            }
            catch (JsonException ex)
            {
                return this.HandleException<T>(ex, request, responseEntity);
            }
            catch (TaskCanceledException ex)
            {
                return this.HandleException<T>(ex, request, responseEntity);
            }
            catch (OperationCanceledException ex)
            {
                return this.HandleException<T>(ex, request, responseEntity);
            }
            catch (HttpRequestException ex)
            {
                return this.HandleException<T>(ex, request, responseEntity);
            }
            catch (Polly.RateLimit.RateLimitRejectedException ex)
            {
                return this.HandleException<T>(ex, request, responseEntity);
            }
            catch (Polly.CircuitBreaker.BrokenCircuitException ex)
            {
                return this.HandleException<T>(ex, request, responseEntity);
            }
            catch (Polly.Bulkhead.BulkheadRejectedException ex)
            {
                return this.HandleException<T>(ex, request, responseEntity);
            }
            catch (Polly.Timeout.TimeoutRejectedException ex)
            {
                return this.HandleException<T>(ex, request, responseEntity);
            }
            finally
            {
                cts?.Dispose();
            }
        }

        private void LogRequestStart(ApiRequest request, bool withoutRetry = false)
        {
            var logInput = new
            {
                Method = request.Method.ToString(),
                Url = request.Url.ToString(),
                HasBody = request.Body != null,
                HeaderCount = request.Headers?.Count ?? 0,
            };

            this._logger.StartProcess(logInput);

            var suffix = withoutRetry ? " (sin retry interno)" : string.Empty;
            this._logger.Info($"Enviando solicitud {request.Method} a {request.Url}{suffix}");
        }

        private string? PrepareRequestBody(ApiRequest request)
        {
            if (request.Body == null || !IsMethodWithBody(request.Method))
            {
                return null;
            }

            var serializedBody = JsonSerializer.Serialize(request.Body);
            this._logger.Debug($"Body serializado: {serializedBody.Length} caracteres");

            if (request.Headers?.Count > 0)
            {
                this._logger.Debug($"Headers configurados: {request.Headers.Count}");
            }

            if (!string.IsNullOrWhiteSpace(request.BearerToken))
            {
                this._logger.Debug("Token Bearer configurado");
            }

            return serializedBody;
        }

        private async Task<HttpResponseMessage> ExecuteRequestWithRetry(
            ApiRequest request,
            string? serializedBody,
            CancellationToken cancellationToken)
        {
            return await this._resiliencePolicyService.RetryPipeline.ExecuteAsync(
                async ct =>
                {
                    using var httpRequest = CreateHttpRequestMessage(request, serializedBody);
                    return await this._http.SendAsync(httpRequest, ct).ConfigureAwait(false);
                },
                cancellationToken).ConfigureAwait(false);
        }

        private async Task<HttpResponseMessage> ExecuteRequestWithoutRetry(
            ApiRequest request,
            string? serializedBody,
            CancellationToken cancellationToken)
        {
            using var httpRequest = CreateHttpRequestMessage(request, serializedBody);
            return await this._http.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
        }

        private async Task<ApiResponse<T>> ProcessResponse<T>(
            HttpResponseMessage result,
            ApiResponse<T> responseEntity,
            CancellationToken cancellationToken)
        {
            var jsonResponse = await result.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            responseEntity.StatusCode = result.StatusCode;
            responseEntity.RawResponse = jsonResponse;

            this._logger.Info($"Respuesta recibida: {result.StatusCode} ({(int)result.StatusCode}), {jsonResponse?.Length ?? 0} caracteres");

            if (result.IsSuccessStatusCode && !string.IsNullOrWhiteSpace(jsonResponse))
            {
                var cleanedJson = PreprocessJsonResponse(jsonResponse);
                responseEntity.Data = JsonSerializer.Deserialize<T>(cleanedJson, _jsonOptions);
                this._logger.Debug("Respuesta deserializada exitosamente");
            }

            return responseEntity;
        }

        private ApiResponse<T> HandleException<T>(Exception ex, ApiRequest request, ApiResponse<T> responseEntity)
        {
            return ex switch
            {
                JsonException => this.CreateErrorResponse<T>(responseEntity, HttpStatusCode.BadGateway, "Error de formato JSON", ex, request),
                TaskCanceledException => this.CreateErrorResponse<T>(responseEntity, HttpStatusCode.RequestTimeout, "El servicio externo no respondió a tiempo", ex, request, "Timeout al llamar a"),
                OperationCanceledException => this.CreateErrorResponse<T>(responseEntity, HttpStatusCode.RequestTimeout, "La operación fue cancelada", ex, request, "Operación cancelada para"),
                HttpRequestException => this.CreateErrorResponse<T>(responseEntity, HttpStatusCode.ServiceUnavailable, "Error de conexión", ex, request, "Error HTTP al llamar a"),
                Polly.RateLimit.RateLimitRejectedException => this.CreateErrorResponse<T>(responseEntity, HttpStatusCode.TooManyRequests, "El servicio está aislado temporalmente", ex, request, "Rate limit excedido para"),
                Polly.CircuitBreaker.BrokenCircuitException => this.CreateErrorResponse<T>(responseEntity, HttpStatusCode.ServiceUnavailable, "El servicio está temporalmente fuera de servicio (circuit breaker abierto)", ex, request, "Circuit breaker abierto para"),
                Polly.Bulkhead.BulkheadRejectedException => this.CreateErrorResponse<T>(responseEntity, HttpStatusCode.TooManyRequests, "Demasiadas solicitudes concurrentes. Intente nuevamente más tarde", ex, request, "Bulkhead rechazado para"),
                Polly.Timeout.TimeoutRejectedException => this.CreateErrorResponse<T>(responseEntity, HttpStatusCode.RequestTimeout, "El servicio no respondió en el tiempo esperado", ex, request, "Timeout de Polly para"),
                _ => this.CreateErrorResponse<T>(responseEntity, HttpStatusCode.InternalServerError, "Error inesperado", ex, request, "Error inesperado al llamar a"),
            };
        }

        private ApiResponse<T> CreateErrorResponse<T>(
            ApiResponse<T> responseEntity,
            HttpStatusCode statusCode,
            string errorMessage,
            Exception ex,
            ApiRequest request,
            string? logPrefix = null)
        {
            var logMessage = logPrefix != null
                ? $"{logPrefix} {request.Url}"
                : $"{errorMessage} de {request.Url}";

            this._logger.LogError(ex, logMessage);
            responseEntity.StatusCode = statusCode;
            responseEntity.RawResponse = ex.Message != null && errorMessage.Contains("Error", StringComparison.Ordinal)
                ? $"{errorMessage}: {ex.Message}"
                : errorMessage;

            return responseEntity;
        }
    }
}