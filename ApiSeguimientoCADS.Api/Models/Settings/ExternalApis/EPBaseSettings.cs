// <copyright file="EPBaseSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Models.Settings.ExternalApis
{
    /// <summary>
    /// CadsSettings
    /// </summary>
    public class EPBaseSettings
    {
        /// <summary>
        /// BasePath
        /// </summary>
        public string BasePath { get; set; } = null!;

        /// <summary>
        /// Auth
        /// </summary>
        public string Auth { get; set; } = null!;
    }
}