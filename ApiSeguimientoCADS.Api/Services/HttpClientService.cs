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
            this._http = http ?? throw new ArgumentNullException(nameof(logger));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// SendAsync
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="request">ApiRequest</param>
        /// <returns>ApiResponse</returns>
        public async Task<ApiResponse<T>> SendAsync<T>(ApiRequest request)
        {
            var responseEntity = new ApiResponse<T>();

            try
            {
                ArgumentNullException.ThrowIfNull(request);
                var logInput = new
                {
                    Method = request.Method.ToString(),
                    Url = request.Url.ToString(),
                    HasBody = request.Body != null,
                    HeaderCount = request.Headers?.Count ?? 0,
                };

                var (processId, stopwatch) = this._logger.StartProcess(logInput);

                this._logger.Info($"Enviando solicitud {request.Method} a {request.Url}");

                using var httpRequest = new HttpRequestMessage(request.Method, request.Url);

                this._http.DefaultRequestHeaders.Clear();
                if (request.Headers != null)
                {
                    foreach (var header in request.Headers)
                    {
                        this._http.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }

                    this._logger.Debug($"Headers agregados: {request.Headers.Count}");
                }

                if (!string.IsNullOrWhiteSpace(request.BearerToken))
                {
                    this._http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.BearerToken);
                    this._logger.Debug("Token Bearer agregado");
                }

                if (request.Body != null && (request.Method == HttpMethod.Post || request.Method == HttpMethod.Put))
                {
                    var json = JsonSerializer.Serialize(request.Body);
                    httpRequest.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    this._logger.Debug($"Body serializado: {json.Length} caracteres");
                }

                var result = await this._http.SendAsync(httpRequest).ConfigureAwait(false);
                var jsonResponse = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

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
                responseEntity.StatusCode = HttpStatusCode.InternalServerError;
                responseEntity.RawResponse = ex.Message;
            }

            return responseEntity;
        }
    }
}