// <copyright file="IUsersHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Handlers.Interfaces
{
    using ApiSeguimientoCADS.Api.Models.Requests.Cads;

    /// <summary>
    /// IUsersHandler
    /// </summary>
    public interface IUsersHandler
    {
        /// <summary>
        /// GenerarUrlFrontend
        /// </summary>
        /// <returns>Url componente front</returns>
        Task<string> GenerarUrlFrontend(ValidateAccessRequest request);
    }
}