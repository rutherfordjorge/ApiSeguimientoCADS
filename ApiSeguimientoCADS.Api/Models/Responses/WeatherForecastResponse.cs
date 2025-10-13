// <copyright file="WeatherForecastResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Responses
{
    using ApiSeguimientoCADS.Api.Models;
    using ApiSeguimientoCADS.Api.Models.Headers;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Respuesta de la API para el pronóstico del clima.
    /// </summary>
    public sealed class WeatherForecastResponse
    {
        /// <summary>
        /// Obtiene o establece la cabecera de la respuesta.
        /// </summary>
        public HeaderBase Header { get; set; } = new();

        /// <summary>
        /// Obtiene o establece la colección de pronósticos.
        /// </summary>
        public IReadOnlyCollection<WeatherForecast> Items { get; set; } = Array.Empty<WeatherForecast>();
    }
}