namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Models.Responses;
    using ApiSeguimientoCADS.Api.Models.Settings;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Models;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public abstract class ExternalApiServiceBase<TService, TSettings, TExternalResponse, TItem>
        where TSettings : class, IExternalApiSettings
        where TExternalResponse : class, IExternalServiceResponse<TItem>
    {
        private readonly IHttpClientService _httpClientService;

        protected ExternalApiServiceBase(
            IHttpClientService httpClientService,
            IOptions<TSettings> settings,
            IAppLogger<TService> logger)
        {
            this._httpClientService = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));
            this.Settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected TSettings Settings { get; }

        protected IAppLogger<TService> Logger { get; }

        protected async Task<DefaultResponse<List<TItem>>> ExecuteAsync(
            object logInput,
            string startInfoMessage,
            string requestDebugMessage,
            object requestBody,
            Func<TExternalResponse, int, object?>? metricsFactory = null,
            Func<TExternalResponse, int, string>? successLogMessageFactory = null,
            Func<TExternalResponse, string>? successMessageFactory = null)
        {
            this.Logger.Info(startInfoMessage);
            var (processId, stopwatch) = this.Logger.StartProcess(logInput);

            try
            {
                this.Logger.Debug(requestDebugMessage);
                var apiRequest = this.CreatePostRequest(requestBody);
                this.Logger.Debug("Headers agregados. Enviando request al servicio externo...");

                var response = await this._httpClientService.SendAsync<TExternalResponse>(apiRequest).ConfigureAwait(false);

                if (!response.IsSuccess)
                {
                    var errorMessage = this.GetHttpErrorMessage(response.StatusCode);
                    this.Logger.LogError(errorMessage);
                    this.Logger.EndProcess(processId, stopwatch);
                    return new DefaultResponse<List<TItem>>(false, errorMessage, null, response.StatusCode.ToString());
                }

                var externalResponse = response.Data;
                if (externalResponse == null)
                {
                    this.Logger.LogError(this.NoDataMessage);
                    this.Logger.EndProcess(processId, stopwatch);
                    return new DefaultResponse<List<TItem>>(false, this.NoDataMessage, null, this.NoDataErrorCode);
                }

                if (!this.IsStatusSuccessful(externalResponse))
                {
                    var statusMessage = this.GetStatusErrorMessage(externalResponse);
                    this.Logger.LogError($"El servicio externo retornó status: {externalResponse.Status} - {externalResponse.Comentario}");
                    this.Logger.EndProcess(processId, stopwatch);
                    return new DefaultResponse<List<TItem>>(false, statusMessage, null, externalResponse.Status);
                }

                var items = externalResponse.Data?.ToList() ?? new List<TItem>();
                var totalItems = items.Count;

                var successLogMessage = successLogMessageFactory?.Invoke(externalResponse, totalItems) ?? this.GetSuccessLogMessage(externalResponse, totalItems);
                if (!string.IsNullOrWhiteSpace(successLogMessage))
                {
                    this.Logger.Info(successLogMessage);
                }

                var metrics = metricsFactory?.Invoke(externalResponse, totalItems) ?? this.CreateDefaultMetrics(totalItems);
                this.Logger.EndProcess(processId, stopwatch, metrics);

                var successMessage = successMessageFactory?.Invoke(externalResponse) ?? this.GetSuccessMessage(externalResponse);
                return new DefaultResponse<List<TItem>>(true, successMessage, items);
            }
            catch (HttpRequestException ex)
            {
                this.Logger.LogError(ex);
                this.Logger.LogError($"{this.NetworkErrorMessage}: {ex.Message}");
                this.Logger.EndProcess(processId, stopwatch);
                return new DefaultResponse<List<TItem>>(false, this.NetworkErrorMessage, null, this.NetworkErrorCode);
            }
            catch (InvalidOperationException ex)
            {
                this.Logger.LogError(ex);
                this.Logger.LogError($"{this.OperationErrorMessage}: {ex.Message}");
                this.Logger.EndProcess(processId, stopwatch);
                return new DefaultResponse<List<TItem>>(false, this.OperationErrorMessage, null, this.OperationErrorCode);
            }
        }

        protected virtual object CreateDefaultMetrics(int totalItems) => new { TotalItems = totalItems };

        protected virtual bool IsStatusSuccessful(TExternalResponse externalResponse) => string.Equals(externalResponse.Status, "200", StringComparison.OrdinalIgnoreCase);

        protected virtual string GetStatusErrorMessage(TExternalResponse externalResponse) => externalResponse.Comentario ?? this.StatusErrorFallbackMessage;

        protected virtual string GetSuccessMessage(TExternalResponse externalResponse) => externalResponse.Comentario ?? this.SuccessMessageFallback;

        protected virtual string GetSuccessLogMessage(TExternalResponse externalResponse, int totalItems) => $"{this.OperationDisplayName} obtenidos exitosamente. Total: {totalItems}";

        protected virtual string GetHttpErrorMessage(HttpStatusCode statusCode) => $"Error al consultar {this.OperationDisplayName}: {statusCode}";

        protected virtual string NoDataMessage => "No se recibieron datos del servicio externo";

        protected virtual string NetworkErrorMessage => "Error de comunicación con el servicio externo";

        protected virtual string NetworkErrorCode => "NETWORK_ERROR";

        protected virtual string OperationErrorMessage => "Error al procesar la solicitud";

        protected virtual string OperationErrorCode => "OPERATION_ERROR";

        protected virtual string StatusErrorFallbackMessage => $"Error en el servicio externo de {this.OperationDisplayName}";

        protected virtual string SuccessMessageFallback => $"{this.OperationDisplayName} obtenidos exitosamente";

        protected abstract string OperationDisplayName { get; }

        protected virtual string NoDataErrorCode => "NO_DATA";

        private ApiRequest CreatePostRequest(object requestBody)
        {
            var apiRequest = new ApiRequest
            {
                Url = new Uri(this.Settings.Full),
                Method = HttpMethod.Post,
                Body = requestBody,
            };

            apiRequest.Headers["Content-Type"] = "application/json";
            apiRequest.Headers["Authorization"] = this.Settings.AuthToken;
            apiRequest.Headers["Cookie"] = this.Settings.Cookie;

            return apiRequest;
        }
    }
}
