// <copyright file="DbNameDatabaseContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Infrastructure.DataContext
{
    using ApiSeguimientoCADS.Api.Infrastructure.Entities;
    using System.Collections.Generic;

    /// <summary>
    /// Contexto en memoria que simula una fuente de datos de solo lectura.
    /// </summary>
    internal sealed class DbNameDatabaseContext
    {
        private readonly List<ProductEntity> _products = new()
        {
            new ProductEntity
            {
                Name = "Suscripción CADS",
                Price = 19.99m,
            },
            new ProductEntity
            {
                Name = "Reporte de Seguimiento",
                Price = 9.99m,
            },
        };

        /// <summary>
        /// Obtiene los productos registrados.
        /// </summary>
        /// <returns>Colección de entidades de producto.</returns>
        public IReadOnlyList<ProductEntity> GetProducts() => this._products;
    }
}