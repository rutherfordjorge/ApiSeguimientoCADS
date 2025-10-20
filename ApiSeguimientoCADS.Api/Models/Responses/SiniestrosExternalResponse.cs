// <copyright file="SiniestrosExternalResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Responses
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Respuesta externa del endpoint de siniestros de BCI
    /// </summary>
    public class SiniestrosExternalResponse
    {
        /// <summary>
        /// Estado de la respuesta
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Comentario de la respuesta
        /// </summary>
        [JsonPropertyName("comentario")]
        public string Comentario { get; set; } = string.Empty;

        /// <summary>
        /// ID de sesión
        /// </summary>
        [JsonPropertyName("sessionId")]
        public int SessionId { get; set; }

        /// <summary>
        /// Lista de siniestros
        /// </summary>
        [JsonPropertyName("data")]
        public IReadOnlyList<SiniestroDto> Data { get; set; } = Array.Empty<SiniestroDto>();
    }
}