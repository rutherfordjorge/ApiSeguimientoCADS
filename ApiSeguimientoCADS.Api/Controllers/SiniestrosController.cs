// <copyright file="SiniestrosController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Controllers
{
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Helpers;
    using ApiSeguimientoCADS.Api.Models.Common;
    using ApiSeguimientoCADS.Api.Models.DTOs.Siniestros;
    using ApiSeguimientoCADS.Api.Models.Responses.Siniestros;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using Asp.Versioning;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Globalization;
    using System.Threading.Tasks;

    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con siniestros de seguros.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/")]
    public class SiniestrosController : ControllerBase
    {
        private readonly ISiniestrosHandler _handler;
        private readonly IAppLogger<SiniestrosController> _logger;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SiniestrosController"/>.
        /// </summary>
        /// <param name="handler">Handler de servicios externos.</param>
        /// <param name="logger">Logger de la aplicación.</param>
        public SiniestrosController(ISiniestrosHandler handler, IAppLogger<SiniestrosController> logger)
        {
            this._handler = handler ?? throw new ArgumentNullException(nameof(handler));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Endpoint para obtener el detalle de siniestros por asegurado
        /// </summary>
        /// <param name="rut">RUT del asegurado.</param>
        /// <returns>Detalle de siniestros del asegurado.</returns>
        [HttpGet("siniestros/{rut}/detalle")]
        [ProducesResponseType(typeof(SiniestrosResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDetSiniestrosPorAsegurado([FromRoute] string rut)
        {
            // Log de inicio con datos enmascarados
            var logInput = new
            {
                RutAsegurado = !string.IsNullOrWhiteSpace(rut) ? LogHelper.MaskRut(rut) : "null",
            };

            this._logger.Info($"{this.GetType().Name} - [GET] /siniestros/{{rut}}/detalle - Request recibido");
            var (processId, stopwatch) = this._logger.StartProcess(logInput);

            try
            {
                if (string.IsNullOrWhiteSpace(rut))
                {
                    this._logger.LogError($"{this.GetType().Name} - Parámetro RUT es nulo o vacío");
                    return this.BadRequest(CreateErrorResponse<object>(
                        "El RUT del asegurado es obligatorio.",
                        "VALIDATION_ERROR"));
                }

                this._logger.Debug($"{this.GetType().Name} - Delegando procesamiento al handler");
                var siniestrosDataDTO = await this._handler.GetSiniestrosDetallePorAsegurado(rut).ConfigureAwait(false);

                var (message, data) = ProcessSiniestrosResult(siniestrosDataDTO, rut);

                var response = new FrontResponse<SiniestrosDataDto>
                {
                    Success = true,
                    Message = message,
                    Data = data,
                    Timestamp = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture),
                };

                return this.Ok(response);
            }
            catch (ArgumentException ex)
            {
                this._logger.LogError(ex, $"{this.GetType().Name} - Validación fallida en request");
                return this.BadRequest(CreateErrorResponse<object>(ex.Message, "VALIDATION_ERROR"));
            }
            catch (OperationCanceledException ex)
            {
                this._logger.LogError(ex, $"{this.GetType().Name} - Operación cancelada por el usuario o timeout");
                return this.StatusCode(
                    StatusCodes.Status408RequestTimeout,
                    CreateErrorResponse<object>(
                        "La operación fue cancelada o excedió el tiempo límite",
                        "OPERATION_CANCELLED"));
            }
            catch (InvalidOperationException ex)
            {
                this._logger.LogError(ex, $"{this.GetType().Name} - Error de operación inválida");
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    CreateErrorResponse<object>("Ha ocurrido un error inesperado", "INTERNAL_ERROR"));
            }
            catch (KeyNotFoundException ex)
            {
                this._logger.LogError(ex, $"{this.GetType().Name} - Asegurado no encontrado");
                return this.NotFound(CreateErrorResponse<object>(
                    "El asegurado solicitado no fue encontrado",
                    "NOT_FOUND"));
            }
            finally
            {
                if (stopwatch != null && processId != Guid.Empty)
                {
                    this._logger.EndProcess(processId, stopwatch);
                }
            }
        }

        /// <summary>
        /// Procesa el resultado de siniestros y determina el mensaje y datos a retornar.
        /// </summary>
        /// <param name="siniestrosDataDTO">DTO con los siniestros obtenidos.</param>
        /// <param name="rut">RUT del asegurado.</param>
        /// <returns>Tupla con mensaje y datos procesados.</returns>
        private static (string Message, SiniestrosDataDto? Data) ProcessSiniestrosResult(
            SiniestrosDataDto siniestrosDataDTO,
            string rut)
        {
            if (siniestrosDataDTO.Siniestros.Count == 0)
            {
                return ($"{rut}: Sin siniestros VP disponibles", null);
            }

            return ($"{rut}: Siniestros obtenidos exitosamente", siniestrosDataDTO);
        }

        /// <summary>
        /// Crea una respuesta de error estandarizada.
        /// </summary>
        /// <typeparam name="T">Tipo de dato de la respuesta.</typeparam>
        /// <param name="message">Mensaje de error.</param>
        /// <param name="errorCode">Código de error.</param>
        /// <returns>Respuesta de error formateada.</returns>
        private static FrontResponse<T> CreateErrorResponse<T>(string message, string errorCode)
        {
            return new FrontResponse<T>
            {
                Success = false,
                Message = message,
                Data = default,
                ErrorCode = errorCode,
                Timestamp = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture),
            };
        }
    }
}