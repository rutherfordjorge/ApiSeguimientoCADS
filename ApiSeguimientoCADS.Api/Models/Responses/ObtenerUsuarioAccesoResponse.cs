// <copyright file="ObtenerUsuarioAccesoResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Responses
{
    using ApiSeguimientoCADS.Api.Models.Headers;

    /// <summary>
    /// Respuesta para exponer el catálogo de productos.
    /// </summary>
    public sealed class ObtenerUsuarioAccesoResponse
    {
        /// <summary>
        /// Obtiene o establece la cabecera estándar de la respuesta.
        /// </summary>
        public HeaderBase Header { get; set; } = new();
    }
}