// <copyright file="InMemoryProductRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Infrastructure.Repositories
{
    using ApiSeguimientoCADS.Api.Infrastructure.DataContext;
    using ApiSeguimientoCADS.Api.Infrastructure.Entities;
    using System.Collections.Generic;

    /// <summary>
    /// Implementación en memoria del repositorio de productos.
    /// </summary>
    internal sealed class InMemoryProductRepository : IProductRepository
    {
        private readonly DbNameDatabaseContext _context = new();

        /// <inheritdoc />
        public IReadOnlyCollection<ProductEntity> GetAll() => this._context.GetProducts();
    }
}