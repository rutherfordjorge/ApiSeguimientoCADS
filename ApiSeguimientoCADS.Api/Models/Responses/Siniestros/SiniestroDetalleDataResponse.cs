// <copyright file="SiniestroDetalleDataResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Responses.Siniestros
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Obtiene datos control de acceso del usuario
    /// </summary>
    public class SiniestroDetalleDataResponse
    {
        /// <summary>
        /// CodigoEmpresa
        /// </summary>
        [JsonPropertyName("CodigoEmpresa")]
        public string? CodigoEmpresa { get; set; }

        /// <summary>
        /// NombreEmpresa
        /// </summary>
        [JsonPropertyName("NombreEmpresa")]
        public string? NombreEmpresa { get; set; }

        /// <summary>
        /// NumeroSiniestro
        /// </summary>
        [JsonPropertyName("NumeroSiniestro")]
        public string? NumeroSiniestro { get; set; }

        /// <summary>
        /// CodigoSucursal
        /// </summary>
        [JsonPropertyName("CodigoSucursal")]
        public string? CodigoSucursal { get; set; }

        /// <summary>
        /// CodigoTipoDocumento
        /// </summary>
        [JsonPropertyName("CodigoTipoDocumento")]
        public string? CodigoTipoDocumento { get; set; }

        /// <summary>
        /// NumeroDocumento
        /// </summary>
        [JsonPropertyName("NumeroDocumento")]
        public string? NumeroDocumento { get; set; }

        /// <summary>
        /// NumeroItem
        /// </summary>
        [JsonPropertyName("NumeroItem")]
        public string? NumeroItem { get; set; }

        /// <summary>
        /// NumeroRiesgo
        /// </summary>
        [JsonPropertyName("NumeroRiesgo")]
        public string? NumeroRiesgo { get; set; }

        /// <summary>
        /// CodigoRamo
        /// </summary>
        [JsonPropertyName("CodigoRamo")]
        public string? CodigoRamo { get; set; }

        /// <summary>
        /// RutLiquidador
        /// </summary>
        [JsonPropertyName("RutLiquidador")]
        public string? RutLiquidador { get; set; }

        /// <summary>
        /// NombreLiquidador
        /// </summary>
        [JsonPropertyName("NombreLiquidador")]
        public string? NombreLiquidador { get; set; }

        /// <summary>
        /// ZonaLiquidador
        /// </summary>
        [JsonPropertyName("ZonaLiquidador")]
        public string? ZonaLiquidador { get; set; }

        /// <summary>
        /// RutTaller
        /// </summary>
        [JsonPropertyName("RutTaller")]
        public string? RutTaller { get; set; }

        /// <summary>
        /// LocalTaller
        /// </summary>
        [JsonPropertyName("LocalTaller")]
        public string? LocalTaller { get; set; }

        /// <summary>
        /// NombreTaller
        /// </summary>
        [JsonPropertyName("NombreTaller")]
        public string? NombreTaller { get; set; }

        /// <summary>
        /// DireccionTaller
        /// </summary>
        [JsonPropertyName("DireccionTaller")]
        public string? DireccionTaller { get; set; }

        /// <summary>
        /// FechaEntradaTaller
        /// </summary>
        [JsonPropertyName("FechaEntradaTaller")]
        public string? FechaEntradaTaller { get; set; }

        /// <summary>
        /// FechaSalidaTaller
        /// </summary>
        [JsonPropertyName("FechaSalidaTaller")]
        public string? FechaSalidaTaller { get; set; }

        /// <summary>
        /// DiasEnTaller
        /// </summary>
        [JsonPropertyName("DiasEnTaller")]
        public string? DiasEnTaller { get; set; }

        /// <summary>
        /// FechaActEstadoEqems
        /// </summary>
        [JsonPropertyName("FechaActEstadoEqems")]
        public string? FechaActEstadoEqems { get; set; }

        /// <summary>
        /// EstadoSiniestro
        /// </summary>
        [JsonPropertyName("EstadoSiniestro")]
        public string? EstadoSiniestro { get; set; }

        /// <summary>
        /// EtapaSiniestro
        /// </summary>
        [JsonPropertyName("EtapaSiniestro")]
        public string? EtapaSiniestro { get; set; }

        /// <summary>
        /// RutAsegurado
        /// </summary>
        [JsonPropertyName("RutAsegurado")]
        public string? RutAsegurado { get; set; }

        /// <summary>
        /// FechaIngresoTaller
        /// </summary>
        [JsonPropertyName("FechaIngresoTaller")]
        public string? FechaIngresoTaller { get; set; }

        /// <summary>
        /// Patente
        /// </summary>
        [JsonPropertyName("Patente")]
        public string? Patente { get; set; }

        /// <summary>
        /// JefeZonal
        /// </summary>
        [JsonPropertyName("JefeZonal")]
        public string? JefeZonal { get; set; }

        /// <summary>
        /// ClasificacionTaller
        /// </summary>
        [JsonPropertyName("ClasificacionTaller")]
        public string? ClasificacionTaller { get; set; }

        /// <summary>
        /// FechaDenuncio
        /// </summary>
        [JsonPropertyName("FechaDenuncio")]
        public string? FechaDenuncio { get; set; }

        /// <summary>
        /// CodigoEtapaRiesgo
        /// </summary>
        [JsonPropertyName("CodigoEtapaRiesgo")]
        public string? CodigoEtapaRiesgo { get; set; }

        /// <summary>
        /// DescripcionEtapaRiesgo
        /// </summary>
        [JsonPropertyName("DescripcionEtapaRiesgo")]
        public string? DescripcionEtapaRiesgo { get; set; }

        /// <summary>
        /// TipoLiquidador
        /// </summary>
        [JsonPropertyName("TipoLiquidador")]
        public string? TipoLiquidador { get; set; }

        /// <summary>
        /// GlosaTipoLiquidador
        /// </summary>
        [JsonPropertyName("GlosaTipoLiquidador")]
        public string? GlosaTipoLiquidador { get; set; }

        /// <summary>
        /// CodigoCobertura
        /// </summary>
        [JsonPropertyName("CodigoCobertura")]
        public string? CodigoCobertura { get; set; }

        /// <summary>
        /// DescripcionCobertura
        /// </summary>
        [JsonPropertyName("DescripcionCobertura")]
        public string? DescripcionCobertura { get; set; }
    }
}