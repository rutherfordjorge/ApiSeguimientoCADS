// <copyright file="SiniestrosService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Models.Requests.Siniestros;
    using ApiSeguimientoCADS.Api.Models.Responses.Siniestros;
    using ApiSeguimientoCADS.Api.Models.Settings.ExternalApis;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using Microsoft.Extensions.Options;
    using System.Globalization;
    using System.Threading.Tasks;

    /// <summary>
    /// SiniestrosService - Servicio para gestionar operaciones relacionadas con siniestros
    /// </summary>
    public class SiniestrosService : ISiniestrosService
    {
        private readonly EPSiniestroPorAseguradoSettings _ePSiniestroPorAseguradoSettings;
        private readonly EPGetdatosdelsiniestroSettings _ePGetdatosdelsiniestro;
        private readonly IHttpService _httpService;
        private readonly IAppLogger<SiniestrosService> _logger;

        /// <summary>
        /// Constructor de SiniestrosService
        /// </summary>
        /// <param name="ePSiniestroPorAseguradoSettings">Configuración del endpoint de siniestros por asegurado</param>
        /// <param name="ePGetdatosdelsiniestro">Configuración del endpoint de detalle de siniestros</param>
        /// <param name="httpService">Servicio HTTP</param>
        /// <param name="logger">Logger de la aplicación</param>
        public SiniestrosService(
            IOptions<EPSiniestroPorAseguradoSettings> ePSiniestroPorAseguradoSettings,
            IOptions<EPGetdatosdelsiniestroSettings> ePGetdatosdelsiniestro,
            IHttpService httpService,
            IAppLogger<SiniestrosService> logger)
        {
            this._ePSiniestroPorAseguradoSettings = ePSiniestroPorAseguradoSettings?.Value ?? throw new ArgumentNullException(nameof(ePSiniestroPorAseguradoSettings));
            this._ePGetdatosdelsiniestro = ePGetdatosdelsiniestro?.Value ?? throw new ArgumentNullException(nameof(ePGetdatosdelsiniestro));
            this._httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// GetSiniestrosPorAsegurado
        /// </summary>
        /// <param name="request">SiniestrosRequest</param>
        /// <returns>SiniestrosResponse</returns>
        /// <exception cref="InvalidOperationException">Cuando hay errores de configuración o el servicio no responde</exception>
        public async Task<SiniestrosResponse> GetSiniestrosPorAsegurado(SiniestrosRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            ArgumentNullException.ThrowIfNull(request.RutAsegurado);

            var (processId, stopwatch) = this._logger.StartProcess(new
            {
                Operation = "GetSiniestrosPorAsegurado",
                RutAsegurado = request.RutAsegurado,
            });

            try
            {
                this._logger.Info($"Obteniendo siniestros para asegurado: {request.RutAsegurado}");

                var url = this.BuildAndValidateUri(this._ePSiniestroPorAseguradoSettings.BasePath, "siniestros por asegurado");
                var body = new { RUTASEGURADO = request.RutAsegurado };

                var headers = this.BuildAuthenticationHeaders(
                    this._ePSiniestroPorAseguradoSettings.Auth,
                    this._ePSiniestroPorAseguradoSettings.TokenCABName,
                    this._ePSiniestroPorAseguradoSettings.TokenCABValue,
                    this._ePSiniestroPorAseguradoSettings.CookieName,
                    this._ePSiniestroPorAseguradoSettings.CookieValue);

                var result = await this._httpService.PostWithHeadersAsync<object, SiniestrosResponse>(
                    url,
                    body,
                    bearerToken: null,
                    customHeaders: headers).ConfigureAwait(false);

                if (result == null)
                {
                    var errorMessage = "El servicio de siniestros no devolvió datos.";
                    this._logger.LogError(errorMessage);
                    throw new InvalidOperationException(errorMessage);
                }

                this._logger.EndProcess(processId, stopwatch, new { Success = true, DataReturned = true });
                this._logger.Info($"Siniestros obtenidos exitosamente para asegurado: {request.RutAsegurado}");

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error al obtener siniestros para asegurado: {request.RutAsegurado}");
                this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = ex.Message });
                throw;
            }
        }

        /// <summary>
        /// GetDetalleSiniestros
        /// </summary>
        /// <param name="request">SiniestrosDetRequest</param>
        /// <returns>SiniestrosDetalleResponse</returns>
        /// <exception cref="ArgumentException">Cuando los parámetros son inválidos</exception>
        /// <exception cref="InvalidOperationException">Cuando hay errores de configuración o el servicio no responde</exception>
        public async Task<SiniestrosDetalleResponse> GetDatosDelSiniestro(SiniestrosDetRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            if (request.INsinie <= 0)
            {
                throw new ArgumentException("El número de siniestro debe ser mayor a cero.", nameof(request));
            }

            if (request.INdocto <= 0)
            {
                throw new ArgumentException("El número de documento es obligatorio y debe ser mayor a cero.");
            }

            var (processId, stopwatch) = this._logger.StartProcess(new
            {
                Operation = "GetDatosDelSiniestro",
                NumeroSiniestro = request.INsinie,
                NumeroDocumento = request.INdocto,
            });

            try
            {
                this._logger.Info($"Obteniendo detalle del siniestro: {request.INsinie}");

                var url = this.BuildAndValidateUri(this._ePGetdatosdelsiniestro.BasePath, "detalle de siniestros");

                var headers = new Dictionary<string, string>
                {
                    ["Authorization"] = $"Basic {this._ePGetdatosdelsiniestro.Auth}",
                    ["nSiniestro"] = request.INsinie.ToString(CultureInfo.InvariantCulture),
                };

                var result = await this._httpService.GetWithHeadersAsync<SiniestrosDetalleResponse>(
                    url,
                    bearerToken: null,
                    customHeaders: headers).ConfigureAwait(false);

                if (result == null)
                {
                    var errorMessage = "El servicio de detalle de siniestros no devolvió datos.";
                    this._logger.LogError(errorMessage);
                    throw new InvalidOperationException(errorMessage);
                }

                this._logger.EndProcess(processId, stopwatch, new { Success = true, DataReturned = true });
                this._logger.Info($"Detalle del siniestro {request.INsinie} obtenido exitosamente");

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error al obtener detalle del siniestro: {request.INsinie}");
                this._logger.EndProcess(processId, stopwatch, new { Success = false, Error = ex.Message });
                throw;
            }
        }

        private Uri BuildAndValidateUri(string basePath, string serviceName)
        {
            this._logger.Debug($"Validando URI para servicio: {serviceName}");

            if (string.IsNullOrWhiteSpace(basePath))
            {
                throw new InvalidOperationException($"La ruta base está vacía o es nula para el servicio de {serviceName}");
            }

            if (!Uri.TryCreate(basePath, UriKind.Absolute, out Uri? validUri))
            {
                throw new InvalidOperationException($"URL base inválida en configuración para {serviceName}: {basePath}");
            }

            this._logger.Debug($"URI validada correctamente: {validUri}");
            return validUri;
        }

        private Dictionary<string, string> BuildAuthenticationHeaders(
            string auth,
            string tokenName,
            string tokenValue,
            string cookieName,
            string cookieValue)
        {
            this._logger.Debug($"Configurando headers de autenticación: Authorization, {tokenName}, {cookieName}");

            return new Dictionary<string, string>
            {
                ["Authorization"] = $"Basic {auth}",
                [tokenName] = tokenValue,
                [cookieName] = cookieValue,
            };
        }
    }
}