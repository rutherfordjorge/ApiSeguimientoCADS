// <copyright file="ITokenService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Services.Interfaces
{
    using ApiSeguimientoCADS.Api.Models.Requests;

    /// <summary>
    /// ITokenService
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// GenerarToken
        /// </summary>
        /// <param name="data">data</param>
        /// <returns>token</returns>
        string GenerateToken(TokenData data);
    }
}