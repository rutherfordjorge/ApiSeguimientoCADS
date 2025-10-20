// <copyright file="DatosSiniestroApiSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Settings
{
    /// <summary>
    /// Configuración para el API de Datos de Siniestro
    /// </summary>
    public class DatosSiniestroApiSettings
    {
        /// <summary>
        /// URL base del API de datos de siniestro
        /// </summary>
        public string Base { get; set; } = string.Empty;

        /// <summary>
        /// Endpoint para obtener datos detallados de un siniestro
        /// </summary>
        public string Endpoint { get; set; } = string.Empty;

        /// <summary>
        /// Token de autorización (Basic Auth)
        /// </summary>
        public string AuthToken { get; set; } = string.Empty;

        /// <summary>
        /// Cookie requerida por el API
        /// </summary>
        public string Cookie { get; set; } = string.Empty;

        /// <summary>
        /// URL completa del endpoint
        /// </summary>
        public string Full => $"{this.Full}{this.Endpoint}";
    }
}