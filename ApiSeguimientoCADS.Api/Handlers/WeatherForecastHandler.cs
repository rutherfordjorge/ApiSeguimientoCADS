// <copyright file="WeatherForecastHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Handlers
{
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Models;
    using ApiSeguimientoCADS.Api.Models.Requests;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementación que coordina la obtención de pronósticos del clima.
    /// </summary>
    internal sealed class WeatherForecastHandler : IWeatherForecastHandler
    {
        private readonly IWeatherForecastService _weatherForecastService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="WeatherForecastHandler"/>.
        /// </summary>
        /// <param name="weatherForecastService">Servicio encargado de procesar la lógica de negocio.</param>
        public WeatherForecastHandler(IWeatherForecastService weatherForecastService)
        {
            this._weatherForecastService = weatherForecastService ?? throw new ArgumentNullException(nameof(weatherForecastService));
        }

        /// <inheritdoc />
        public IReadOnlyCollection<WeatherForecast> GetForecasts(WeatherForecastRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            return this._weatherForecastService.GetForecasts(request.City);
        }
    }
}