// <copyright file="UserAccessResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Responses.Cads
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Obtiene datos control de acceso del usuario
    /// </summary>
    public class UserAccessResponse
    {
        /// <summary>
        /// Data usuario
        /// </summary>
        [JsonPropertyName("data")]
        public UserDataResonse? Data { get; set; }

        /// <summary>
        /// Version
        /// </summary>
        [JsonPropertyName("version")]
        public string? Version { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }

        /// <summary>
        /// HostName
        /// </summary>
        [JsonPropertyName("hostName")]
        public string? HostName { get; set; }

        /// <summary>
        /// Code version
        /// </summary>
        [JsonPropertyName("codeVersion")]
        public string? CodeVersion { get; set; }
    }
}