// <copyright file="UsersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Controllers
{
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Helpers;
    using ApiSeguimientoCADS.Api.Models.Requests.Cads;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using Asp.Versioning;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Controlador para validación de acceso de usuarios y generación de URLs de redirección.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersHandler _handler;
        private readonly IAppLogger<UsersController> _logger;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UsersController"/>.
        /// </summary>
        /// <param name="handler">Handler de servicios externos.</param>
        /// <param name="logger">Logger de la aplicación.</param>
        public UsersController(IUsersHandler handler, IAppLogger<UsersController> logger)
        {
            this._handler = handler ?? throw new ArgumentNullException(nameof(handler));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Endpoint para validar el Token/SessionId del usuario de entrada.
        /// </summary>
        /// <param name="request">Datos de la solicitud externa.</param>
        /// <returns>URL de redirección al frontend.</returns>
        [HttpPost("[action]")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Validate([FromForm] ValidateAccessRequest request)
        {
            this._logger.Info("[POST] /validate - Request recibido");

            var logInput = this.CreateLogInput(request);
            var (processId, stopwatch) = this._logger.StartProcess(logInput);

            try
            {
                if (request == null)
                {
                    this._logger.LogError("Request es nulo");
                    this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = "NullRequest" });
                    return this.BadRequest(new { Message = "La solicitud no puede ser nula." });
                }

                this._logger.Debug("Request validado, delegando al handler");

                var urlFrontend = await this._handler.GenerarUrlFrontend(request).ConfigureAwait(false);

                this._logger.Info($"URL generada exitosamente: {urlFrontend}");
                this._logger.EndProcess(processId, stopwatch, new { Success = true, Action = "Redirect" });

                return this.Redirect(urlFrontend);
            }
            catch (OutOfMemoryException)
            {
                throw;
            }
            catch (StackOverflowException)
            {
                throw;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.LogError(ex, "Argumento nulo en la solicitud");
                this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = "ArgumentNullException" });
                return this.BadRequest(new { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                this._logger.LogError(ex, "Argumento inválido en la solicitud");
                this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = "ArgumentException" });
                return this.BadRequest(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                this._logger.LogError(ex, "Error de operación inválida al procesar la solicitud");
                this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = "InvalidOperationException" });

                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { Message = ex.Message });
            }
        }

        private object CreateLogInput(ValidateAccessRequest? request)
        {
            if (request == null)
            {
                this._logger.Debug("Request es nulo, retornando log input con valores 'null'");
                return new
                {
                    RutTitular = "null",
                    Origen = "null",
                    Rol = "null",
                };
            }

            this._logger.Debug("Creando log input para request válido");
            return new
            {
                RutTitular = !string.IsNullOrWhiteSpace(request.RutTitular)
                    ? this.SafeMaskRut(request.RutTitular)
                    : "null",
                Origen = request.Origen.ToString(),
                Rol = request.Rol.ToString(),
            };
        }

        private string SafeMaskRut(string rut)
        {
            try
            {
                var masked = LogHelper.MaskRut(rut);
                this._logger.Debug("RUT enmascarado exitosamente");
                return masked;
            }
            catch (ArgumentException ex)
            {
                this._logger.LogError(ex, "Error al enmascarar RUT, usando valor 'masked-error'");
                return "masked-error";
            }
            catch (FormatException ex)
            {
                this._logger.LogError(ex, "Error de formato al enmascarar RUT, usando valor 'format-error'");
                return "format-error";
            }
        }
    }
}