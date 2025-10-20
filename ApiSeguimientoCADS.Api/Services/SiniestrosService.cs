// <copyright file="SiniestrosService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Models.Responses;
    using ApiSeguimientoCADS.Api.Models.Settings;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using ApiSeguimientoCADS.Api.Services.Models;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// Servicio para consumir el API de siniestros de BCI
    /// </summary>
    public class SiniestrosService : ISiniestrosService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly SiniestrosApiSettings _settings;
        private readonly IAppLogger<SiniestrosService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SiniestrosService"/> class.
        /// </summary>
        /// <param name="httpClientService">Servicio HTTP para consumir APIs externas</param>
        /// <param name="settings">Configuración del API de siniestros</param>
        /// <param name="logger">Logger para registrar eventos</param>
        public SiniestrosService(
            IHttpClientService httpClientService,
            IOptions<SiniestrosApiSettings> settings,
            IAppLogger<SiniestrosService> logger)
        {
            this._httpClientService = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));
            this._settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task<DefaultResponse<List<SiniestroDto>>> ObtenerSiniestrosPorAseguradoAsync(int rutAsegurado)
        {
            var logInput = new { RutAsegurado = rutAsegurado };
            this._logger.Info($"Iniciando consulta de siniestros para RUT asegurado: {rutAsegurado}");
            var (processId, stopwatch) = this._logger.StartProcess(logInput);

            try
            {
                // Preparar el request
                this._logger.Debug($"Preparando request para URL: {this._settings.Full}");
                var apiRequest = new ApiRequest
                {
                    Url = new Uri(this._settings.Full),
                    Method = HttpMethod.Post,
                    Body = new { RUTASEGURADO = rutAsegurado },
                };

                // Agregar headers requeridos
                apiRequest.Headers["Content-Type"] = "application/json";
                apiRequest.Headers["Authorization"] = this._settings.AuthToken;
                apiRequest.Headers["Cookie"] = this._settings.Cookie;

                this._logger.Debug("Headers agregados. Enviando request al servicio externo...");

                // Realizar la llamada al servicio externo
                var response = await this._httpClientService.SendAsync<SiniestrosExternalResponse>(apiRequest).ConfigureAwait(false);

                // Validar respuesta
                if (!response.IsSuccess)
                {
                    this._logger.LogError($"Error al consultar siniestros. StatusCode: {response.StatusCode}");
                    this._logger.EndProcess(processId, stopwatch);
                    return new DefaultResponse<List<SiniestroDto>>(
                        success: false,
                        message: $"Error al consultar siniestros: {response.StatusCode}",
                        data: null,
                        errorCode: response.StatusCode.ToString());
                }

                if (response.Data == null)
                {
                    this._logger.LogError("La respuesta del servicio externo no contiene datos");
                    this._logger.EndProcess(processId, stopwatch);
                    return new DefaultResponse<List<SiniestroDto>>(
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
                    return new DefaultResponse<List<SiniestroDto>>(
                        success: false,
                        message: response.Data.Comentario ?? "Error en el servicio externo",
                        data: null,
                        errorCode: response.Data.Status);
                }

                var totalSiniestros = response.Data.Data?.Count ?? 0;
                this._logger.Info($"Siniestros obtenidos exitosamente. Total: {totalSiniestros}");

                var result = new DefaultResponse<List<SiniestroDto>>(
                    success: true,
                    message: response.Data.Comentario ?? "Siniestros obtenidos exitosamente",
                    data: response.Data.Data?.ToList() ?? new List<SiniestroDto>());

                this._logger.EndProcess(processId, stopwatch, new { TotalSiniestros = totalSiniestros });
                return result;
            }
            catch (HttpRequestException ex)
            {
                this._logger.LogError(ex);
                this._logger.LogError($"Error de red al consultar siniestros: {ex.Message}");
                this._logger.EndProcess(processId, stopwatch);

                return new DefaultResponse<List<SiniestroDto>>(
                    success: false,
                    message: "Error de comunicación con el servicio externo",
                    data: null,
                    errorCode: "NETWORK_ERROR");
            }
            catch (InvalidOperationException ex)
            {
                this._logger.LogError(ex);
                this._logger.LogError($"Error de operación al consultar siniestros: {ex.Message}");
                this._logger.EndProcess(processId, stopwatch);

                return new DefaultResponse<List<SiniestroDto>>(
                    success: false,
                    message: "Error al procesar la solicitud",
                    data: null,
                    errorCode: "OPERATION_ERROR");
            }
        }
    }
}