// <copyright file="WeatherForecastRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Requests
{
    /// <summary>
    /// Solicitud utilizada para filtrar pronósticos del clima por ciudad.
    /// </summary>
    public sealed class WeatherForecastRequest
    {
        /// <summary>
        /// Obtiene o establece el nombre de la ciudad a consultar.
        /// </summary>
        public string City { get; set; } = string.Empty;
    }
}