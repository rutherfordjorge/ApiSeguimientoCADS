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
    public class ServiciosExternosController : BaseApiController<ServiciosExternosController>
    {
        private readonly IServiciosExternosHandler _handler;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ServiciosExternosController"/>.
        /// </summary>
        /// <param name="handler">Handler de servicios externos.</param>
        /// <param name="logger">Logger de la aplicación.</param>
        public ServiciosExternosController(IServiciosExternosHandler handler, IAppLogger<ServiciosExternosController> logger)
            : base(logger)
        {
            this._handler = handler ?? throw new ArgumentNullException(nameof(handler));
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
            var logInput = new
            {
                RutTitular = request?.RutTitular != null ? LogHelper.MaskRut(request.RutTitular) : "null",
                Origen = request?.Origen.ToString() ?? "null",
                Rol = request?.Rol.ToString() ?? "null",
            };

            var (correlationId, processId, stopwatch) = this.StartLoggingScope("[POST] /validate - Request recibido", logInput);
            try
            {
                if (request == null)
                {
                    this.Logger.LogError("Request es nulo");
                    this.EndLoggingScope(processId, stopwatch);
                    return this.BadRequest(new { Message = "La solicitud no puede ser nula." });
                }

                this.Logger.Debug("Request validado, delegando al handler");
                var urlFrontend = await this._handler.GenerarUrlFrontend(request).ConfigureAwait(false);

                this.Logger.Info("URL generada exitosamente. Redirigiendo al frontend");
                this.EndLoggingScope(processId, stopwatch);
                return this.Redirect(urlFrontend);
            }
            catch (ArgumentException ex)
            {
                this.EndLoggingScope(processId, stopwatch);
                this.Logger.LogError(ex);
                return this.BadRequest(new { Message = ex.Message, CorrelationId = correlationId });
            }
            catch (InvalidOperationException ex)
            {
                this.EndLoggingScope(processId, stopwatch);
                this.Logger.LogError(ex);
                this.Logger.LogError("[POST] /validate - Respuesta 500 InternalServerError");

                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { Message = ex.Message, CorrelationId = correlationId });
            }
        }
    }
}