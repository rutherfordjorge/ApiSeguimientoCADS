// <copyright file="ValidateAccessRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Models.Requests.Cads
{
    using ApiSeguimientoCADS.Api.Models.Enums;

    /// <summary>
    /// ExternalRequest
    /// </summary>
    public record ValidateAccessRequest : GlobalRequest
    {
        /// <summary>
        /// RutTitular
        /// </summary>
        public string? RutTitular { get; set; }

        /// <summary>
        /// RutSolicitante
        /// </summary>
        public string? RutSolicitante { get; set; }

        /// <summary>
        /// Rol
        /// </summary>
        public ERol? Rol { get; set; }

        /// <summary>
        /// RutCorredor
        /// </summary>
        public string? RutCorredor { get; set; }
    }
}