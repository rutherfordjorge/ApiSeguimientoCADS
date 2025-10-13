// <copyright file="WeatherForecast.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models
{
    using System;

    /// <summary>
    /// Representa un pronóstico del clima diario.
    /// </summary>
    public sealed class WeatherForecast
    {
        /// <summary>
        /// Obtiene o establece la fecha del pronóstico.
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Obtiene o establece la temperatura en grados Celsius.
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Obtiene la temperatura equivalente en grados Fahrenheit.
        /// </summary>
        public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);

        /// <summary>
        /// Obtiene o establece un resumen del clima.
        /// </summary>
        public string? Summary { get; set; }
    }
}