// <copyright file="SiniestrosDataResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Responses.Siniestros
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Obtiene datos control de acceso del usuario
    /// </summary>
    public class SiniestrosDataResponse
    {
        /// <summary>
        /// RutCorredor
        /// </summary>
        [JsonPropertyName("RutCorredor")]
        public string? RutCorredor { get; set; }

        /// <summary>
        /// NumeroSiniestro
        /// </summary>
        [JsonPropertyName("NumeroSiniestro")]
        public int? NumeroSiniestro { get; set; }

        /// <summary>
        /// FechaSiniestro
        /// </summary>
        [JsonPropertyName("FechaSiniestro")]
        public string? FechaSiniestro { get; set; }

        /// <summary>
        /// FechaDenuncia
        /// </summary>
        [JsonPropertyName("FechaDenuncia")]
        public string? FechaDenuncia { get; set; }

        /// <summary>
        /// CodigoEstado
        /// </summary>
        [JsonPropertyName("CodigoEstado")]
        public string? CodigoEstado { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        [JsonPropertyName("Estado")]
        public string? Estado { get; set; }

        /// <summary>
        /// CodigoEtapa
        /// </summary>
        [JsonPropertyName("CodigoEtapa")]
        public string? CodigoEtapa { get; set; }

        /// <summary>
        /// Etapa
        /// </summary>
        [JsonPropertyName("Etapa")]
        public string? Etapa { get; set; }

        /// <summary>
        /// Ramo
        /// </summary>
        [JsonPropertyName("Ramo")]
        public string? Ramo { get; set; }

        /// <summary>
        /// NumeroPoliza
        /// </summary>
        [JsonPropertyName("NumeroPoliza")]

        public string? NumeroPoliza { get; set; }

        /// <summary>
        /// NumeroItem
        /// </summary>
        [JsonPropertyName("NumeroItem")]
        public string? NumeroItem { get; set; }

        /// <summary>
        /// TipoDano
        /// </summary>
        [JsonPropertyName("TipoDano")]
        public string? TipoDano { get; set; }
    }
}