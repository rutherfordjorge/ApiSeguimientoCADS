// <copyright file="SiniestroDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Responses
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// DTO de un siniestro
    /// </summary>
    public class SiniestroDto
    {
        /// <summary>
        /// RUT del corredor
        /// </summary>
        [JsonPropertyName("RutCorredor")]
        public string RutCorredor { get; set; } = string.Empty;

        /// <summary>
        /// Número de siniestro
        /// </summary>
        [JsonPropertyName("NumeroSiniestro")]
        public int NumeroSiniestro { get; set; }

        /// <summary>
        /// Fecha del siniestro
        /// </summary>
        [JsonPropertyName("FechaSiniestro")]
        public string FechaSiniestro { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de denuncia
        /// </summary>
        [JsonPropertyName("FechaDenuncia")]
        public string FechaDenuncia { get; set; } = string.Empty;

        /// <summary>
        /// Código del estado
        /// </summary>
        [JsonPropertyName("CodigoEstado")]
        public string CodigoEstado { get; set; } = string.Empty;

        /// <summary>
        /// Descripción del estado
        /// </summary>
        [JsonPropertyName("Estado")]
        public string Estado { get; set; } = string.Empty;

        /// <summary>
        /// Código de la etapa
        /// </summary>
        [JsonPropertyName("CodigoEtapa")]
        public string CodigoEtapa { get; set; } = string.Empty;

        /// <summary>
        /// Descripción de la etapa
        /// </summary>
        [JsonPropertyName("Etapa")]
        public string Etapa { get; set; } = string.Empty;

        /// <summary>
        /// Ramo del seguro
        /// </summary>
        [JsonPropertyName("Ramo")]
        public string Ramo { get; set; } = string.Empty;

        /// <summary>
        /// Número de póliza
        /// </summary>
        [JsonPropertyName("NumeroPoliza")]
        public string NumeroPoliza { get; set; } = string.Empty;

        /// <summary>
        /// Número de ítem
        /// </summary>
        [JsonPropertyName("NumeroItem")]
        public string NumeroItem { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de daño
        /// </summary>
        [JsonPropertyName("TipoDano")]
        public string TipoDano { get; set; } = string.Empty;
    }
}