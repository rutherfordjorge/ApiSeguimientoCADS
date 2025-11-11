// <copyright file="SiniestroDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.DTOs.Siniestros
{
    /// <summary>
    /// Información de un siniestro
    /// </summary>
    public class SiniestroDto
    {
        /// <summary>
        /// Número de siniestro
        /// </summary>
        public string NumSiniestro { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de siniestro
        /// </summary>
        public string TipoSinistros { get; set; } = string.Empty;

        /// <summary>
        /// Glosa del siniestro
        /// </summary>
        public string GlosaSiniestro { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de denuncio
        /// </summary>
        public string FechaDenuncio { get; set; } = string.Empty;

        /// <summary>
        /// Estado del siniestro
        /// </summary>
        public string EstadoSinistro { get; set; } = string.Empty;

        /// <summary>
        /// Estado del denuncio
        /// </summary>
        public string EstadoDenuncio { get; set; } = string.Empty;

        /// <summary>
        /// Indica si tiene acciones pendientes
        /// </summary>
        public bool AccionesPendientes { get; set; }
    }
}