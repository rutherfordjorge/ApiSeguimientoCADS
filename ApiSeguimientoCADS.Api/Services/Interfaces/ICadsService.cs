// <copyright file="ICadsService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Define el contrato para el servicio CADS
    /// </summary>
    public interface ICadsService
    {
        /// <summary>
        /// Valida las credenciales del usuario en el sistema CADS
        /// </summary>
        /// <param name="rutTitular">RUT del titular</param>
        /// <param name="sessionId">ID de sesión</param>
        /// <returns>True si la validación es exitosa, false en caso contrario</returns>
        Task<bool> ValidarUsuarioAsync(string rutTitular, string sessionId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene información del usuario desde CADS
        /// </summary>
        /// <param name="rutTitular">RUT del titular</param>
        /// <returns>Información del usuario</returns>
        Task<object?> ObtenerInformacionUsuarioAsync(string rutTitular, CancellationToken cancellationToken = default);
    }
}