// <copyright file="SiniestrosResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Responses.Siniestros
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Obtiene datos de los siniestros
    /// </summary>
    public class SiniestrosResponse
    {
        /// <summary>
        /// Data
        /// </summary>
        [JsonPropertyName("data")]
        public IReadOnlyCollection<SiniestrosDataResponse>? Data { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Version
        /// </summary>
        [JsonPropertyName("comentario")]
        public string? Comentario { get; set; }

        /// <summary>
        /// HostName
        /// </summary>
        [JsonPropertyName("sessionId")]
        public int? SessionId { get; set; }
    }
}