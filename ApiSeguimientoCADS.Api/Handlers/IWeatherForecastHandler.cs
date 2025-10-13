// <copyright file="IWeatherForecastHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Handlers
{
    using ApiSeguimientoCADS.Api.Models;
    using ApiSeguimientoCADS.Api.Models.Requests;
    using System.Collections.Generic;

    /// <summary>
    /// Define la orquestación para obtener pronósticos del clima.
    /// </summary>
    public interface IWeatherForecastHandler
    {
        /// <summary>
        /// Obtiene los pronósticos para la solicitud especificada.
        /// </summary>
        /// <param name="request">Solicitud de pronóstico.</param>
        /// <returns>Colección de pronósticos.</returns>
        IReadOnlyCollection<WeatherForecast> GetForecasts(WeatherForecastRequest request);
    }
}