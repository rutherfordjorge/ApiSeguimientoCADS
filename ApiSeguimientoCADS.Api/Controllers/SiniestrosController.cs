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
    using System.Globalization;

    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con siniestros
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/siniestros")]
    public class SiniestrosController : ControllerBase
    {
        private readonly ISiniestrosService _siniestrosService;
        private readonly IDatosSiniestroService _datosSiniestroService;
        private readonly IAppLogger<SiniestrosController> _logger;

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
        {
            this._siniestrosService = siniestrosService ?? throw new ArgumentNullException(nameof(siniestrosService));
            this._datosSiniestroService = datosSiniestroService ?? throw new ArgumentNullException(nameof(datosSiniestroService));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
            ArgumentNullException.ThrowIfNull(request);

            var correlationId = this.HttpContext.Items["X-Request-ID"]?.ToString() ?? Guid.NewGuid().ToString();
            this.HttpContext.Items["CorrelationId"] = correlationId;

            var logInput = new
            {
                RutAsegurado = request?.RutAsegurado.ToString(CultureInfo.InvariantCulture) ?? "null",
                RequestId = correlationId,
            };

            this._logger.Info($"[POST] /siniestros/por-asegurado - Request recibido");
            var (processId, stopwatch) = this._logger.StartProcess(logInput);

            try
            {
                if (request == null)
                {
                    this._logger.LogError("Request es nulo");
                    this._logger.EndProcess(processId, stopwatch);
                    var errorResponse = new DefaultResponse<List<SiniestroDto>>(
                        success: false,
                        message: "La solicitud no puede ser nula.",
                        errorCode: "NULL_REQUEST");
                    return this.BadRequest(errorResponse);
                }

                if (!this.ModelState.IsValid)
                {
                    this._logger.LogError("Request inválido: ModelState tiene errores");
                    this._logger.EndProcess(processId, stopwatch);
                    var errors = string.Join(", ", this.ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    var validationErrorResponse = new DefaultResponse<List<SiniestroDto>>(
                        success: false,
                        message: $"Errores de validación: {errors}",
                        errorCode: "VALIDATION_ERROR");
                    return this.BadRequest(validationErrorResponse);
                }

                this._logger.Debug($"Consultando siniestros para RUT: {request.RutAsegurado}");
                var response = await this._siniestrosService.ObtenerSiniestrosPorAseguradoAsync(request.RutAsegurado).ConfigureAwait(false);

                this._logger.EndProcess(processId, stopwatch);

                if (!response.Success)
                {
                    this._logger.Info($"No se pudieron obtener siniestros: {response.Message}");
                    return this.BadRequest(response);
                }

                this._logger.Info($"Siniestros obtenidos exitosamente. Total: {response.Data?.Count ?? 0}");
                return this.Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                this._logger.LogError(ex);
                this._logger.LogError($"Error de operación al consultar siniestros: {ex.Message}");
                this._logger.EndProcess(processId, stopwatch);

                var errorResponse = new DefaultResponse<List<SiniestroDto>>(
                    success: false,
                    message: "Error al procesar la solicitud",
                    data: null,
                    errorCode: "OPERATION_ERROR");

                return this.BadRequest(errorResponse);
            }
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
            ArgumentNullException.ThrowIfNull(request);

            var correlationId = this.HttpContext.Items["X-Request-ID"]?.ToString() ?? Guid.NewGuid().ToString();
            this.HttpContext.Items["CorrelationId"] = correlationId;

            var logInput = new
            {
                NumeroSiniestro = request?.NumeroSiniestro.ToString(CultureInfo.InvariantCulture) ?? "null",
                NumeroRiesgo = request?.NumeroRiesgo.ToString(CultureInfo.InvariantCulture) ?? "null",
                NumeroItem = request?.NumeroItem.ToString(CultureInfo.InvariantCulture) ?? "null",
                RequestId = correlationId,
            };

            this._logger.Info($"[POST] /siniestros/datos-detalle - Request recibido");
            var (processId, stopwatch) = this._logger.StartProcess(logInput);

            try
            {
                if (request == null)
                {
                    this._logger.LogError("Request es nulo");
                    this._logger.EndProcess(processId, stopwatch);
                    var errorResponse = new DefaultResponse<List<DatosSiniestroDetalleDto>>(
                        success: false,
                        message: "La solicitud no puede ser nula.",
                        errorCode: "NULL_REQUEST");
                    return this.BadRequest(errorResponse);
                }

                if (!this.ModelState.IsValid)
                {
                    this._logger.LogError("Request inválido: ModelState tiene errores");
                    this._logger.EndProcess(processId, stopwatch);
                    var errors = string.Join(", ", this.ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    var validationErrorResponse = new DefaultResponse<List<DatosSiniestroDetalleDto>>(
                        success: false,
                        message: $"Errores de validación: {errors}",
                        errorCode: "VALIDATION_ERROR");
                    return this.BadRequest(validationErrorResponse);
                }

                this._logger.Debug($"Consultando datos de siniestro: {request.NumeroSiniestro}");
                var response = await this._datosSiniestroService.ObtenerDatosSiniestroAsync(request).ConfigureAwait(false);

                this._logger.EndProcess(processId, stopwatch);

                if (!response.Success)
                {
                    this._logger.Info($"No se pudieron obtener datos del siniestro: {response.Message}");
                    return this.BadRequest(response);
                }

                this._logger.Info($"Datos de siniestro obtenidos exitosamente. Total registros: {response.Data?.Count ?? 0}");
                return this.Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                this._logger.LogError(ex);
                this._logger.LogError($"Error de operación al consultar siniestros: {ex.Message}");
                this._logger.EndProcess(processId, stopwatch);

                var errorResponse = new DefaultResponse<List<SiniestroDto>>(
                    success: false,
                    message: "Error al procesar la solicitud",
                    data: null,
                    errorCode: "OPERATION_ERROR");

                return this.BadRequest(errorResponse);
            }
        }
    }
}