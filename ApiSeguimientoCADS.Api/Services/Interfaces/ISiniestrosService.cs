// <copyright file="ISiniestrosService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services.Interfaces
{
    using ApiSeguimientoCADS.Api.Models.Responses;
    using System.Threading;

    /// <summary>
    /// Define el contrato para el servicio de siniestros
    /// </summary>
    public interface ISiniestrosService
    {
        /// <summary>
        /// Obtiene los siniestros de un asegurado por su RUT
        /// </summary>
        /// <param name="rutAsegurado">RUT del asegurado (sin puntos ni guión)</param>
        /// <returns>Lista de siniestros del asegurado</returns>
        Task<DefaultResponse<List<SiniestroDto>>> ObtenerSiniestrosPorAseguradoAsync(int rutAsegurado, CancellationToken cancellationToken = default);
    }
}