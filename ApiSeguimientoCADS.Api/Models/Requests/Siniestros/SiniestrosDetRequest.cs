// <copyright file="SiniestrosDetRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Models.Requests.Siniestros
{
    /// <summary>
    /// SiniestrosRequest
    /// </summary>
    /// <summary>
    /// Representa la solicitud para obtener datos relacionados a los siniestros.
    /// </summary>
    public class SiniestrosDetRequest
    {
        /// <summary>
        /// Número de siniestro.
        /// </summary>
        public int INsinie { get; set; }

        /// <summary>
        /// Número de documento.
        /// </summary>
        public int INdocto { get; set; }
    }
}