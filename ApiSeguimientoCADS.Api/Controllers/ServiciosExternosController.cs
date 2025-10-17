// <copyright file="ServiciosExternosController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Controllers
{
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
    public class ServiciosExternosController : Controller
    {
        /// <summary>
        /// Endpoint para validar el Token/SessionId del usuario de entrada.
        /// </summary>
        /// <returns>A <see cref="Task{IActionResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost("Validate")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Validate([FromForm] ExternalRequest request)
        {
            try
            {
                // Simulación de una tarea asíncrona, útil durante el desarrollo
                // FALTA LOG
                await Task.Yield();
                return this.Redirect("sad");
            }
            catch (InvalidOperationException ex)
            {
                // FALTA LOG
                InvalidOperationException exception = ex as InvalidOperationException;
                return this.BadRequest("Error en la operación.");
            }
        }
    }
}