// <copyright file="DatosSiniestroService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Models.Requests;
    using ApiSeguimientoCADS.Api.Models.Responses;
    using ApiSeguimientoCADS.Api.Models.Settings;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Servicio para consumir el API de datos de siniestro de BCI
    /// </summary>
    public class DatosSiniestroService : ExternalApiServiceBase<DatosSiniestroService, DatosSiniestroApiSettings, DatosSiniestroExternalResponse, DatosSiniestroDetalleDto>, IDatosSiniestroService
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DatosSiniestroService"/>.
        /// </summary>
        /// <param name="httpClientService">El servicio HTTP para realizar las llamadas a la API externa.</param>
        /// <param name="settings">La configuración de la API externa de datos de siniestro.</param>
        /// <param name="logger">El registrador de logs para esta instancia de servicio.</param>
        /// <exception cref="ArgumentNullException">
        /// Se produce si alguno de los parámetros <paramref name="httpClientService"/>, <paramref name="settings"/> o <paramref name="logger"/> es <c>null</c>.
        /// </exception>
        public DatosSiniestroService(
            IHttpClientService httpClientService,
            IOptions<DatosSiniestroApiSettings> settings,
            IAppLogger<DatosSiniestroService> logger)
            : base(httpClientService, settings, logger)
        {
        }

        /// <summary>
        /// Obtiene el nombre legible de la operación para usar en logs y mensajes.
        /// </summary>
        protected override string OperationDisplayName => "datos de siniestro";

        /// <summary>
        /// Crea las métricas predeterminadas con el número total de registros.
        /// </summary>
        /// <param name="totalItems">Cantidad total de registros obtenidos.</param>
        /// <returns>Un objeto con la métrica de total de registros.</returns>
        protected override object CreateDefaultMetrics(int totalItems) => new { TotalRegistros = totalItems };

        /// <summary>
        /// Obtiene el mensaje de log en caso de éxito incluyendo el total de registros.
        /// </summary>
        /// <param name="externalResponse">La respuesta externa de datos de siniestro.</param>
        /// <param name="totalItems">Cantidad total de registros obtenidos.</param>
        /// <returns>El mensaje de log de éxito.</returns>
        protected override string GetSuccessLogMessage(DatosSiniestroExternalResponse externalResponse, int totalItems) =>
            $"Datos de siniestro obtenidos exitosamente. Total registros: {totalItems}";

        /// <summary>
        /// Obtiene el mensaje de éxito por defecto cuando la respuesta externa no lo proporciona.
        /// </summary>
        protected override string SuccessMessageFallback => "Datos de siniestro obtenidos exitosamente";

        /// <summary>
        /// Obtiene el mensaje de error HTTP con el código de estado correspondiente.
        /// </summary>
        /// <param name="statusCode">El código de estado HTTP devuelto por el servicio externo.</param>
        /// <returns>Un mensaje de error con el código de estado.</returns>
        protected override string GetHttpErrorMessage(HttpStatusCode statusCode) =>
            $"Error al consultar datos de siniestro: {statusCode}";

        /// <summary>
        /// Obtiene el mensaje de error predeterminado para errores en el servicio externo.
        /// </summary>
        protected override string StatusErrorFallbackMessage => "Error en el servicio externo de datos de siniestro";

        /// <summary>
        /// Obtiene el mensaje de error cuando ocurre un problema de red al consultar el servicio externo.
        /// </summary>
        protected override string NetworkErrorMessage => "Error interno al consultar datos de siniestro";

        /// <summary>
        /// Obtiene el código de error asociado a errores internos de comunicación.
        /// </summary>
        protected override string NetworkErrorCode => "INTERNAL_ERROR";

        /// <summary>
        /// Obtiene el mensaje de error predeterminado cuando ocurre un error al procesar la solicitud.
        /// </summary>
        protected override string OperationErrorMessage => "Error al procesar la solicitud";

        /// <summary>
        /// Obtiene los datos de siniestro desde el servicio externo de manera asíncrona.
        /// </summary>
        /// <param name="request">La solicitud que contiene los criterios para obtener los datos de siniestro.</param>
        /// <returns>
        /// Una tarea que representa la operación asíncrona y contiene un <see cref="DefaultResponse{T}"/>
        /// con una lista de <see cref="DatosSiniestroDetalleDto"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Se produce si <paramref name="request"/> es <c>null</c>.</exception>
        public Task<DefaultResponse<List<DatosSiniestroDetalleDto>>> ObtenerDatosSiniestroAsync(DatosSiniestroRequest request, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(request);

            var logInput = new
            {
                request.NumeroSiniestro,
                request.NumeroRiesgo,
                request.NumeroItem,
                request.CodigoSucursal,
                request.CodigoTipoDocumento,
                request.NumeroDocumento,
                request.Patente,
            };

            var requestBody = new
            {
                i_Nsinie = request.NumeroSiniestro,
                i_Nriesg = request.NumeroRiesgo,
                i_Nitem = request.NumeroItem,
                i_Csucur = request.CodigoSucursal,
                i_Ctpdoc = request.CodigoTipoDocumento,
                i_Ndocto = request.NumeroDocumento,
                i_Patent = request.Patente ?? string.Empty,
            };

            return this.ExecuteAsync(
                logInput,
                $"Iniciando consulta de datos de siniestro. Número: {request.NumeroSiniestro}",
                $"Preparando request para URL: {this.Settings.Full}",
                requestBody,
                (response, total) => new { TotalRegistros = total },
                cancellationToken: cancellationToken);
        }
    }
}