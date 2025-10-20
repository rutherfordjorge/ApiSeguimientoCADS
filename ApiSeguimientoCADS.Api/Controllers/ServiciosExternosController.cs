// <copyright file="ServiciosExternosController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Controllers
{
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Models.Requests;
    using Asp.Versioning;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controlador que valida y obtiene valores de las API's externas.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/servicios-externos")]
    public class ServiciosExternosController(IServiciosExternosHandler handler) : Controller
    {
        private readonly IServiciosExternosHandler _handler = handler ?? throw new ArgumentNullException(nameof(handler));

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

            try
            {
                if (request == null)
                {
                    return this.BadRequest(new { Message = "La solicitud no puede ser nula." });
                }

                var urlFrontend = await this._handler.GenerarUrlFrontend(request).ConfigureAwait(false);

                return this.Redirect(urlFrontend);
            }
            catch (ArgumentException ex)
            {
                return this.BadRequest(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { Message = ex.Message, CorrelationId = correlationId });
            }
        }
    }
}