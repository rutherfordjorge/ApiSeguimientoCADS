// <copyright file="ProductsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Controllers
{
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Models.Responses;
    using ApiSeguimientoCADS.Api.Security;
    using Asp.Versioning;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;

    /// <summary>
    /// Controlador que expone el catálogo de productos de la plataforma.
    /// </summary>
    [ApiController]
    [HeaderValidation]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products")]
    public sealed class ProductsController : ControllerBase
    {
        private readonly IProductHandler _productHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="productHandler">Parametro.</param>
        public ProductsController(IProductHandler productHandler)
        {
            this._productHandler = productHandler ?? throw new ArgumentNullException(nameof(productHandler));
        }

        /// <summary>
        /// Obtiene todos los productos registrados en el catálogo.
        /// </summary>
        /// <returns>Respuesta con el detalle de los productos.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ProductListResponse), StatusCodes.Status200OK)]
        public ActionResult<ProductListResponse> Get()
        {
            var response = this._productHandler.GetProducts();
            return this.Ok(response);
        }
    }
}