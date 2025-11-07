// <copyright file="UsersHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Handlers
{
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Helpers;
    using ApiSeguimientoCADS.Api.Models.Enums;
    using ApiSeguimientoCADS.Api.Models.Requests;
    using ApiSeguimientoCADS.Api.Models.Requests.Cads;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// IUsersHandler
    /// </summary>
    public class UsersHandler : IUsersHandler
    {
        private readonly IAppLogger<UsersHandler> _logger;
        private readonly IConfiguration _configuration;
        private readonly ICadsService _cadsService;
        private readonly ITokenService _tokenService;

        /// <summary>
        /// UsersHandler - Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="configuration">configuration</param>
        /// <param name="cadsService">cadsService</param>
        /// <param name="tokenService">tokenService</param>
        public UsersHandler(
            IAppLogger<UsersHandler> logger,
            IConfiguration configuration,
            ICadsService cadsService,
            ITokenService tokenService)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this._cadsService = cadsService ?? throw new ArgumentNullException(nameof(cadsService));
            this._tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        /// <summary>
        /// Genera URL del frontend con los parámetros de redirección.
        /// </summary>
        /// <param name="request">Datos de la solicitud.</param>
        /// <returns>URL completa para redirección.</returns>
        public async Task<string> GenerarUrlFrontend(ValidateAccessRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            TokenData tokenData;
            string token;

            this._logger.Info("Iniciando validaciones de request");

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(request.RutTitular))
            {
                this._logger.LogError("Validación fallida: RUT del titular es nulo o vacío");
                throw new ArgumentException("El RUT del titular es obligatorio.", nameof(request));
            }

            if (request.Origen == EOrigen.None)
            {
                this._logger.LogError($"Validación fallida: Origen inválido ({request.Origen})");
                throw new ArgumentException("El origen es obligatorio.", nameof(request));
            }

            if (request.Rol == ERol.None)
            {
                this._logger.LogError($"Validación fallida: Rol inválido ({request.Rol})");
                throw new ArgumentException("El rol es obligatorio.", nameof(request));
            }

            var userAccessResponse = await this._cadsService.ValideUserAccess(request).ConfigureAwait(false);

            if (userAccessResponse?.Data?.IdUsuario is null)
            {
                return await RedirectToOrigin(request.RutaOrigen).ConfigureAwait(false);
            }

            // Obtener URL base desde configuración
            var urlBase = this._configuration["Frontend:BaseUrl"]
                ?? throw new InvalidOperationException("Frontend:BaseUrl no está configurado en appsettings");
            this._logger.Debug($"URL base obtenida de configuración: {urlBase}");

            // Validar datos del usuario
            if (userAccessResponse?.Data == null)
            {
                throw new InvalidOperationException("No se pudieron obtener los datos del usuario.");
            }

            // Generar SessionId único
            var sessionId = Guid.NewGuid().ToString("N");
            this._logger.Debug($"SessionId generado: {sessionId}");

            // Generar Token
            tokenData = new TokenData
            {
                Origen = (int)request.Origen,
                Rol = (int)request.Rol,
                SessionId = sessionId,
                Solicitante = request.RutSolicitante ?? string.Empty,
                Nombres = userAccessResponse.Data.Nombre ?? string.Empty,
                Apellidos = userAccessResponse.Data.Apellido ?? string.Empty,
                Email = userAccessResponse.Data.Email ?? string.Empty,
                TokenOrigen = request.Token ?? string.Empty,
            };

            token = this._tokenService.GenerateToken(tokenData);
            this._logger.Debug("Token generado exitosamente");

            // Construir URL
            var sb = new StringBuilder(urlBase);
            char sep = urlBase.Contains('?', StringComparison.Ordinal) ? '&' : '?';

            void AppendParam(string key, string? value)
            {
                sb.Append(sep);
                sb.Append(key);
                sb.Append('=');
                sb.Append(Uri.EscapeDataString(value ?? "-"));
                sep = '&';
            }

            AppendParam("titular", request.RutTitular);
            AppendParam("origen", ((int)request.Origen).ToString(CultureInfo.InvariantCulture));
            AppendParam("corredor", request.RutCorredor);
            AppendParam("rol", ((int)request.Rol).ToString(CultureInfo.InvariantCulture));
            AppendParam("urlOrigen", Helper.NormalizarRuta(request.RutaOrigen));
            AppendParam("urlDestino", "onboarding"); // se envia este valor mientras se desarrolla logica de si entra por primera vez
            AppendParam("sessionId", sessionId);
            AppendParam("idUsuario", userAccessResponse?.Data?.IdUsuario.ToString(CultureInfo.InvariantCulture));
            AppendParam("token", token);
            var urlFinal = sb.ToString();

            this._logger.Info($"URL generada exitosamente. Longitud: {urlFinal.Length} caracteres");

            return await RedirectToOrigin(urlFinal).ConfigureAwait(false);
        }

        private static async Task<string> RedirectToOrigin(string urlOrigen)
        {
            ArgumentNullException.ThrowIfNull(urlOrigen);

            if (urlOrigen.Contains("http", StringComparison.Ordinal))
            {
                return urlOrigen;
            }

            try
            {
                // Intentar crear URI con validación
                if (!Uri.TryCreate("http://" + urlOrigen, UriKind.Absolute, out Uri? testUri))
                {
                    // Si no es válida, devolver con https por defecto
                    return "https://" + urlOrigen;
                }

                bool result = await Helper.UrlExistsAsync(testUri).ConfigureAwait(false);
                string prefix = result ? "http://" : "https://";
                return prefix + urlOrigen;
            }
            catch (HttpRequestException)
            {
                // Error de conexión HTTP, devolver con https
                return "https://" + urlOrigen;
            }
            catch (TaskCanceledException)
            {
                // Timeout, devolver con https
                return "https://" + urlOrigen;
            }
            catch (InvalidOperationException)
            {
                // Error en operación, devolver con https
                return "https://" + urlOrigen;
            }
        }
    }
}