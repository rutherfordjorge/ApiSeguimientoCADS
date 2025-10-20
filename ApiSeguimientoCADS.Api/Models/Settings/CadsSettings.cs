// <copyright file="CadsSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Settings
{
    /// <summary>
    /// Configuración para el servicio CADS
    /// </summary>
    public class CadsSettings
    {
        /// <summary>
        /// URL base del servicio CADS
        /// </summary>
        public string Base { get; set; } = string.Empty;

        /// <summary>
        /// Endpoint de validación
        /// </summary>
        public string ValidationEndpoint { get; set; } = string.Empty;

        /// <summary>
        /// Token de autorización
        /// </summary>
        public string AuthToken { get; set; } = string.Empty;

        /// <summary>
        /// Timeout en segundos
        /// </summary>
        public int TimeoutSeconds { get; set; } = 30;

        /// <summary>
        /// URL completa del endpoint de validación
        /// </summary>
        public string Full => $"{this.Base}{this.ValidationEndpoint}";
    }
}