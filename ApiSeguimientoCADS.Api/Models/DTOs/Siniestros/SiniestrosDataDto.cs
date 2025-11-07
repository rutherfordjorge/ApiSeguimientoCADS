// <copyright file="SiniestrosDataDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.DTOs.Siniestros
{
    /// <summary>
    /// Datos de siniestros y tipos
    /// </summary>
    public class SiniestrosDataDto
    {
        /// <summary>
        /// Lista de tipos de siniestros
        /// </summary>
        public IList<TipoSiniestroDto> TiposSiniestros { get; } = new List<TipoSiniestroDto>();

        /// <summary>
        /// Lista de siniestros
        /// </summary>
        public IList<SiniestroDto> Siniestros { get; } = new List<SiniestroDto>();
    }
}