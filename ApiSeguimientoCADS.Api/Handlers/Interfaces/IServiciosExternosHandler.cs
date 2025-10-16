// <copyright file="IServiciosExternosHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Handlers.Interfaces
{
    using ApiSeguimientoCADS.Api.Models.Requests;

    /// <summary>
    /// IServiciosExternosHandler
    /// </summary>
    public interface IServiciosExternosHandler
    {
        /// <summary>
        /// GenerarUrlFrontend
        /// </summary>
        /// <returns>Url componente front</returns>
        Task<string> GenerarUrlFrontend(ExternalRequest request);
    }
}