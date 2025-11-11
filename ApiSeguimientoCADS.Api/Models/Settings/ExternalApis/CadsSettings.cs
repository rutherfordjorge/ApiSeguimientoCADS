// <copyright file="CadsSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Models.Settings.ExternalApis
{
    /// <summary>
    /// CadsSettings
    /// </summary>
    public class CadsSettings
    {
        /// <summary>
        /// BasePath
        /// </summary>
        public string BasePath { get; set; } = null!;

        /// <summary>
        /// Endpoints
        /// </summary>
        public ApiCadsEndpoints Endpoints { get; set; } = null!;
    }
}