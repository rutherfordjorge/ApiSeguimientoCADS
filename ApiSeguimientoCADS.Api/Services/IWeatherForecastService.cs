// <copyright file="IWeatherForecastService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Define los servicios relacionados al pronóstico del clima.
    /// </summary>
    public interface IWeatherForecastService
    {
        /// <summary>
        /// Obtiene pronósticos asociados a una ciudad.
        /// </summary>
        /// <param name="city">Nombre de la ciudad.</param>
        /// <returns>Colección de pronósticos diarios.</returns>
        IReadOnlyCollection<WeatherForecast> GetForecasts(string city);
    }
}