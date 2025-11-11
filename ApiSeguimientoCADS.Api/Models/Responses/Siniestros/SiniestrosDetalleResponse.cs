// <copyright file="SiniestrosDetalleResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Models.Responses.Siniestros
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Obtiene detalles de los siniestros
    /// </summary>
    public class SiniestrosDetalleResponse
    {
        /// <summary>
        /// Data
        /// </summary>
        [JsonPropertyName("data")]
        public IReadOnlyCollection<SiniestroDetalleDataResponse>? Data { get; set; }

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
        public string? SessionId { get; set; }
    }
}