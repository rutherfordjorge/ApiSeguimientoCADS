// <copyright file="SiniestrosRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Models.Requests.Siniestros
{
    /// <summary>
    /// SiniestrosRequest
    /// </summary>
    public record SiniestrosRequest
    {
        /// <summary>
        /// RutAsegurado
        /// </summary>
        public string? RutAsegurado { get; set; }
    }
}