// <copyright file="ProductHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Handlers
{
    using ApiSeguimientoCADS.Api.Infrastructure.Repositories;
    using ApiSeguimientoCADS.Api.Models.Headers;
    using ApiSeguimientoCADS.Api.Models.Responses;
    using ApiSeguimientoCADS.Api.Services.Models;
    using System;
    using System.Linq;

    /// <summary>
    /// Maneja la orquestación del catálogo de productos.
    /// </summary>
    internal sealed class ProductHandler : IProductHandler
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ProductHandler"/>.
        /// </summary>
        /// <param name="productRepository">Repositorio de productos.</param>
        public ProductHandler(IProductRepository productRepository)
        {
            this._productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        /// <inheritdoc />
        public ProductListResponse GetProducts()
        {
            var products = this._productRepository
                .GetAll()
                .Select(product => new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                })
                .ToArray();

            return new ProductListResponse
            {
                Header = new HeaderBase
                {
                    Message = "Catálogo obtenido correctamente.",
                },
                Items = products,
            };
        }
    }
}