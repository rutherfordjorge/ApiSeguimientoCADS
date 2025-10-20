// <copyright file="DatosSiniestroRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Requests
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Request para obtener datos detallados de un siniestro
    /// </summary>
    public record DatosSiniestroRequest
    {
        /// <summary>
        /// Número de siniestro
        /// </summary>
        [Required(ErrorMessage = "El número de siniestro es requerido")]
        public int NumeroSiniestro { get; set; }

        /// <summary>
        /// Número de riesgo
        /// </summary>
        [Required(ErrorMessage = "El número de riesgo es requerido")]
        public int NumeroRiesgo { get; set; }

        /// <summary>
        /// Número de ítem
        /// </summary>
        [Required(ErrorMessage = "El número de ítem es requerido")]
        public int NumeroItem { get; set; }

        /// <summary>
        /// Código de sucursal
        /// </summary>
        [Required(ErrorMessage = "El código de sucursal es requerido")]
        [StringLength(1, ErrorMessage = "El código de sucursal debe tener 1 carácter")]
        public string CodigoSucursal { get; set; } = string.Empty;

        /// <summary>
        /// Código de tipo de documento
        /// </summary>
        [Required(ErrorMessage = "El código de tipo de documento es requerido")]
        [StringLength(1, ErrorMessage = "El código de tipo de documento debe tener 1 carácter")]
        public string CodigoTipoDocumento { get; set; } = string.Empty;

        /// <summary>
        /// Número de documento
        /// </summary>
        [Required(ErrorMessage = "El número de documento es requerido")]
        public int NumeroDocumento { get; set; }

        /// <summary>
        /// Patente del vehículo (opcional)
        /// </summary>
        public string? Patente { get; set; }
    }
}
