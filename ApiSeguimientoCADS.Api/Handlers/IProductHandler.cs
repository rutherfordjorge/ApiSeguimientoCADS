// <copyright file="IProductHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Handlers
{
    using ApiSeguimientoCADS.Api.Models.Responses;

    /// <summary>
    /// Orquestador para el módulo de productos.
    /// </summary>
    public interface IProductHandler
    {
        /// <summary>
        /// Obtiene todos los productos disponibles en el catálogo.
        /// </summary>
        /// <returns>Respuesta con los productos registrados.</returns>
        ProductListResponse GetProducts();
    }
}