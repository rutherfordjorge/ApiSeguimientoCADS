// <copyright file="JwtSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Models.Settings
{
    /// <summary>
    /// JwtSettings
    /// </summary>
    public record JwtSettings
    {
        /// <summary>
        /// Issuer
        /// </summary>
        public string Issuer { get; set; } = null!;

        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; } = null!;
    }
}