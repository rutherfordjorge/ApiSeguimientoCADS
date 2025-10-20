// <copyright file="DatosSiniestroDetalleDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Responses
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// DTO con datos detallados de un siniestro
    /// </summary>
    public class DatosSiniestroDetalleDto
    {
        /// <summary>
        /// Número de siniestro
        /// </summary>
        [JsonPropertyName("NSINIE")]
        public int NumeroSiniestro { get; set; }

        /// <summary>
        /// Número de patente
        /// </summary>
        [JsonPropertyName("NPATEN")]
        public string? Patente { get; set; }

        /// <summary>
        /// Código de vehículo
        /// </summary>
        [JsonPropertyName("CODVEH")]
        public string? CodigoVehiculo { get; set; }

        /// <summary>
        /// Tipo de vehículo
        /// </summary>
        [JsonPropertyName("TIPVEH")]
        public string? TipoVehiculo { get; set; }

        /// <summary>
        /// Código de marca
        /// </summary>
        [JsonPropertyName("CMARCA")]
        public string? CodigoMarca { get; set; }

        /// <summary>
        /// Descripción de marca
        /// </summary>
        [JsonPropertyName("DESMAR")]
        public string? DescripcionMarca { get; set; }

        /// <summary>
        /// Código de modelo
        /// </summary>
        [JsonPropertyName("CMODEL")]
        public string? CodigoModelo { get; set; }

        /// <summary>
        /// Descripción de modelo
        /// </summary>
        [JsonPropertyName("DESMOL")]
        public string? DescripcionModelo { get; set; }

        /// <summary>
        /// Código de versión
        /// </summary>
        [JsonPropertyName("CODVER")]
        public string? CodigoVersion { get; set; }

        /// <summary>
        /// Descripción de versión
        /// </summary>
        [JsonPropertyName("DESVER")]
        public string? DescripcionVersion { get; set; }

        /// <summary>
        /// Año de fabricación
        /// </summary>
        [JsonPropertyName("FANOFA")]
        public int? AnioFabricacion { get; set; }

        /// <summary>
        /// Fecha de siniestro
        /// </summary>
        [JsonPropertyName("FECSIN")]
        public string? FechaSiniestro { get; set; }

        /// <summary>
        /// Fecha de aviso
        /// </summary>
        [JsonPropertyName("FECAVI")]
        public string? FechaAviso { get; set; }

        /// <summary>
        /// Fecha de ingreso al sistema
        /// </summary>
        [JsonPropertyName("FECHA_INGRESO_SISTEMA")]
        public string? FechaIngresoSistema { get; set; }

        /// <summary>
        /// Estado del siniestro
        /// </summary>
        [JsonPropertyName("ESTADO_SINIESTRO")]
        public string? EstadoSiniestro { get; set; }

        /// <summary>
        /// Código de coafiliado 1
        /// </summary>
        [JsonPropertyName("CCOAF1")]
        public string? CodigoCoafiliado1 { get; set; }

        /// <summary>
        /// Código de coafiliado 2
        /// </summary>
        [JsonPropertyName("CCOAF2")]
        public string? CodigoCoafiliado2 { get; set; }

        /// <summary>
        /// Código de coafiliado 3
        /// </summary>
        [JsonPropertyName("CCOAF3")]
        public string? CodigoCoafiliado3 { get; set; }

        /// <summary>
        /// RUT del liquidador
        /// </summary>
        [JsonPropertyName("NRUTLIQ")]
        public int? RutLiquidador { get; set; }

        /// <summary>
        /// Dígito verificador del RUT del liquidador
        /// </summary>
        [JsonPropertyName("DRUTLIQ")]
        public string? DvLiquidador { get; set; }

        /// <summary>
        /// Nombre del liquidador
        /// </summary>
        [JsonPropertyName("NOMBLIQ")]
        public string? NombreLiquidador { get; set; }

        /// <summary>
        /// Teléfono del liquidador
        /// </summary>
        [JsonPropertyName("FONOLIQ")]
        public int? TelefonoLiquidador { get; set; }

        /// <summary>
        /// Celular del liquidador
        /// </summary>
        [JsonPropertyName("CELULIQ")]
        public string? CelularLiquidador { get; set; }

        /// <summary>
        /// Email del liquidador
        /// </summary>
        [JsonPropertyName("EMAILIQ")]
        public string? EmailLiquidador { get; set; }

        /// <summary>
        /// RUT del abonado
        /// </summary>
        [JsonPropertyName("NRUT_ABO")]
        public int? RutAbonado { get; set; }

        /// <summary>
        /// Dígito verificador del RUT del abonado
        /// </summary>
        [JsonPropertyName("DRUT_ABO")]
        public string? DvAbonado { get; set; }

        /// <summary>
        /// Nombre del abonado
        /// </summary>
        [JsonPropertyName("NOMBR_ABO")]
        public string? NombreAbonado { get; set; }

        /// <summary>
        /// Email del abonado
        /// </summary>
        [JsonPropertyName("EMAIL_ABO")]
        public string? EmailAbonado { get; set; }

        /// <summary>
        /// Código de tipo 01
        /// </summary>
        [JsonPropertyName("CTPR01")]
        public string? CodigoTipo01 { get; set; }

        /// <summary>
        /// Cliente
        /// </summary>
        [JsonPropertyName("CLIENTE")]
        public string? Cliente { get; set; }

        /// <summary>
        /// Valor de deducible
        /// </summary>
        [JsonPropertyName("VTDEDU")]
        public decimal? ValorDeducible { get; set; }

        /// <summary>
        /// Código de grado
        /// </summary>
        [JsonPropertyName("CGRADO")]
        public string? CodigoGrado { get; set; }

        /// <summary>
        /// Descripción de grado
        /// </summary>
        [JsonPropertyName("DESGRA")]
        public string? DescripcionGrado { get; set; }

        /// <summary>
        /// Código de colisión
        /// </summary>
        [JsonPropertyName("CCOLISI")]
        public string? CodigoColision { get; set; }

        /// <summary>
        /// Descripción de colisión
        /// </summary>
        [JsonPropertyName("COLISION")]
        public string? Colision { get; set; }

        /// <summary>
        /// Código de robo
        /// </summary>
        [JsonPropertyName("CROBO")]
        public string? CodigoRobo { get; set; }

        /// <summary>
        /// Indicador de aparición
        /// </summary>
        [JsonPropertyName("IAPARICI")]
        public string? IndicadorAparicion { get; set; }

        /// <summary>
        /// Cantidad de terceros
        /// </summary>
        [JsonPropertyName("CANTERCE")]
        public int? CantidadTerceros { get; set; }

        /// <summary>
        /// Descripción del accidente
        /// </summary>
        [JsonPropertyName("XDEACC")]
        public string? DescripcionAccidente { get; set; }

        /// <summary>
        /// Nombre del denunciante
        /// </summary>
        [JsonPropertyName("NOMBRDEN")]
        public string? NombreDenunciante { get; set; }

        /// <summary>
        /// Email del denunciante
        /// </summary>
        [JsonPropertyName("EMAILDEN")]
        public string? EmailDenunciante { get; set; }

        /// <summary>
        /// Teléfono 1 del denunciante
        /// </summary>
        [JsonPropertyName("FONO1DEN")]
        public string? Telefono1Denunciante { get; set; }

        /// <summary>
        /// Teléfono 2 del denunciante
        /// </summary>
        [JsonPropertyName("FONO2DEN")]
        public string? Telefono2Denunciante { get; set; }

        /// <summary>
        /// Nombre del asegurado
        /// </summary>
        [JsonPropertyName("NOMBRASE")]
        public string? NombreAsegurado { get; set; }

        /// <summary>
        /// Email del asegurado
        /// </summary>
        [JsonPropertyName("EMAILASE")]
        public string? EmailAsegurado { get; set; }

        /// <summary>
        /// Teléfono 1 del asegurado
        /// </summary>
        [JsonPropertyName("FONO1ASE")]
        public string? Telefono1Asegurado { get; set; }

        /// <summary>
        /// Teléfono 2 del asegurado
        /// </summary>
        [JsonPropertyName("FONO2ASE")]
        public string? Telefono2Asegurado { get; set; }

        /// <summary>
        /// Indicador de comunicación con asegurado
        /// </summary>
        [JsonPropertyName("IND_COMUNIC_ASE")]
        public string? IndicadorComunicacionAsegurado { get; set; }

        /// <summary>
        /// Código de sucursal
        /// </summary>
        [JsonPropertyName("CSUCUR")]
        public string? CodigoSucursal { get; set; }

        /// <summary>
        /// Código de ramo
        /// </summary>
        [JsonPropertyName("CRAMO")]
        public string? CodigoRamo { get; set; }

        /// <summary>
        /// Código de tipo de documento
        /// </summary>
        [JsonPropertyName("CTPDOC")]
        public string? CodigoTipoDocumento { get; set; }

        /// <summary>
        /// Número de documento
        /// </summary>
        [JsonPropertyName("NDOCTO")]
        public int? NumeroDocumento { get; set; }

        /// <summary>
        /// Número de ítem
        /// </summary>
        [JsonPropertyName("NITEM")]
        public int? NumeroItem { get; set; }

        /// <summary>
        /// Número de riesgo
        /// </summary>
        [JsonPropertyName("NRIESG")]
        public int? NumeroRiesgo { get; set; }

        /// <summary>
        /// Chasis
        /// </summary>
        [JsonPropertyName("CHASIS")]
        public string? Chasis { get; set; }

        /// <summary>
        /// Número de motor
        /// </summary>
        [JsonPropertyName("NMOTOR")]
        public string? NumeroMotor { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        [JsonPropertyName("XCOLOR")]
        public string? Color { get; set; }

        /// <summary>
        /// Número de puertas
        /// </summary>
        [JsonPropertyName("NPUERTAS")]
        public string? NumeroPuertas { get; set; }

        /// <summary>
        /// RUT del conductor
        /// </summary>
        [JsonPropertyName("RUTCONDUCTO")]
        public int? RutConductor { get; set; }

        /// <summary>
        /// Dígito verificador del conductor
        /// </summary>
        [JsonPropertyName("DIGCONDUCTO")]
        public string? DvConductor { get; set; }

        /// <summary>
        /// Nombre del conductor
        /// </summary>
        [JsonPropertyName("NOMBRCONDUC")]
        public string? NombreConductor { get; set; }

        /// <summary>
        /// Email del conductor
        /// </summary>
        [JsonPropertyName("EMAILCONDUC")]
        public string? EmailConductor { get; set; }

        /// <summary>
        /// Teléfono 1 del conductor
        /// </summary>
        [JsonPropertyName("FONOCONDUC1")]
        public string? Telefono1Conductor { get; set; }

        /// <summary>
        /// Teléfono 2 del conductor
        /// </summary>
        [JsonPropertyName("FONOCONDUC2")]
        public string? Telefono2Conductor { get; set; }

        /// <summary>
        /// Descripción de la etapa
        /// </summary>
        [JsonPropertyName("DES_ETAPA")]
        public string? DescripcionEtapa { get; set; }

        /// <summary>
        /// Moneda de la póliza
        /// </summary>
        [JsonPropertyName("Moneda_Pol")]
        public string? MonedaPoliza { get; set; }

        /// <summary>
        /// Pérdida estimada
        /// </summary>
        [JsonPropertyName("Perd_Estim")]
        public decimal? PerdidaEstimada { get; set; }

        /// <summary>
        /// Pérdida total
        /// </summary>
        [JsonPropertyName("Perd_Total")]
        public decimal? PerdidaTotal { get; set; }

        /// <summary>
        /// Nombre del taller
        /// </summary>
        [JsonPropertyName("Nombre_Taller")]
        public string? NombreTaller { get; set; }

        /// <summary>
        /// Dirección del taller
        /// </summary>
        [JsonPropertyName("Direcc_Taller")]
        public string? DireccionTaller { get; set; }

        /// <summary>
        /// Fecha de entrega
        /// </summary>
        [JsonPropertyName("Fecha_Entrega")]
        public string? FechaEntrega { get; set; }

        /// <summary>
        /// Código de estado
        /// </summary>
        [JsonPropertyName("Codigo_Estado")]
        public string? CodigoEstado { get; set; }

        /// <summary>
        /// Fecha de asignación
        /// </summary>
        [JsonPropertyName("Fecha_Asignacion")]
        public string? FechaAsignacion { get; set; }

        /// <summary>
        /// Dirección del siniestro
        /// </summary>
        [JsonPropertyName("Direccion_Sin")]
        public string? DireccionSiniestro { get; set; }

        /// <summary>
        /// Código del evento
        /// </summary>
        [JsonPropertyName("Codigo_Evento")]
        public string? CodigoEvento { get; set; }

        /// <summary>
        /// Descripción del evento
        /// </summary>
        [JsonPropertyName("Descri_Evento")]
        public string? DescripcionEvento { get; set; }

        /// <summary>
        /// Comisaría
        /// </summary>
        [JsonPropertyName("Comisaria")]
        public string? Comisaria { get; set; }

        /// <summary>
        /// Fecha de constancia
        /// </summary>
        [JsonPropertyName("Fecha_Const")]
        public string? FechaConstancia { get; set; }

        /// <summary>
        /// Folio de constancia
        /// </summary>
        [JsonPropertyName("Folio_Const")]
        public int? FolioConstancia { get; set; }

        /// <summary>
        /// Párrafo de constancia
        /// </summary>
        [JsonPropertyName("Parrafo_Const")]
        public int? ParrafoConstancia { get; set; }

        /// <summary>
        /// Indicador de fallecido
        /// </summary>
        [JsonPropertyName("Ind_Fallecido")]
        public string? IndicadorFallecido { get; set; }

        /// <summary>
        /// Dinámica del siniestro
        /// </summary>
        [JsonPropertyName("Dinamica_Sin")]
        public string? DinamicaSiniestro { get; set; }

        /// <summary>
        /// Campo de alerta
        /// </summary>
        [JsonPropertyName("Campo_Alerta")]
        public string? CampoAlerta { get; set; }

        /// <summary>
        /// RUT del denunciante
        /// </summary>
        [JsonPropertyName("Rut_Denunciante")]
        public int? RutDenunciante { get; set; }

        /// <summary>
        /// Dígito verificador del denunciante
        /// </summary>
        [JsonPropertyName("Dv_Denunciante")]
        public string? DvDenunciante { get; set; }
    }
}