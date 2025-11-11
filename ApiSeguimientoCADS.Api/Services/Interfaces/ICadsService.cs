// <copyright file="ICadsService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Services.Interfaces
{
    using ApiSeguimientoCADS.Api.Models.Requests.Cads;
    using ApiSeguimientoCADS.Api.Models.Responses.Cads;

    /// <summary>
    /// ICadsService
    /// </summary>
    public interface ICadsService
    {
        /// <summary>
        /// ValideUserAccess
        /// </summary>
        /// <param name="request">ExternalRequest</param>
        /// <returns>UserAccessResponse</returns>
        Task<UserAccessResponse?> ValideUserAccess(ValidateAccessRequest request);
    }
}