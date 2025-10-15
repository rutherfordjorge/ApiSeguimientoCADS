// <copyright file="HttpClientService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services
{
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

        /// <summary>
        /// HttpClientService
        /// </summary>
        /// <param name="http">http</param>
        public HttpClientService(HttpClient http)
        {
            this._http = http;
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

                using var httpRequest = new HttpRequestMessage(request.Method, request.Url);

                this._http.DefaultRequestHeaders.Clear();
                if (request.Headers != null)
                {
                    foreach (var header in request.Headers)
                    {
                        this._http.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                if (!string.IsNullOrWhiteSpace(request.BearerToken))
                {
                    this._http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.BearerToken);
                }

                if (request.Body != null && (request.Method == HttpMethod.Post || request.Method == HttpMethod.Put))
                {
                    var json = JsonSerializer.Serialize(request.Body);
                    httpRequest.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }

                var result = await this._http.SendAsync(httpRequest).ConfigureAwait(false);
                var jsonResponse = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

                responseEntity.StatusCode = result.StatusCode;
                responseEntity.RawResponse = jsonResponse;

                if (result.IsSuccessStatusCode && !string.IsNullOrWhiteSpace(jsonResponse))
                {
                    responseEntity.Data = JsonSerializer.Deserialize<T>(jsonResponse);
                }
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