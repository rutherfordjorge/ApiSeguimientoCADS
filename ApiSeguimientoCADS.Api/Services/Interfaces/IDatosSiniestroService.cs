// <copyright file="IDatosSiniestroService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services.Interfaces
{
    using ApiSeguimientoCADS.Api.Models.Requests;
    using ApiSeguimientoCADS.Api.Models.Responses;
    using System.Threading;

    /// <summary>
    /// Define el contrato para el servicio de datos de siniestro
    /// </summary>
    public interface IDatosSiniestroService
    {
        /// <summary>
        /// Obtiene los datos detallados de un siniestro
        /// </summary>
        /// <param name="request">Request con los datos del siniestro</param>
        /// <returns>Datos detallados del siniestro</returns>
        Task<DefaultResponse<List<DatosSiniestroDetalleDto>>> ObtenerDatosSiniestroAsync(DatosSiniestroRequest request, CancellationToken cancellationToken = default);
    }
}