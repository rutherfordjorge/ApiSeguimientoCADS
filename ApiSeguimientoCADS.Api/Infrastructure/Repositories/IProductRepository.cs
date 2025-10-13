// <copyright file="IProductRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Infrastructure.Repositories
{
    using ApiSeguimientoCADS.Api.Infrastructure.Entities;
    using System.Collections.Generic;

    /// <summary>
    /// Expone operaciones de consulta sobre los productos registrados.
    /// </summary>
    internal interface IProductRepository
    {
        /// <summary>
        /// Obtiene todos los productos disponibles.
        /// </summary>
        /// <returns>Colección de productos.</returns>
        IReadOnlyCollection<ProductEntity> GetAll();
    }
}