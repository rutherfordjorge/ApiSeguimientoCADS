// <copyright file="SiniestrosController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Controllers
{
    using ApiSeguimientoCADS.Api.Models.Requests;
    using ApiSeguimientoCADS.Api.Models.Responses;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using Asp.Versioning;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;

    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con siniestros
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/siniestros")]
    public class SiniestrosController : BaseApiController<SiniestrosController>
    {
        private readonly ISiniestrosService _siniestrosService;
        private readonly IDatosSiniestroService _datosSiniestroService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SiniestrosController"/> class.
        /// </summary>
        /// <param name="siniestrosService">Servicio de siniestros</param>
        /// <param name="datosSiniestroService">Servicio de datos de siniestro</param>
        /// <param name="logger">Logger de la aplicación</param>
        public SiniestrosController(
            ISiniestrosService siniestrosService,
            IDatosSiniestroService datosSiniestroService,
            IAppLogger<SiniestrosController> logger)
            : base(logger)
        {
            this._siniestrosService = siniestrosService ?? throw new ArgumentNullException(nameof(siniestrosService));
            this._datosSiniestroService = datosSiniestroService ?? throw new ArgumentNullException(nameof(datosSiniestroService));
        }

        /// <summary>
        /// Obtiene los siniestros de un asegurado por su RUT
        /// </summary>
        /// <param name="request">Request con el RUT del asegurado</param>
        /// <returns>Lista de siniestros del asegurado</returns>
        [HttpPost("por-asegurado")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(DefaultResponse<List<SiniestroDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DefaultResponse<List<SiniestroDto>>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DefaultResponse<List<SiniestroDto>>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerSiniestrosPorAsegurado([FromBody] SiniestrosRequest request)
        {
            return await this.ExecuteDefaultResponseAsync<SiniestrosRequest, List<SiniestroDto>>(
                request,
                req => new
                {
                    RutAsegurado = req?.RutAsegurado.ToString(CultureInfo.InvariantCulture) ?? "null",
                    RequestId = this.HttpContext.Items["CorrelationId"]?.ToString() ?? string.Empty,
                },
                "[POST] /siniestros/por-asegurado - Request recibido",
                async req =>
                {
                    this.Logger.Debug($"Consultando siniestros para RUT: {req.RutAsegurado}");
                    return await this._siniestrosService.ObtenerSiniestrosPorAseguradoAsync(req.RutAsegurado, this.HttpContext.RequestAborted).ConfigureAwait(false);
                },
                response => new { TotalSiniestros = response.Data?.Count ?? 0 },
                response =>
                {
                    this.Logger.Info($"No se pudieron obtener siniestros: {response.Message}");
                    return this.BadRequest(response);
                },
                response => this.Logger.Info($"Siniestros obtenidos exitosamente. Total: {response.Data?.Count ?? 0}"))
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Obtiene los datos detallados de un siniestro específico
        /// </summary>
        /// <param name="request">Request con los datos del siniestro</param>
        /// <returns>Datos detallados del siniestro</returns>
        [HttpPost("datos-detalle")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(DefaultResponse<List<DatosSiniestroDetalleDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DefaultResponse<List<DatosSiniestroDetalleDto>>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DefaultResponse<List<DatosSiniestroDetalleDto>>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerDatosSiniestro([FromBody] DatosSiniestroRequest request)
        {
            return await this.ExecuteDefaultResponseAsync<DatosSiniestroRequest, List<DatosSiniestroDetalleDto>>(
                request,
                req => new
                {
                    NumeroSiniestro = req?.NumeroSiniestro.ToString(CultureInfo.InvariantCulture) ?? "null",
                    NumeroRiesgo = req?.NumeroRiesgo.ToString(CultureInfo.InvariantCulture) ?? "null",
                    NumeroItem = req?.NumeroItem.ToString(CultureInfo.InvariantCulture) ?? "null",
                    RequestId = this.HttpContext.Items["CorrelationId"]?.ToString() ?? string.Empty,
                },
                "[POST] /siniestros/datos-detalle - Request recibido",
                async req =>
                {
                    this.Logger.Debug($"Consultando datos de siniestro: {req.NumeroSiniestro}");
                    return await this._datosSiniestroService.ObtenerDatosSiniestroAsync(req, this.HttpContext.RequestAborted).ConfigureAwait(false);
                },
                response => new { TotalRegistros = response.Data?.Count ?? 0 },
                response =>
                {
                    this.Logger.Info($"No se pudieron obtener datos del siniestro: {response.Message}");
                    return this.BadRequest(response);
                },
                response => this.Logger.Info($"Datos de siniestro obtenidos exitosamente. Total registros: {response.Data?.Count ?? 0}"))
                .ConfigureAwait(false);
        }
    }
}