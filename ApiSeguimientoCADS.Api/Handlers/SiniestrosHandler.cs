// <copyright file="SiniestrosHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Handlers
{
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Models.DTOs.Siniestros;
    using ApiSeguimientoCADS.Api.Models.Requests.Siniestros;
    using ApiSeguimientoCADS.Api.Models.Responses.Siniestros;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using ApiSeguimientoCADS.Api.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// SiniestrosHandler
    /// </summary>
    public class SiniestrosHandler : ISiniestrosHandler
    {
        private readonly IAppLogger<SiniestrosHandler> _logger;
        private readonly ISiniestrosService _siniestrosService;
        private readonly IResiliencePolicyService _resiliencePolicyService;

        /// <summary>
        /// SiniestrosHandler - Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="siniestrosService">siniestrosService</param>
        /// <param name="resiliencePolicyService">resiliencePolicyService</param>
        public SiniestrosHandler(
            IAppLogger<SiniestrosHandler> logger,
            ISiniestrosService siniestrosService,
            IResiliencePolicyService resiliencePolicyService)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._siniestrosService = siniestrosService ?? throw new ArgumentNullException(nameof(siniestrosService));
            this._resiliencePolicyService = resiliencePolicyService ?? throw new ArgumentNullException(nameof(resiliencePolicyService));
        }

        /// <summary>
        /// Obtiene la lista de siniestros asociados a un asegurado.
        /// </summary>
        /// <param name="request">Datos de la solicitud con el RUT del asegurado.</param>
        /// <returns>Respuesta con la lista de siniestros del asegurado.</returns>
        public async Task<SiniestrosResponse> GetSiniestrosPorAsegurado(SiniestrosRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            this._logger.Info($"{this.GetType().FullName} - Iniciando validaciones de request");

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(request.RutAsegurado))
            {
                this._logger.LogError("Validación fallida: RUT del asegurado es nulo o vacío");
                throw new ArgumentException("El RUT del titular es obligatorio.", nameof(request));
            }

            var siniestrosResponse = await this._siniestrosService.GetSiniestrosPorAsegurado(request).ConfigureAwait(false);

            if (siniestrosResponse == null)
            {
                throw new InvalidOperationException("El servicio no devolvió información de siniestros.");
            }

            return siniestrosResponse;
        }

        /// <summary>
        /// Obtiene el detalle de un siniestro
        /// </summary>
        /// <param name="request">Datos de la solicitud.</param>
        /// <returns>Detalle completo de un siniestro.</returns>
        public async Task<SiniestrosDetalleResponse> GetDetalleSiniestros(SiniestrosDetRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            this._logger.Info($"{this.GetType().FullName} - Iniciando validaciones de request");

            // Validaciones básicas
            if (request.INsinie <= 0)
            {
                this._logger.LogError("Validación fallida: El número de siniestro no puede ser menor o igual a cero.");
                throw new ArgumentException("El número de siniestro es obligatorio y debe ser mayor a cero.");
            }

            if (request.INdocto <= 0)
            {
                this._logger.LogError("Validación fallida: El número de documento no puede ser menor o igual a cero.");
                throw new ArgumentException("El número de documento es obligatorio y debe ser mayor a cero.");
            }

            var siniestrosDetalleDataResponse = await this._siniestrosService.GetDatosDelSiniestro(request).ConfigureAwait(false);

            return siniestrosDetalleDataResponse;
        }

        /// <summary>
        /// Obtiene el detalle completo de siniestros por asegurado aplicando todas las reglas de negocio.
        /// </summary>
        /// <param name="rut">RUT del asegurado.</param>
        /// <returns>Detalle completo de siniestros procesados.</returns>
        public async Task<SiniestrosDataDto> GetSiniestrosDetallePorAsegurado(string rut)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(rut);

            this._logger.Info($"{this.GetType().FullName} - Iniciando proceso de obtención de siniestros para RUT: {rut}");

            // Validar formato del RUT
            if (!RutValidator.Validar(rut))
            {
                this._logger.LogError($"Validación fallida: RUT inválido recibido: {rut}");
                throw new ArgumentException("El RUT proporcionado no es válido.", nameof(rut));
            }

            // Limpiar RUT para consulta
            string rutLimpio = RutValidator.ObtenerNumeroRut(rut);
            var request = new SiniestrosRequest { RutAsegurado = rutLimpio };

            // Obtener siniestros del servicio externo
            this._logger.Debug($"{this.GetType().FullName} - Consultando siniestros para RUT limpio: {rutLimpio}");
            var lstSiniestrosResponse = await this.GetSiniestrosPorAsegurado(request).ConfigureAwait(false);

            // Validar que existan datos
            if (lstSiniestrosResponse.Data == null || lstSiniestrosResponse.Data.Count == 0)
            {
                this._logger.Info($"{this.GetType().FullName} - No se encontraron siniestros para el RUT: {rut}");
                return new SiniestrosDataDto();
            }

            // Procesar siniestros VP únicos (combina filtrado y procesamiento en un solo paso)
            var lstSiniestrosDataResponse = this.ProcesarSiniestrosVP(lstSiniestrosResponse.Data);

            if (lstSiniestrosDataResponse.Count == 0)
            {
                this._logger.Info($"{this.GetType().FullName} - No se pudieron procesar siniestros VP para RUT: {rut}");
                return new SiniestrosDataDto();
            }

            // Enriquecer con detalles y transformar a DTO
            var siniestrosDataDTO = await this.EnriquecerConDetalles(lstSiniestrosDataResponse).ConfigureAwait(false);

            // Agregar tipos de siniestros si hay datos
            if (siniestrosDataDTO.Siniestros.Count > 0)
            {
                siniestrosDataDTO.TiposSiniestros.Add(new TipoSiniestroDto
                {
                    Nombre = "Vehículo",
                    Visible = true,
                });
            }

            this._logger.Info($"{this.GetType().FullName} - Proceso completado exitosamente. Total siniestros: {siniestrosDataDTO.Siniestros.Count}");

            return siniestrosDataDTO;
        }

        /// <summary>
        /// Procesa y filtra siniestros VP, creando requests únicos para consulta de detalles.
        /// </summary>
        /// <param name="siniestros">Lista de siniestros a procesar.</param>
        /// <returns>Lista de requests únicos con sus datos originales.</returns>
        private List<(SiniestrosDetRequest Request, SiniestrosDataResponse OriginalData)> ProcesarSiniestrosVP(
            IReadOnlyCollection<SiniestrosDataResponse> siniestros)
        {
            var resultado = new List<(SiniestrosDetRequest Request, SiniestrosDataResponse OriginalData)>();

            // Filtrar siniestros VP con datos válidos
            var siniestrosVP = siniestros
                .Where(p => p.Ramo == "VP" && p.NumeroSiniestro.HasValue && !string.IsNullOrWhiteSpace(p.NumeroPoliza))
                .ToList();

            foreach (var s in siniestrosVP)
            {
                // Extraer solo dígitos del número de póliza
                var numeroPolizaStr = new string(s.NumeroPoliza!.Where(char.IsDigit).ToArray());

                // Validar que se pueda parsear a entero
                if (!int.TryParse(numeroPolizaStr, CultureInfo.InvariantCulture, out int numeroDocto))
                {
                    this._logger.Debug($"No se pudo parsear NumeroPoliza: {s.NumeroPoliza}. Se omitirá este registro.");
                    continue;
                }

                var detRequest = new SiniestrosDetRequest
                {
                    INsinie = s.NumeroSiniestro!.Value,
                    INdocto = numeroDocto,
                };

                resultado.Add((detRequest, s));
            }

            // Eliminar duplicados basándose en INsinie e INdocto
            return resultado
                .DistinctBy(x => new { x.Request.INsinie, x.Request.INdocto })
                .ToList();
        }

        /// <summary>
        /// Enriquece los siniestros con sus detalles y los transforma a DTO.
        /// </summary>
        /// <param name="siniestrosConRequest">Lista de requests con datos originales.</param>
        /// <returns>DTO con siniestros enriquecidos.</returns>
        private async Task<SiniestrosDataDto> EnriquecerConDetalles(
            List<(SiniestrosDetRequest Request, SiniestrosDataResponse OriginalData)> siniestrosConRequest)
        {
            var siniestrosDataDTO = new SiniestrosDataDto();

            // Paralelizar llamadas a GetDetalleSiniestros con Bulkhead (máx 5 concurrentes, 10 en cola)
            var tasks = siniestrosConRequest.Select(async item =>
            {
                try
                {
                    // Ejecutar con Bulkhead para limitar concurrencia y proteger servicio externo
                    var siniestrosDetResponse = await this._resiliencePolicyService.BulkheadPipeline.ExecuteAsync(
                        async _ => await this.GetDetalleSiniestros(item.Request).ConfigureAwait(false),
                        CancellationToken.None).ConfigureAwait(false);

                    if (siniestrosDetResponse.Data == null)
                    {
                        this._logger.Debug($"No se encontraron detalles para siniestro {item.Request.INsinie}");
                        return null;
                    }

                    // Transformar cada detalle a SiniestroDto
                    var dtos = new List<SiniestroDto>();
                    foreach (var detalle in siniestrosDetResponse.Data)
                    {
                        dtos.Add(new SiniestroDto
                        {
                            NumSiniestro = item.OriginalData.NumeroSiniestro?.ToString(CultureInfo.InvariantCulture) ?? string.Empty,
                            TipoSinistros = "auto",
                            GlosaSiniestro = $"Patente: {detalle.Patente}",
                            FechaDenuncio = item.OriginalData.FechaDenuncia ?? string.Empty,
                            EstadoSinistro = item.OriginalData.Estado ?? string.Empty,
                            EstadoDenuncio = item.OriginalData.CodigoEstado ?? string.Empty,
                            AccionesPendientes = false,
                        });
                    }

                    return dtos;
                }
                catch (ArgumentException ex)
                {
                    this._logger.LogError(ex, $"Error de validación al obtener detalle del siniestro {item.Request.INsinie}");
                    return null;
                }
                catch (InvalidOperationException ex)
                {
                    this._logger.LogError(ex, $"Error al obtener detalle del siniestro {item.Request.INsinie}");
                    return null;
                }
            });

            // Esperar todas las tareas en paralelo
            var results = await Task.WhenAll(tasks).ConfigureAwait(false);

            // Agregar todos los resultados exitosos a la lista final
            foreach (var dto in results.Where(r => r != null).SelectMany(r => r!))
            {
                siniestrosDataDTO.Siniestros.Add(dto);
            }

            return siniestrosDataDTO;
        }
    }
}