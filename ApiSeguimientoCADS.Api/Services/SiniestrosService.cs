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
    using System.Threading.Tasks;

    /// <summary>
    /// Servicio para consumir el API de siniestros de BCI
    /// </summary>
    public class SiniestrosService : ExternalApiServiceBase<SiniestrosService, SiniestrosApiSettings, SiniestrosExternalResponse, SiniestroDto>, ISiniestrosService
    {
        public SiniestrosService(
            IHttpClientService httpClientService,
            IOptions<SiniestrosApiSettings> settings,
            IAppLogger<SiniestrosService> logger)
            : base(httpClientService, settings, logger)
        {
        }

        protected override string OperationDisplayName => "siniestros";

        protected override object CreateDefaultMetrics(int totalItems) => new { TotalSiniestros = totalItems };

        protected override string GetSuccessLogMessage(SiniestrosExternalResponse externalResponse, int totalItems) => $"Siniestros obtenidos exitosamente. Total: {totalItems}";

        protected override string SuccessMessageFallback => "Siniestros obtenidos exitosamente";

        protected override string GetHttpErrorMessage(HttpStatusCode statusCode) => $"Error al consultar siniestros: {statusCode}";

        protected override string StatusErrorFallbackMessage => "Error en el servicio externo de siniestros";

        protected override string NetworkErrorMessage => "Error de comunicación con el servicio externo";

        protected override string OperationErrorMessage => "Error al procesar la solicitud";

        public Task<DefaultResponse<List<SiniestroDto>>> ObtenerSiniestrosPorAseguradoAsync(int rutAsegurado)
        {
            var logInput = new { RutAsegurado = rutAsegurado };
            var requestBody = new { RUTASEGURADO = rutAsegurado };

            return this.ExecuteAsync(
                logInput,
                $"Iniciando consulta de siniestros para RUT asegurado: {rutAsegurado}",
                $"Preparando request para URL: {this.Settings.Full}",
                requestBody,
                (response, total) => new { TotalSiniestros = total });
        }
    }
}