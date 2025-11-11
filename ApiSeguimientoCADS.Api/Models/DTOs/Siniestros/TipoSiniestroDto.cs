// <copyright file="TipoSiniestroDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.DTOs.Siniestros
{
    /// <summary>
    /// Tipo de siniestro
    /// </summary>
    public class TipoSiniestroDto
    {
        /// <summary>
        /// Nombre del tipo de siniestro
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Indica si es visible
        /// </summary>
        public bool Visible { get; set; }
    }
}