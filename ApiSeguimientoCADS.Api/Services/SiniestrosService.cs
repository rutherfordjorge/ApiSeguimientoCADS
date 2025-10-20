// <copyright file="SiniestrosService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Models.Responses;
    using ApiSeguimientoCADS.Api.Models.Settings;
    using ApiSeguimientoCADS.Api.Security;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using ApiSeguimientoCADS.Api.Services.Models;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// Servicio para consumir el API de siniestros de BCI
    /// </summary>
    public class SiniestrosService : ISiniestrosService
    {
        private readonly IHttpClientService httpClientService;
        private readonly SiniestrosApiSettings settings;
        private readonly IAppLogger<SiniestrosService> logger;

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
            this.httpClientService = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));
            this.settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task<DefaultResponse<List<SiniestroDto>>> ObtenerSiniestrosPorAseguradoAsync(int rutAsegurado)
        {
            try
            {
                this.logger.LogInfo($"Consultando siniestros para RUT asegurado: {rutAsegurado}");

                // Preparar el request
                var apiRequest = new ApiRequest
                {
                    Url = new Uri(this.settings.FullUrl),
                    Method = HttpMethod.Post,
                    Body = new { RUTASEGURADO = rutAsegurado },
                };

                // Agregar headers requeridos
                apiRequest.Headers["Content-Type"] = "application/json";
                apiRequest.Headers["Authorization"] = this.settings.AuthToken;
                apiRequest.Headers["Cookie"] = this.settings.Cookie;

                // Realizar la llamada al servicio externo
                var response = await this.httpClientService.SendAsync<SiniestrosExternalResponse>(apiRequest);

                // Validar respuesta
                if (!response.IsSuccess)
                {
                    this.logger.LogError($"Error al consultar siniestros. StatusCode: {response.StatusCode}");
                    return new DefaultResponse<List<SiniestroDto>>(
                        success: false,
                        message: $"Error al consultar siniestros: {response.StatusCode}",
                        data: null,
                        errorCode: response.StatusCode.ToString());
                }

                if (response.Data == null)
                {
                    this.logger.LogWarning("La respuesta del servicio externo no contiene datos");
                    return new DefaultResponse<List<SiniestroDto>>(
                        success: false,
                        message: "No se recibieron datos del servicio externo",
                        data: null,
                        errorCode: "NO_DATA");
                }

                // Validar el status de la respuesta externa
                if (response.Data.Status != "200")
                {
                    this.logger.LogWarning($"El servicio externo retornó status: {response.Data.Status}");
                    return new DefaultResponse<List<SiniestroDto>>(
                        success: false,
                        message: response.Data.Comentario ?? "Error en el servicio externo",
                        data: null,
                        errorCode: response.Data.Status);
                }

                this.logger.LogInfo($"Siniestros obtenidos exitosamente. Total: {response.Data.Data?.Count ?? 0}");

                // Retornar respuesta exitosa en formato DefaultResponse
                return new DefaultResponse<List<SiniestroDto>>(
                    success: true,
                    message: response.Data.Comentario ?? "Siniestros obtenidos exitosamente",
                    data: response.Data.Data ?? new List<SiniestroDto>());
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Excepción al consultar siniestros: {ex.Message}", ex);
                return new DefaultResponse<List<SiniestroDto>>(
                    success: false,
                    message: "Error interno al consultar siniestros",
                    data: null,
                    errorCode: "INTERNAL_ERROR");
            }
        }
    }
}
