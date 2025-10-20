// <copyright file="SiniestrosController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Controllers
{
    using ApiSeguimientoCADS.Api.Models.Requests;
    using ApiSeguimientoCADS.Api.Models.Responses;
    using ApiSeguimientoCADS.Api.Security;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using Asp.Versioning;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con siniestros
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/siniestros")]
    public class SiniestrosController : ControllerBase
    {
        private readonly ISiniestrosService siniestrosService;
        private readonly IAppLogger<SiniestrosController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SiniestrosController"/> class.
        /// </summary>
        /// <param name="siniestrosService">Servicio de siniestros</param>
        /// <param name="logger">Logger de la aplicación</param>
        public SiniestrosController(
            ISiniestrosService siniestrosService,
            IAppLogger<SiniestrosController> logger)
        {
            this.siniestrosService = siniestrosService ?? throw new ArgumentNullException(nameof(siniestrosService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
            var correlationId = this.HttpContext.Items["X-Request-ID"]?.ToString() ?? Guid.NewGuid().ToString();
            this.HttpContext.Items["CorrelationId"] = correlationId;

            var logInput = new
            {
                RutAsegurado = request?.RutAsegurado.ToString() ?? "null",
                RequestId = correlationId,
            };

            this.logger.LogInfo($"[POST] /siniestros/por-asegurado - Request recibido");
            var (processId, stopwatch) = this.logger.StartProcess(logInput);

            try
            {
                if (request == null)
                {
                    this.logger.LogError("Request es nulo");
                    this.logger.EndProcess(processId, stopwatch);
                    var errorResponse = new DefaultResponse<List<SiniestroDto>>(
                        success: false,
                        message: "La solicitud no puede ser nula.",
                        errorCode: "NULL_REQUEST");
                    return this.BadRequest(errorResponse);
                }

                if (!this.ModelState.IsValid)
                {
                    this.logger.LogError("Request inválido: ModelState tiene errores");
                    this.logger.EndProcess(processId, stopwatch);
                    var errors = string.Join(", ", this.ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    var validationErrorResponse = new DefaultResponse<List<SiniestroDto>>(
                        success: false,
                        message: $"Errores de validación: {errors}",
                        errorCode: "VALIDATION_ERROR");
                    return this.BadRequest(validationErrorResponse);
                }

                this.logger.LogDebug($"Consultando siniestros para RUT: {request.RutAsegurado}");
                var response = await this.siniestrosService.ObtenerSiniestrosPorAseguradoAsync(request.RutAsegurado);

                this.logger.EndProcess(processId, stopwatch);

                if (!response.Success)
                {
                    this.logger.LogWarning($"No se pudieron obtener siniestros: {response.Message}");
                    return this.BadRequest(response);
                }

                this.logger.LogInfo($"Siniestros obtenidos exitosamente. Total: {response.Data?.Count ?? 0}");
                return this.Ok(response);
            }
            catch (Exception ex)
            {
                this.logger.EndProcess(processId, stopwatch);
                this.logger.LogError($"Excepción al obtener siniestros: {ex.Message}", ex);

                var errorResponse = new DefaultResponse<List<SiniestroDto>>(
                    success: false,
                    message: "Error interno del servidor",
                    errorCode: "INTERNAL_SERVER_ERROR");

                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    errorResponse);
            }
        }
    }
}
