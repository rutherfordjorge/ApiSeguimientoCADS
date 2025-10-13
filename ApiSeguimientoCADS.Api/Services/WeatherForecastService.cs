// <copyright file="WeatherForecastService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;

    /// <summary>
    /// Servicio que genera pronósticos del clima simulados.
    /// </summary>
    public sealed class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] _summaries =
        {
            "Congelado",
            "Frío",
            "Fresco",
            "Templado",
            "Cálido",
            "Caluroso",
            "Bochornoso",
        };

        /// <inheritdoc />
        public IReadOnlyCollection<WeatherForecast> GetForecasts(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("La ciudad es obligatoria.", nameof(city));
            }

            var random = new Random(city.GetHashCode(StringComparison.Ordinal));
            return Enumerable.Range(1, 5)
                .Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(index)),
                    TemperatureC = RandomNumberGenerator.GetInt32(-20, 55),
                    Summary = _summaries[RandomNumberGenerator.GetInt32(_summaries.Length)],
                })
                .ToArray();
        }
    }
}