// <copyright file="ExternalRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Models.Requests
{
    using ApiSeguimientoCADS.Api.Models.Enums;

    /// <summary>
    /// ExternalRequest
    /// </summary>
    public record ExternalRequest
    {
        /// <summary>
        /// RutTitular
        /// </summary>
        public string? RutTitular { get; set; }

        /// <summary>
        /// Origen
        /// </summary>
        public EOrigen Origen { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// RutSolicitante
        /// </summary>
        public string? RutSolicitante { get; set; }

        /// <summary>
        /// Rol
        /// </summary>
        public ERol Rol { get; set; }

        /// <summary>
        /// RutCorredor
        /// </summary>
        public string? RutCorredor { get; set; }

        /// <summary>
        /// RutaOrigen
        /// </summary>
        public string RutaOrigen { get; set; } = null!;

        /// <summary>
        /// RutaDestino
        /// </summary>
        public string RutaDestino { get; set; } = null!;

        /// <summary>
        /// SessionId
        /// </summary>
        public string? SessionId { get; set; } = null!;
    }
}