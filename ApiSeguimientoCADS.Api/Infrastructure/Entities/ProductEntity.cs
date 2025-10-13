// <copyright file="ProductEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Infrastructure.Entities
{
    using System;

    /// <summary>
    /// Entidad simple que representa un producto disponible en la API.
    /// </summary>
    internal sealed class ProductEntity
    {
        /// <summary>
        /// Obtiene o establece el identificador del producto.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Obtiene o establece el nombre descriptivo del producto.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el precio sugerido.
        /// </summary>
        public decimal Price { get; set; }
    }
}