// <copyright file="JwtSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Settings
{
    /// <summary>
    /// Configuración para JWT (JSON Web Tokens)
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Clave secreta para firmar tokens
        /// </summary>
        public string Key { get; set; } = string.Empty;

        /// <summary>
        /// Emisor del token
        /// </summary>
        public string Issuer { get; set; } = string.Empty;

        /// <summary>
        /// Audiencia del token
        /// </summary>
        public string Audience { get; set; } = string.Empty;

        /// <summary>
        /// Tiempo de expiración en minutos
        /// </summary>
        public int ExpirationMinutes { get; set; } = 60;
    }
}