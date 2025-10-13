// <copyright file="ProductListResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Responses
{
    using ApiSeguimientoCADS.Api.Models.Headers;
    using ApiSeguimientoCADS.Api.Services.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Respuesta para exponer el catálogo de productos.
    /// </summary>
    public sealed class ProductListResponse
    {
        /// <summary>
        /// Obtiene o establece la cabecera estándar de la respuesta.
        /// </summary>
        public HeaderBase Header { get; set; } = new();

        /// <summary>
        /// Obtiene o establece la colección de productos.
        /// </summary>
        public IReadOnlyCollection<ProductModel> Items { get; set; } = Array.Empty<ProductModel>();
    }
}