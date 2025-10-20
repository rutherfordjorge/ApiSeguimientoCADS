// <copyright file="CadsService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Models.Settings;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using ApiSeguimientoCADS.Api.Services.Models;
    using Microsoft.Extensions.Options;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Servicio para interactuar con el sistema CADS
    /// </summary>
    public class CadsService : ICadsService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly CadsSettings _settings;
        private readonly IAppLogger<CadsService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CadsService"/> class.
        /// </summary>
        /// <param name="httpClientService">Servicio HTTP para consumir APIs externas</param>
        /// <param name="settings">Configuración del servicio CADS</param>
        /// <param name="logger">Logger de la aplicación</param>
        public CadsService(
            IHttpClientService httpClientService,
            IOptions<CadsSettings> settings,
            IAppLogger<CadsService> logger)
        {
            this._httpClientService = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));
            this._settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task<bool> ValidarUsuarioAsync(string rutTitular, string sessionId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(rutTitular);
            ArgumentException.ThrowIfNullOrWhiteSpace(sessionId);

            var logInput = new
            {
                RutTitular = rutTitular,
                SessionId = sessionId,
            };

            this._logger.Info($"Validando usuario en CADS - RUT: {rutTitular}");
            var (processId, stopwatch) = this._logger.StartProcess(logInput);

            try
            {
                var apiRequest = new ApiRequest
                {
                    Url = new Uri(this._settings.Full),
                    Method = HttpMethod.Post,
                    Body = new
                    {
                        rutTitular,
                        sessionId,
                    },
                };

                apiRequest.Headers["Content-Type"] = "application/json";
                apiRequest.Headers["Authorization"] = this._settings.AuthToken;

                this._logger.Debug($"Enviando request a CADS: {this._settings.Full}");

                var response = await this._httpClientService.SendAsync<object>(apiRequest).ConfigureAwait(false);

                this._logger.EndProcess(processId, stopwatch);

                if (response.IsSuccess)
                {
                    this._logger.Info("Usuario validado exitosamente en CADS");
                    return true;
                }

                this._logger.LogError($"Error al validar usuario en CADS. StatusCode: {response.StatusCode}");
                return false;
            }
            catch (HttpRequestException ex)
            {
                this._logger.LogError(ex);
                this._logger.LogError($"Error de red al validar usuario en CADS: {ex.Message}");
                this._logger.EndProcess(processId, stopwatch);
                return false;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex);
                this._logger.EndProcess(processId, stopwatch);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<object?> ObtenerInformacionUsuarioAsync(string rutTitular)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(rutTitular);

            var logInput = new { RutTitular = rutTitular };

            this._logger.Info($"Obteniendo información de usuario en CADS - RUT: {rutTitular}");
            var (processId, stopwatch) = this._logger.StartProcess(logInput);

            try
            {
                var apiRequest = new ApiRequest
                {
                    Url = new Uri($"{this._settings.Base}/usuarios/{rutTitular}"),
                    Method = HttpMethod.Get,
                };

                apiRequest.Headers["Authorization"] = this._settings.AuthToken;

                this._logger.Debug($"Enviando request a CADS para obtener información de usuario");

                var response = await this._httpClientService.SendAsync<object>(apiRequest).ConfigureAwait(false);

                this._logger.EndProcess(processId, stopwatch);

                if (response.IsSuccess)
                {
                    this._logger.Info("Información de usuario obtenida exitosamente");
                    return response.Data;
                }

                this._logger.LogError($"Error al obtener información de usuario. StatusCode: {response.StatusCode}");
                return null;
            }
            catch (HttpRequestException ex)
            {
                this._logger.LogError(ex);
                this._logger.LogError($"Error de red al obtener información de usuario: {ex.Message}");
                this._logger.EndProcess(processId, stopwatch);
                return null;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex);
                this._logger.EndProcess(processId, stopwatch);
                throw;
            }
        }
    }
}