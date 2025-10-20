// <copyright file="ServiciosExternosController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Controllers
{
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Helpers;
    using ApiSeguimientoCADS.Api.Models.Requests;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using Asp.Versioning;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Controlador que valida y obtiene valores de las API's externas.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/servicios-externos")]
    public class ServiciosExternosController : Controller
    {
        private readonly IServiciosExternosHandler _handler;
        private readonly IAppLogger<ServiciosExternosController> _logger;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ServiciosExternosController"/>.
        /// </summary>
        /// <param name="handler">Handler de servicios externos.</param>
        /// <param name="logger">Logger de la aplicación.</param>
        public ServiciosExternosController(IServiciosExternosHandler handler, IAppLogger<ServiciosExternosController> logger)
        {
            this._handler = handler ?? throw new ArgumentNullException(nameof(handler));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Endpoint para validar el Token/SessionId del usuario de entrada.
        /// </summary>
        /// <param name="request">Datos de la solicitud externa.</param>
        /// <returns>URL de redirección al frontend.</returns>
        [HttpPost("validate")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Validate([FromForm] ExternalRequest request)
        {
            var correlationId = this.HttpContext.Items["X-Request-ID"]?.ToString() ?? Guid.NewGuid().ToString();

            this.HttpContext.Items["CorrelationId"] = correlationId;

            // Log de inicio con datos enmascarados
            var logInput = new
            {
                RutTitular = request?.RutTitular != null ? LogHelper.MaskRut(request.RutTitular) : "null",
                Origen = request?.Origen.ToString() ?? "null",
                Rol = request?.Rol.ToString() ?? "null",
                RequestId = correlationId,
            };

            this._logger.Info($"[POST] /validate - Request recibido");
            var (processId, stopwatch) = this._logger.StartProcess(logInput);
            try
            {
                if (request == null)
                {
                    this._logger.LogError("Request es nulo");
                    this._logger.EndProcess(processId, stopwatch);
                    return this.BadRequest(new { Message = "La solicitud no puede ser nula." });
                }

                this._logger.Debug("Request validado, delegando al handler");
                var urlFrontend = await this._handler.GenerarUrlFrontend(request).ConfigureAwait(false);

                this._logger.Info($"URL generada exitosamente. Redirigiendo al frontend");
                this._logger.EndProcess(processId, stopwatch);
                return this.Redirect(urlFrontend);
            }
            catch (ArgumentException ex)
            {
                return this.BadRequest(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                this._logger.EndProcess(processId, stopwatch);
                this._logger.LogError(ex);
                this._logger.LogError($"[POST] /validate - Respuesta 500 InternalServerError");

                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { Message = ex.Message, CorrelationId = correlationId });
            }
        }
    }
}