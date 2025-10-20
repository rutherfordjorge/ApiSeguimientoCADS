// <copyright file="DatosSiniestroExternalResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Responses
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Respuesta externa del endpoint de datos de siniestro de BCI
    /// </summary>
    public class DatosSiniestroExternalResponse : IExternalServiceResponse<DatosSiniestroDetalleDto>
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
        /// Lista de datos de siniestros
        /// </summary>
        [JsonPropertyName("data")]

        public IReadOnlyList<DatosSiniestroDetalleDto>? Data { get; set; } = Array.Empty<DatosSiniestroDetalleDto>();
    }
}