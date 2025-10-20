// <copyright file="ExternalApiServiceBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Models.Responses;
    using ApiSeguimientoCADS.Api.Models.Settings;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using ApiSeguimientoCADS.Api.Services.Models;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Clase base abstracta para la integración con servicios externos a través de HTTP.
    /// Proporciona la configuración, registro de logs y métodos de utilidad para la ejecución de llamadas a APIs externas.
    /// </summary>
    /// <typeparam name="TService">El tipo de servicio que implementa esta clase base.</typeparam>
    /// <typeparam name="TSettings">El tipo de configuración que implementa <see cref="IExternalApiSettings"/>.</typeparam>
    /// <typeparam name="TExternalResponse">El tipo de respuesta externa que implementa <see cref="IExternalServiceResponse{TItem}"/>.</typeparam>
    /// <typeparam name="TItem">El tipo de elemento contenido en la respuesta externa.</typeparam>
    public abstract class ExternalApiServiceBase<TService, TSettings, TExternalResponse, TItem>
        where TSettings : class, IExternalApiSettings
        where TExternalResponse : class, IExternalServiceResponse<TItem>
    {
        private readonly IHttpClientService _httpClientService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ExternalApiServiceBase{TService, TSettings, TExternalResponse, TItem}"/>.
        /// </summary>
        /// <param name="httpClientService">El servicio HTTP para realizar las llamadas a la API externa.</param>
        /// <param name="settings">La configuración de la API externa.</param>
        /// <param name="logger">El registrador de logs para la instancia de servicio.</param>
        /// <exception cref="ArgumentNullException">
        /// Se produce si alguno de los parámetros <paramref name="httpClientService"/>, <paramref name="settings"/> o <paramref name="logger"/> es <c>null</c>.
        /// </exception>
        protected ExternalApiServiceBase(
            IHttpClientService httpClientService,
            IOptions<TSettings> settings,
            IAppLogger<TService> logger)
        {
            this._httpClientService = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));
            this.Settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Obtiene la configuración de la API externa.
        /// </summary>
        protected TSettings Settings { get; }

        /// <summary>
        /// Obtiene el registrador de logs para la instancia de servicio.
        /// </summary>
        protected IAppLogger<TService> Logger { get; }

        /// <summary>
        /// Ejecuta de manera asíncrona la operación de consumo de la API externa y devuelve una respuesta con la lista de elementos.
        /// </summary>
        /// <returns>Una tarea que representa la operación asíncrona y contiene un <see cref="DefaultResponse{T}"/> con una lista de <typeparamref name="TItem"/>.</returns>
        protected async Task<DefaultResponse<List<TItem>>> ExecuteAsync(
            object logInput,
            string startInfoMessage,
            string requestDebugMessage,
            object requestBody,
            Func<TExternalResponse, int, object?>? metricsFactory = null,
            Func<TExternalResponse, int, string>? successLogMessageFactory = null,
            Func<TExternalResponse, string>? successMessageFactory = null,
            CancellationToken cancellationToken = default)
        {
            this.Logger.Info(startInfoMessage);
            var (processId, stopwatch) = this.Logger.StartProcess(logInput);

            try
            {
                this.Logger.Debug(requestDebugMessage);
                var apiRequest = this.CreatePostRequest(requestBody);
                this.Logger.Debug("Headers agregados. Enviando request al servicio externo...");

                var response = await this._httpClientService.SendAsync<TExternalResponse>(apiRequest, cancellationToken).ConfigureAwait(false);

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
            catch (OperationCanceledException)
            {
                this.Logger.Info("Operación cancelada por el consumidor.");
                this.Logger.EndProcess(processId, stopwatch);
                throw;
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

        /// <summary>
        /// Crea las métricas predeterminadas con el número total de elementos especificado.
        /// </summary>
        /// <param name="totalItems">Cantidad total de elementos.</param>
        /// <returns>Un objeto que contiene las métricas predeterminadas.</returns>
        protected virtual object CreateDefaultMetrics(int totalItems) => new { TotalItems = totalItems };

        /// <summary>
        /// Determina si la respuesta externa indica un estado exitoso.
        /// </summary>
        /// <param name="externalResponse">La respuesta externa.</param>
        /// <returns><c>true</c> si el estado es "200"; en caso contrario, <c>false</c>.</returns>
        protected virtual bool IsStatusSuccessful(TExternalResponse externalResponse) =>
            externalResponse != null && string.Equals(externalResponse.Status, "200", StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Obtiene el mensaje de error de estado a partir de la respuesta externa.
        /// </summary>
        /// <param name="externalResponse">La respuesta externa.</param>
        /// <returns>El mensaje de error o un mensaje predeterminado si no existe.</returns>
        protected virtual string GetStatusErrorMessage(TExternalResponse externalResponse) =>
            externalResponse?.Comentario ?? this.StatusErrorFallbackMessage;

        /// <summary>
        /// Obtiene el mensaje de éxito a partir de la respuesta externa.
        /// </summary>
        /// <param name="externalResponse">La respuesta externa.</param>
        /// <returns>El mensaje de éxito o un mensaje predeterminado si no existe.</returns>
        protected virtual string GetSuccessMessage(TExternalResponse externalResponse) =>
            externalResponse?.Comentario ?? this.StatusErrorFallbackMessage;

        /// <summary>
        /// Obtiene un mensaje de log de éxito incluyendo la cantidad total de elementos.
        /// </summary>
        /// <param name="externalResponse">La respuesta externa.</param>
        /// <param name="totalItems">La cantidad total de elementos obtenidos.</param>
        /// <returns>El mensaje de log de éxito.</returns>
        protected virtual string GetSuccessLogMessage(TExternalResponse externalResponse, int totalItems) =>
            $"{this.OperationDisplayName} obtenidos exitosamente. Total: {totalItems}";

        /// <summary>
        /// Obtiene un mensaje de error de HTTP que incluye el nombre de la operación.
        /// </summary>
        /// <param name="statusCode">El código de estado HTTP devuelto.</param>
        /// <returns>Un mensaje de error con el código de estado HTTP.</returns>
        protected virtual string GetHttpErrorMessage(HttpStatusCode statusCode) =>
            $"Error al consultar {this.OperationDisplayName}: {statusCode}";

        /// <summary>
        /// Mensaje que se muestra cuando no se recibieron datos del servicio externo.
        /// </summary>
        protected virtual string NoDataMessage => "No se recibieron datos del servicio externo";

        /// <summary>
        /// Mensaje que se muestra cuando ocurre un error de comunicación con el servicio externo.
        /// </summary>
        protected virtual string NetworkErrorMessage => "Error de comunicación con el servicio externo";

        /// <summary>
        /// Código de error estándar para errores de red.
        /// </summary>
        protected virtual string NetworkErrorCode => "NETWORK_ERROR";

        /// <summary>
        /// Mensaje que se muestra cuando ocurre un error al procesar la solicitud.
        /// </summary>
        protected virtual string OperationErrorMessage => "Error al procesar la solicitud";

        /// <summary>
        /// Código de error estándar para errores de operación.
        /// </summary>
        protected virtual string OperationErrorCode => "OPERATION_ERROR";

        /// <summary>
        /// Mensaje de error predeterminado que se muestra cuando el servicio externo devuelve un error.
        /// </summary>
        protected virtual string StatusErrorFallbackMessage => $"Error en el servicio externo de {this.OperationDisplayName}";

        /// <summary>
        /// Mensaje de éxito predeterminado cuando no se recibe uno de la respuesta externa.
        /// </summary>
        protected virtual string SuccessMessageFallback => $"{this.OperationDisplayName} obtenidos exitosamente";

        /// <summary>
        /// Nombre legible de la operación que se está ejecutando.
        /// </summary>
        protected abstract string OperationDisplayName { get; }

        /// <summary>
        /// Código de error estándar cuando no se reciben datos.
        /// </summary>
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