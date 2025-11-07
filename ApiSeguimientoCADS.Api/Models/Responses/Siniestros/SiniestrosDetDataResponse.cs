// <copyright file="SiniestrosDetDataResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Responses.Siniestros
{
    /// <summary>
    /// Representa el detalle completo de un siniestro y su información asociada.
    /// </summary>
    /// <remarks>
    /// Esta clase corresponde a la respuesta del servicio de datos de siniestros.
    /// Contiene información del vehículo, asegurado, liquidador, denunciante y otros datos relevantes.
    /// </remarks>
    public class SiniestrosDetDataResponse
    {
        /// <summary>Número del siniestro.</summary>
        public int NSINIE { get; set; }

        /// <summary>Patente del vehículo involucrado.</summary>
        public string? NPATEN { get; set; }

        /// <summary>Código interno del vehículo.</summary>
        public string? CODVEH { get; set; }

        /// <summary>Tipo de vehículo (por ejemplo, Automóvil, Camión, etc.).</summary>
        public string? TIPVEH { get; set; }

        /// <summary>Código de la marca del vehículo.</summary>
        public string? CMARCA { get; set; }

        /// <summary>Descripción de la marca.</summary>
        public string? DESMAR { get; set; }

        /// <summary>Código del modelo.</summary>
        public string? CMODEL { get; set; }

        /// <summary>Descripción del modelo.</summary>
        public string? DESMOL { get; set; }

        /// <summary>Código de versión del modelo.</summary>
        public string? CODVER { get; set; }

        /// <summary>Descripción de la versión (puede ser nula).</summary>
        public string? DESVER { get; set; }

        /// <summary>Año de fabricación del vehículo.</summary>
        public int FANOFA { get; set; }

        /// <summary>Fecha del siniestro (formato AAAAMMDD).</summary>
        public string? FECSIN { get; set; }

        /// <summary>Fecha del aviso del siniestro.</summary>
        public string? FECAVI { get; set; }

        /// <summary>Fecha en que el siniestro fue ingresado al sistema.</summary>
        public string? FechaIngresoSistema { get; set; }

        /// <summary>Estado actual del siniestro.</summary>
        public string? EstadoSiniestro { get; set; }

        /// <summary>Código de compañía o área 1.</summary>
        public string? CCOAF1 { get; set; }

        /// <summary>Código de compañía o área 2.</summary>
        public string? CCOAF2 { get; set; }

        /// <summary>Código de compañía o área 3.</summary>
        public string? CCOAF3 { get; set; }

        /// <summary>RUT del liquidador.</summary>
        public int NRUTLIQ { get; set; }

        /// <summary>Dígito verificador del liquidador.</summary>
        public string? DRUTLIQ { get; set; }

        /// <summary>Nombre del liquidador.</summary>
        public string? NOMBLIQ { get; set; }

        /// <summary>Teléfono del liquidador.</summary>
        public long FONOLIQ { get; set; }

        /// <summary>Celular del liquidador (puede venir vacío).</summary>
        public string? CELULIQ { get; set; }

        /// <summary>Correo electrónico del liquidador.</summary>
        public string? EMAILIQ { get; set; }

        /// <summary>RUT del abogado asociado.</summary>
        public int NrutAbo { get; set; }

        /// <summary>Dígito verificador del abogado.</summary>
        public string? DrutAbo { get; set; }

        /// <summary>Nombre del abogado asociado.</summary>
        public string? NombrAbo { get; set; }

        /// <summary>Correo del abogado asociado.</summary>
        public string? EmailAbo { get; set; }

        /// <summary>Tipo de participante (por ejemplo, Propietario, Proponente, etc.).</summary>
        public string? CTPR01 { get; set; }

        /// <summary>Descripción del cliente asociado al siniestro.</summary>
        public string? CLIENTE { get; set; }

        /// <summary>Valor del deducible aplicado.</summary>
        public decimal VTDEDU { get; set; }

        /// <summary>Código del grado de daño.</summary>
        public string? CGRADO { get; set; }

        /// <summary>Descripción del grado de daño.</summary>
        public string? DESGRA { get; set; }

        /// <summary>Código de colisión.</summary>
        public string? CCOLISI { get; set; }

        /// <summary>Descripción de la colisión.</summary>
        public string? COLISION { get; set; }

        /// <summary>Código de robo, si aplica.</summary>
        public string? CROBO { get; set; }

        /// <summary>Indicador de aparición de alguna variable relevante.</summary>
        public string? IAPARICI { get; set; }

        /// <summary>Cantidad de terceros involucrados.</summary>
        public int CANTERCE { get; set; }

        /// <summary>Descripción del accidente según la denuncia.</summary>
        public string? XDEACC { get; set; }

        /// <summary>Nombre del denunciante.</summary>
        public string? NOMBRDEN { get; set; }

        /// <summary>Correo electrónico del denunciante.</summary>
        public string? EMAILDEN { get; set; }

        /// <summary>Primer teléfono del denunciante.</summary>
        public string? FONO1DEN { get; set; }

        /// <summary>Segundo teléfono del denunciante.</summary>
        public string? FONO2DEN { get; set; }

        /// <summary>Nombre del asegurado.</summary>
        public string? NOMBRASE { get; set; }

        /// <summary>Correo electrónico del asegurado.</summary>
        public string? EMAILASE { get; set; }

        /// <summary>Teléfono 1 del asegurado.</summary>
        public string? FONO1ASE { get; set; }

        /// <summary>Teléfono 2 del asegurado.</summary>
        public string? FONO2ASE { get; set; }

        /// <summary>Indicador de comunicación con el asegurado.</summary>
        public string? IndComunicAse { get; set; }

        /// <summary>Código de sucursal.</summary>
        public string? CSUCUR { get; set; }

        /// <summary>Código del ramo del seguro.</summary>
        public string? CRAMO { get; set; }

        /// <summary>Tipo de documento asociado.</summary>
        public string? CTPDOC { get; set; }

        /// <summary>Número del documento asociado.</summary>
        public int NDOCTO { get; set; }

        /// <summary>Número del ítem asociado.</summary>
        public int NITEM { get; set; }

        /// <summary>Número de riesgo asociado.</summary>
        public int NRIESG { get; set; }

        /// <summary>Número de chasis del vehículo.</summary>
        public string? CHASIS { get; set; }

        /// <summary>Número de motor del vehículo.</summary>
        public string? NMOTOR { get; set; }

        /// <summary>Color del vehículo.</summary>
        public string? XCOLOR { get; set; }

        /// <summary>Número de puertas del vehículo.</summary>
        public string? NPUERTAS { get; set; }

        /// <summary>RUT del conductor al momento del siniestro.</summary>
        public int RUTCONDUCTO { get; set; }

        /// <summary>Dígito verificador del conductor.</summary>
        public string? DIGCONDUCTO { get; set; }

        /// <summary>Nombre completo del conductor.</summary>
        public string? NOMBRCONDUC { get; set; }

        /// <summary>Correo del conductor.</summary>
        public string? EMAILCONDUC { get; set; }

        /// <summary>Teléfono principal del conductor.</summary>
        public string? FONOCONDUC1 { get; set; }

        /// <summary>Teléfono secundario del conductor.</summary>
        public string? FONOCONDUC2 { get; set; }

        /// <summary>Descripción de la etapa actual del siniestro (por ejemplo, Liquidado).</summary>
        public string? DesEtapa { get; set; }

        /// <summary>Moneda de la póliza.</summary>
        public string? MonedaPol { get; set; }

        /// <summary>Porcentaje de pérdida estimada.</summary>
        public decimal PerdEstim { get; set; }

        /// <summary>Porcentaje de pérdida total.</summary>
        public decimal PerdTotal { get; set; }

        /// <summary>Nombre del taller asignado.</summary>
        public string? NombreTaller { get; set; }

        /// <summary>Dirección del taller asignado.</summary>
        public string? DireccTaller { get; set; }

        /// <summary>Fecha estimada de entrega del vehículo.</summary>
        public string? FechaEntrega { get; set; }

        /// <summary>Código del estado interno del siniestro.</summary>
        public string? CodigoEstado { get; set; }

        /// <summary>Fecha de asignación del siniestro.</summary>
        public string? FechaAsignacion { get; set; }

        /// <summary>Dirección donde ocurrió el siniestro.</summary>
        public string? DireccionSin { get; set; }

        /// <summary>Código del evento asociado al siniestro.</summary>
        public string? CodigoEvento { get; set; }

        /// <summary>Descripción del evento.</summary>
        public string? DescriEvento { get; set; }

        /// <summary>Comisaría donde se registró el parte, si aplica.</summary>
        public string? Comisaria { get; set; }

        /// <summary>Fecha de la constatación en comisaría.</summary>
        public string? FechaConst { get; set; }

        /// <summary>Número de folio del parte policial.</summary>
        public int FolioConst { get; set; }

        /// <summary>Número de párrafo del parte policial.</summary>
        public int ParrafoConst { get; set; }

        /// <summary>Indicador de fallecidos (N o S).</summary>
        public string? IndFallecido { get; set; }

        /// <summary>Descripción de la dinámica del siniestro.</summary>
        public string? DinamicaSin { get; set; }

        /// <summary>Campo de alerta interna o de riesgo.</summary>
        public string? CampoAlerta { get; set; }

        /// <summary>RUT del denunciante.</summary>
        public int RutDenunciante { get; set; }

        /// <summary>Dígito verificador del denunciante.</summary>
        public string? DvDenunciante { get; set; }
    }
}