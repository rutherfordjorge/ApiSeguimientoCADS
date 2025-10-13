// <copyright file="ProductModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services.Models
{
    using System;

    /// <summary>
    /// Modelo expuesto por los servicios para consumo de productos.
    /// </summary>
    public sealed class ProductModel
    {
        /// <summary>
        /// Obtiene o establece el identificador del producto.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Obtiene o establece el nombre descriptivo del producto.
        /// </summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el precio sugerido en moneda local.
        /// </summary>
        public decimal Price { get; init; }
    }
}