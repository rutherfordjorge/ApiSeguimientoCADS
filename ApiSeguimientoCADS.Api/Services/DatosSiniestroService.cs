// <copyright file="DatosSiniestroService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Models.Requests;
    using ApiSeguimientoCADS.Api.Models.Responses;
    using ApiSeguimientoCADS.Api.Models.Settings;
    using ApiSeguimientoCADS.Api.Security;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using ApiSeguimientoCADS.Api.Services.Models;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// Servicio para consumir el API de datos de siniestro de BCI
    /// </summary>
    public class DatosSiniestroService : IDatosSiniestroService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly DatosSiniestroApiSettings _settings;
        private readonly IAppLogger<DatosSiniestroService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatosSiniestroService"/> class.
        /// </summary>
        /// <param name="httpClientService">Servicio HTTP para consumir APIs externas</param>
        /// <param name="settings">Configuración del API de datos de siniestro</param>
        /// <param name="logger">Logger para registrar eventos</param>
        public DatosSiniestroService(
            IHttpClientService httpClientService,
            IOptions<DatosSiniestroApiSettings> settings,
            IAppLogger<DatosSiniestroService> logger)
        {
            this._httpClientService = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));
            this._settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task<DefaultResponse<List<DatosSiniestroDetalleDto>>> ObtenerDatosSiniestroAsync(DatosSiniestroRequest request)
        {
            var logInput = new
            {
                request.NumeroSiniestro,
                request.NumeroRiesgo,
                request.NumeroItem,
                request.CodigoSucursal,
                request.CodigoTipoDocumento,
                request.NumeroDocumento,
                request.Patente,
            };

            this._logger.Info($"Iniciando consulta de datos de siniestro. Número: {request.NumeroSiniestro}");
            var (processId, stopwatch) = this._logger.StartProcess(logInput);

            try
            {
                // Preparar el request body según el formato del API externo
                var requestBody = new
                {
                    i_Nsinie = request.NumeroSiniestro,
                    i_Nriesg = request.NumeroRiesgo,
                    i_Nitem = request.NumeroItem,
                    i_Csucur = request.CodigoSucursal,
                    i_Ctpdoc = request.CodigoTipoDocumento,
                    i_Ndocto = request.NumeroDocumento,
                    i_Patent = request.Patente ?? string.Empty,
                };

                this._logger.Debug($"Preparando request para URL: {this._settings.FullUrl}");

                // Preparar el request
                var apiRequest = new ApiRequest
                {
                    Url = new Uri(this._settings.FullUrl),
                    Method = HttpMethod.Post,
                    Body = requestBody,
                };

                // Agregar headers requeridos
                apiRequest.Headers["Content-Type"] = "application/json";
                apiRequest.Headers["Authorization"] = this._settings.AuthToken;
                apiRequest.Headers["Cookie"] = this._settings.Cookie;

                this._logger.Debug("Headers agregados. Enviando request al servicio externo...");

                // Realizar la llamada al servicio externo
                var response = await this._httpClientService.SendAsync<DatosSiniestroExternalResponse>(apiRequest);

                // Validar respuesta
                if (!response.IsSuccess)
                {
                    this._logger.LogError($"Error al consultar datos de siniestro. StatusCode: {response.StatusCode}");
                    this._logger.EndProcess(processId, stopwatch);
                    return new DefaultResponse<List<DatosSiniestroDetalleDto>>(
                        success: false,
                        message: $"Error al consultar datos de siniestro: {response.StatusCode}",
                        data: null,
                        errorCode: response.StatusCode.ToString());
                }

                if (response.Data == null)
                {
                    this._logger.LogError("La respuesta del servicio externo no contiene datos");
                    this._logger.EndProcess(processId, stopwatch);
                    return new DefaultResponse<List<DatosSiniestroDetalleDto>>(
                        success: false,
                        message: "No se recibieron datos del servicio externo",
                        data: null,
                        errorCode: "NO_DATA");
                }

                // Validar el status de la respuesta externa
                if (response.Data.Status != "200")
                {
                    this._logger.LogError($"El servicio externo retornó status: {response.Data.Status} - {response.Data.Comentario}");
                    this._logger.EndProcess(processId, stopwatch);
                    return new DefaultResponse<List<DatosSiniestroDetalleDto>>(
                        success: false,
                        message: response.Data.Comentario ?? "Error en el servicio externo",
                        data: null,
                        errorCode: response.Data.Status);
                }

                var totalRegistros = response.Data.Data?.Count ?? 0;
                this._logger.Info($"Datos de siniestro obtenidos exitosamente. Total registros: {totalRegistros}");

                var result = new DefaultResponse<List<DatosSiniestroDetalleDto>>(
                    success: true,
                    message: response.Data.Comentario ?? "Datos de siniestro obtenidos exitosamente",
                    data: response.Data.Data ?? new List<DatosSiniestroDetalleDto>());

                this._logger.EndProcess(processId, stopwatch, new { TotalRegistros = totalRegistros });
                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex);
                this._logger.LogError($"Excepción al consultar datos de siniestro: {ex.Message}");
                this._logger.EndProcess(processId, stopwatch);
                return new DefaultResponse<List<DatosSiniestroDetalleDto>>(
                    success: false,
                    message: "Error interno al consultar datos de siniestro",
                    data: null,
                    errorCode: "INTERNAL_ERROR");
            }
        }
    }
}
