// <copyright file="ISiniestrosService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Services.Interfaces
{
    using ApiSeguimientoCADS.Api.Models.Requests.Siniestros;
    using ApiSeguimientoCADS.Api.Models.Responses.Siniestros;

    /// <summary>
    /// ICadsService
    /// </summary>
    public interface ISiniestrosService
    {
        /// <summary>
        /// GetSiniestrosPorAsegurado
        /// </summary>
        /// <param name="request">SiniestrosRequest</param>
        /// <returns>SiniestrosResponse</returns>
        Task<SiniestrosResponse> GetSiniestrosPorAsegurado(SiniestrosRequest request);

        /// <summary>
        /// GetDatosSiniestros
        /// </summary>
        /// <param name="request">SiniestrosDetRequest</param>
        /// <returns>SiniestrosDetResponse</returns>
        Task<SiniestrosDetalleResponse> GetDatosDelSiniestro(SiniestrosDetRequest request);
    }
}