// <copyright file="UserDataResonse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Responses.Cads
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// UserDataResonse
    /// </summary>
    public class UserDataResonse
    {
        /// <summary>
        /// IdUsuario
        /// </summary>
        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }

        /// <summary>
        /// Nombre usuario
        /// </summary>
        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }

        /// <summary>
        /// Apellido usuario
        /// </summary>
        [JsonPropertyName("apellido")]
        public string? Apellido { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }
}