// <copyright file="SiniestrosRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Requests
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Request para obtener siniestros por asegurado
    /// </summary>
    public record SiniestrosRequest
    {
        /// <summary>
        /// RUT del asegurado (sin puntos ni guión)
        /// </summary>
        [Required(ErrorMessage = "El RUT del asegurado es requerido")]
        public int RutAsegurado { get; set; }
    }
}
