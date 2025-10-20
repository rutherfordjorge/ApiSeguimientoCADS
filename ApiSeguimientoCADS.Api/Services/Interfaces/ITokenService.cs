// <copyright file="ITokenService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services.Interfaces
{
    /// <summary>
    /// Define el contrato para el servicio de generación de tokens JWT
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Genera un token JWT basado en los datos proporcionados
        /// </summary>
        /// <param name="rutTitular">RUT del titular</param>
        /// <param name="origen">Origen de la solicitud</param>
        /// <param name="rol">Rol del usuario</param>
        /// <returns>Token JWT generado</returns>
        string GenerateToken(string rutTitular, string origen, string rol);

        /// <summary>
        /// Valida un token JWT
        /// </summary>
        /// <param name="token">Token a validar</param>
        /// <returns>True si el token es válido, false en caso contrario</returns>
        bool ValidateToken(string token);
    }
}