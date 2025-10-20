// <copyright file="SiniestrosService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Models.Responses;
    using ApiSeguimientoCADS.Api.Models.Settings;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Servicio responsable de consumir el API de siniestros de BCI.
    /// Hereda de <see cref="ExternalApiServiceBase{TService, TSettings, TExternalResponse, TItem}"/>
    /// /// para aprovechar la lógica genérica de ejecución, logging y manejo de errores.
    /// </summary>
    public class SiniestrosService
        : ExternalApiServiceBase<SiniestrosService, SiniestrosApiSettings, SiniestrosExternalResponse, SiniestroDto>,
          ISiniestrosService
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SiniestrosService"/>.
        /// </summary>
        /// <param name="httpClientService">El servicio HTTP para realizar las llamadas a la API externa.</param>
        /// <param name="settings">La configuración de la API de siniestros.</param>
        /// <param name="logger">El registrador de logs para esta instancia de servicio.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Se produce si <paramref name="httpClientService"/>, <paramref name="settings"/> o <paramref name="logger"/> es <c>null</c>.
        /// </exception>
        public SiniestrosService(
            IHttpClientService httpClientService,
            IOptions<SiniestrosApiSettings> settings,
            IAppLogger<SiniestrosService> logger)
            : base(httpClientService, settings, logger)
        {
        }

        /// <summary>
        /// Obtiene el nombre legible de la operación para logs y mensajes de salida.
        /// </summary>
        protected override string OperationDisplayName => "siniestros";

        /// <summary>
        /// Crea las métricas predeterminadas con el número total de siniestros obtenidos.
        /// </summary>
        /// <param name="totalItems">Cantidad total de siniestros.</param>
        /// <returns>Un objeto que contiene la métrica de total de siniestros.</returns>
        protected override object CreateDefaultMetrics(int totalItems) => new { TotalSiniestros = totalItems };

        /// <summary>
        /// Obtiene el mensaje de log en caso de éxito, incluyendo el total de siniestros.
        /// </summary>
        /// <param name="externalResponse">La respuesta externa de la API de siniestros.</param>
        /// <param name="totalItems">Cantidad total de siniestros obtenidos.</param>
        /// <returns>Un mensaje de log de éxito.</returns>
        protected override string GetSuccessLogMessage(SiniestrosExternalResponse externalResponse, int totalItems) =>
            $"Siniestros obtenidos exitosamente. Total: {totalItems}";

        /// <summary>
        /// Obtiene el mensaje de éxito predeterminado cuando no se recibe uno desde la API externa.
        /// </summary>
        protected override string SuccessMessageFallback => "Siniestros obtenidos exitosamente";

        /// <summary>
        /// Obtiene un mensaje de error estándar cuando la API externa devuelve un código HTTP de error.
        /// </summary>
        /// <param name="statusCode">El código de estado HTTP devuelto por la API.</param>
        /// <returns>El mensaje de error correspondiente.</returns>
        protected override string GetHttpErrorMessage(HttpStatusCode statusCode) =>
            $"Error al consultar siniestros: {statusCode}";

        /// <summary>
        /// Obtiene el mensaje de error predeterminado para fallas en la API externa.
        /// </summary>
        protected override string StatusErrorFallbackMessage => "Error en el servicio externo de siniestros";

        /// <summary>
        /// Obtiene el mensaje de error estándar cuando ocurre un problema de comunicación con la API externa.
        /// </summary>
        protected override string NetworkErrorMessage => "Error de comunicación con el servicio externo";

        /// <summary>
        /// Obtiene el mensaje de error predeterminado cuando ocurre un error al procesar la solicitud.
        /// </summary>
        protected override string OperationErrorMessage => "Error al procesar la solicitud";

        /// <summary>
        /// Obtiene la lista de siniestros asociados a un asegurado a través de su RUT.
        /// </summary>
        /// <param name="rutAsegurado">El RUT del asegurado para el que se consultan los siniestros.</param>
        /// <returns>
        /// Una tarea que representa la operación asíncrona y contiene un <see cref="DefaultResponse{T}"/>
        /// con una lista de <see cref="SiniestroDto"/>.
        /// </returns>
        public Task<DefaultResponse<List<SiniestroDto>>> ObtenerSiniestrosPorAseguradoAsync(int rutAsegurado, CancellationToken cancellationToken = default)
        {
            var logInput = new { RutAsegurado = rutAsegurado };
            var requestBody = new { RUTASEGURADO = rutAsegurado };

            return this.ExecuteAsync(
                logInput,
                $"Iniciando consulta de siniestros para RUT asegurado: {rutAsegurado}",
                $"Preparando request para URL: {this.Settings.Full}",
                requestBody,
                (response, total) => new { TotalSiniestros = total },
                cancellationToken: cancellationToken);
        }
    }
}