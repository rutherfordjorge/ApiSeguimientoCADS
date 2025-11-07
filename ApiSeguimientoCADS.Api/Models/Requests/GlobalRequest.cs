// <copyright file="GlobalRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Requests
{
    using ApiSeguimientoCADS.Api.Models.Enums;

    /// <summary>
    /// GlobalRequest
    /// </summary>
    public record GlobalRequest
    {
        /// <summary>
        /// Token
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// Expiration
        /// </summary>
        public DateTime? Expiration { get; set; }

        /// <summary>
        /// Origen
        /// </summary>
        public EOrigen Origen { get; set; }

        /// <summary>
        /// RutaOrigen
        /// </summary>
        public string RutaOrigen { get; set; } = null!;

        /// <summary>
        /// SessionId
        /// </summary>
        public string? SessionId { get; set; } = null!;
    }
}