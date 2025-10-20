// <copyright file="HttpClientService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using ApiSeguimientoCADS.Api.Services.Models;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Threading;

    /// <summary>
    /// HttpClientService
    /// </summary>
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _http;
        private readonly IAppLogger<HttpClientService> _logger;

        /// <summary>
        /// HttpClientService
        /// </summary>
        /// <param name="http">http</param>
        /// <param name="logger">logger</param>
        public HttpClientService(HttpClient http, IAppLogger<HttpClientService> logger)
        {
            this._http = http ?? throw new ArgumentNullException(nameof(http));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// SendAsync
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="request">ApiRequest</param>
        /// <returns>ApiResponse</returns>
        public async Task<ApiResponse<T>> SendAsync<T>(ApiRequest request, CancellationToken cancellationToken = default)
        {
            var responseEntity = new ApiResponse<T>();

            // Declarar las variables FUERA del try para que sean accesibles en el catch
            Guid processId = Guid.Empty;
            System.Diagnostics.Stopwatch? stopwatch = null;

            try
            {
                ArgumentNullException.ThrowIfNull(request);
                ArgumentNullException.ThrowIfNull(request.Url);

                var logInput = new
                {
                    Method = request.Method.ToString(),
                    Url = request.Url.ToString(),
                    HasBody = request.Body != null,
                    HeaderCount = request.Headers?.Count ?? 0,
                };
                (processId, stopwatch) = this._logger.StartProcess(logInput);

                this._logger.Info($"Enviando solicitud {request.Method} a {request.Url}");

                using var httpRequest = new HttpRequestMessage(request.Method, request.Url);

                if (request.Body != null && (request.Method == HttpMethod.Post || request.Method == HttpMethod.Put || request.Method == HttpMethod.Patch))
                {
                    var json = JsonSerializer.Serialize(request.Body);
                    httpRequest.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    this._logger.Debug($"Body serializado: {json.Length} caracteres");
                }

                if (!string.IsNullOrWhiteSpace(request.BearerToken))
                {
                    httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", request.BearerToken);
                    this._logger.Debug("Token Bearer agregado");
                }

                if (request.Headers != null && request.Headers.Count > 0)
                {
                    foreach (var header in request.Headers)
                    {
                        if (!httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value))
                        {
                            httpRequest.Content?.Headers.TryAddWithoutValidation(header.Key, header.Value);
                        }
                    }

                    this._logger.Debug($"Headers agregados: {request.Headers.Count}");
                }

                var result = await this._http.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                var jsonResponse = await result.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

                responseEntity.StatusCode = result.StatusCode;
                responseEntity.RawResponse = jsonResponse;
                this._logger.Info($"Respuesta recibida: {result.StatusCode} ({(int)result.StatusCode})");

                if (result.IsSuccessStatusCode && !string.IsNullOrWhiteSpace(jsonResponse))
                {
                    responseEntity.Data = JsonSerializer.Deserialize<T>(jsonResponse);
                    this._logger.Debug("Respuesta deserializada exitosamente");
                }

                var output = new
                {
                    StatusCode = (int)result.StatusCode,
                    IsSuccess = result.IsSuccessStatusCode,
                    ResponseLength = jsonResponse?.Length ?? 0,
                };

                this._logger.EndProcess(processId, stopwatch, output);
            }
            catch (HttpRequestException ex)
            {
                this._logger.LogError(ex);
                responseEntity.StatusCode = HttpStatusCode.InternalServerError;
                responseEntity.RawResponse = ex.Message;
                if (stopwatch != null && processId != Guid.Empty)
                {
                    this._logger.EndProcess(processId, stopwatch);
                }
            }
            catch (OperationCanceledException)
            {
                this._logger.Info("Solicitud HTTP cancelada por el consumidor.");
                if (stopwatch != null && processId != Guid.Empty)
                {
                    this._logger.EndProcess(processId, stopwatch);
                }
                throw;
            }

            return responseEntity;
        }
    }
}