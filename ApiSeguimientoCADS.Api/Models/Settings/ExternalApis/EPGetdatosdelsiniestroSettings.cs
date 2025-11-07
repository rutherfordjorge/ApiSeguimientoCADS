// <copyright file="EPGetdatosdelsiniestroSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Models.Settings.ExternalApis
{
    /// <summary>
    /// CadsSettings
    /// </summary>
    public class EPGetdatosdelsiniestroSettings : EPBaseSettings
    {
        /// <summary>
        /// TokenName
        /// </summary>
        public string ADCCOName { get; set; } = null!;

        /// <summary>
        /// TokenCABValue
        /// </summary>
        public string ADCCOValue { get; set; } = null!;
    }
}