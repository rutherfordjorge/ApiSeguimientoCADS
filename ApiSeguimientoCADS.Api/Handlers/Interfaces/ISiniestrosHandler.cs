// <copyright file="ISiniestrosHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Handlers.Interfaces
{
    using ApiSeguimientoCADS.Api.Models.DTOs.Siniestros;
    using ApiSeguimientoCADS.Api.Models.Requests.Siniestros;
    using ApiSeguimientoCADS.Api.Models.Responses.Siniestros;

    /// <summary>
    /// IServiciosExternosHandler
    /// </summary>
    public interface ISiniestrosHandler
    {
        /// <summary>
        /// Obtiene el detalle completo de siniestros por asegurado aplicando todas las reglas de negocio.
        /// </summary>
        /// <param name="rut">RUT del asegurado.</param>
        /// <returns>Detalle completo de siniestros procesados.</returns>
        Task<SiniestrosDataDto> GetSiniestrosDetallePorAsegurado(string rut);

        /// <summary>
        /// GetSiniestrosPorAsegurado
        /// </summary>
        /// <returns>Siniestros por asegurado</returns>
        Task<SiniestrosResponse> GetSiniestrosPorAsegurado(SiniestrosRequest request);

        /// <summary>
        /// GetDatosSiniestros
        /// </summary>
        /// <returns>Detalle de siniestros</returns>
        Task<SiniestrosDetalleResponse> GetDetalleSiniestros(SiniestrosDetRequest request);
    }
}