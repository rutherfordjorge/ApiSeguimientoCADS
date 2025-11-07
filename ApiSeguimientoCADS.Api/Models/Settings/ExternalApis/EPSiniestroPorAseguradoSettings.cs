// <copyright file="EPSiniestroPorAseguradoSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Models.Settings.ExternalApis
{
    /// <summary>
    /// CadsSettings
    /// </summary>
    public class EPSiniestroPorAseguradoSettings
    {
        /// <summary>
        /// BasePath
        /// </summary>
        public string BasePath { get; set; } = null!;

        /// <summary>
        /// Auth
        /// </summary>
        public string Auth { get; set; } = null!;

        /// <summary>
        /// TokenName
        /// </summary>
        public string TokenCABName { get; set; } = null!;

        /// <summary>
        /// TokenCABValue
        /// </summary>
        public string TokenCABValue { get; set; } = null!;

        /// <summary>
        /// CookieName
        /// </summary>
        public string CookieName { get; set; } = null!;

        /// <summary>
        /// CookieValue
        /// </summary>
        public string CookieValue { get; set; } = null!;

        /// <summary>
        /// ValidarAccesoMultipleUrl
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1056:Uri properties should not be strings", Justification = "Configuration binding works better with strings")]
        public string ValidarAccesoMultipleUrl { get; set; } = null!;
    }
}