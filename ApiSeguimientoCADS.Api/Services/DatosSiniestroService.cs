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
    using System.Threading.Tasks;

    /// <summary>
    /// Servicio para consumir el API de datos de siniestro de BCI
    /// </summary>
    public class DatosSiniestroService : ExternalApiServiceBase<DatosSiniestroService, DatosSiniestroApiSettings, DatosSiniestroExternalResponse, DatosSiniestroDetalleDto>, IDatosSiniestroService
    {
        public DatosSiniestroService(
            IHttpClientService httpClientService,
            IOptions<DatosSiniestroApiSettings> settings,
            IAppLogger<DatosSiniestroService> logger)
            : base(httpClientService, settings, logger)
        {
        }

        protected override string OperationDisplayName => "datos de siniestro";

        protected override object CreateDefaultMetrics(int totalItems) => new { TotalRegistros = totalItems };

        protected override string GetSuccessLogMessage(DatosSiniestroExternalResponse externalResponse, int totalItems) => $"Datos de siniestro obtenidos exitosamente. Total registros: {totalItems}";

        protected override string SuccessMessageFallback => "Datos de siniestro obtenidos exitosamente";

        protected override string GetHttpErrorMessage(HttpStatusCode statusCode) => $"Error al consultar datos de siniestro: {statusCode}";

        protected override string StatusErrorFallbackMessage => "Error en el servicio externo de datos de siniestro";

        protected override string NetworkErrorMessage => "Error interno al consultar datos de siniestro";

        protected override string NetworkErrorCode => "INTERNAL_ERROR";

        protected override string OperationErrorMessage => "Error al procesar la solicitud";

        public Task<DefaultResponse<List<DatosSiniestroDetalleDto>>> ObtenerDatosSiniestroAsync(DatosSiniestroRequest request)
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
                (response, total) => new { TotalRegistros = total });
        }
    }
}