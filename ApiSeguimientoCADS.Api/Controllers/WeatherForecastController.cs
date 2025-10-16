// <copyright file="WeatherForecastController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Controllers
{
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Models.Requests;
    using ApiSeguimientoCADS.Api.Models.Responses;
    using ApiSeguimientoCADS.Api.Security;
    using Asp.Versioning;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;

    /// <summary>
    /// Controlador que expone endpoints relacionados con el pronóstico del clima.
    /// </summary>
    [ApiController]
    [HeaderValidation]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/weather-forecasts")]
    public sealed class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastHandler _weatherForecastHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="weatherForecastHandler">Orquestador del módulo de pronósticos.</param>
        public WeatherForecastController(IWeatherForecastHandler weatherForecastHandler)
        {
            this._weatherForecastHandler = weatherForecastHandler ?? throw new ArgumentNullException(nameof(weatherForecastHandler));
        }

        /// <summary>
        /// Obtiene los pronósticos del clima filtrados por ciudad.
        /// </summary>
        /// <param name="request">Parámetros de búsqueda.</param>
        /// <returns>Respuesta con los pronósticos generados.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(WeatherForecastResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<WeatherForecastResponse> Get([FromQuery] WeatherForecastRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.City))
            {
                return this.BadRequest("La ciudad es obligatoria.");
            }

            var forecasts = this._weatherForecastHandler.GetForecasts(request);
            return this.Ok(new WeatherForecastResponse
            {
                Items = forecasts,
            });
        }
    }
}