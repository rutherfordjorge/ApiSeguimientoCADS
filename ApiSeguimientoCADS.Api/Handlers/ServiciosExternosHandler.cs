// <copyright file="ServiciosExternosHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Handlers
{
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Helpers;
    using ApiSeguimientoCADS.Api.Models.Enums;
    using ApiSeguimientoCADS.Api.Models.Requests;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// ServiciosExternosHandler
    /// </summary>
    public class ServiciosExternosHandler : IServiciosExternosHandler
    {
        private readonly IAppLogger<ServiciosExternosHandler> _logger;
        private readonly IConfiguration _configuration;

        private static string GenerarTokenSimple(string rutTitular, string sessionId)
        {
            var data = $"{rutTitular}|{sessionId}|{DateTime.UtcNow:yyyyMMddHHmmss}";
            var hash = System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(data));
            return Convert.ToBase64String(hash);
        }

        private static string NormalizarRuta(string? ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta))
            {
                return "-";
            }

            return ruta.Replace("/", "|", StringComparison.Ordinal);
        }

        /// <summary>
        /// ServiciosExternosHandler
        /// </summary>
        public ServiciosExternosHandler(IAppLogger<ServiciosExternosHandler> logger, IConfiguration configuration)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Genera URL del frontend con los parámetros de redirección.
        /// </summary>
        /// <param name="request">Datos de la solicitud.</param>
        /// <returns>URL completa para redirección.</returns>
        public async Task<string> GenerarUrlFrontend(ExternalRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var input = new
            {
                RutTitular = LogHelper.MaskRut(request.RutTitular ?? string.Empty),
                Origen = request.Origen.ToString() ?? "None",
                Rol = request.Rol.ToString() ?? "None",
            };

            var (processId, stopwatch) = this._logger.StartProcess(input);
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

            // Obtener URL base desde configuración
            var urlBase = this._configuration["Frontend:BaseUrl"]
                ?? "https://seguimientocads.desa.bciseguros.cl/redirect/";
            this._logger.Debug($"URL base obtenida de configuración: {urlBase}");

            // Generar SessionId único
            var sessionId = Guid.NewGuid().ToString("N");
            this._logger.Debug($"SessionId generado: {sessionId}");

            // Obtener texto del origen
            var origenTexto = request.Origen switch
            {
                EOrigen.Web => "SITIO PRIVADO",
                EOrigen.App => "APP",
                EOrigen.Ofv => "OFICINA VIRTUAL",
                _ => "DESCONOCIDO",
            };

            // Generar token simple (TODO: implementar JWT real)
            var token = GenerarTokenSimple(request.RutTitular!, sessionId);
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
            AppendParam("urlOrigen", NormalizarRuta(request.RutaOrigen));
            AppendParam("urlDestino", NormalizarRuta(request.RutaDestino));
            AppendParam("sessionId", sessionId);
            AppendParam("origenTexto", origenTexto);
            AppendParam("token", token);
            var urlFinal = sb.ToString();

            this._logger.Info($"URL generada exitosamente. Longitud: {urlFinal.Length} caracteres");

            var output = new
            {
                UrlLength = urlFinal.Length,
                SessionId = sessionId,
            };

            this._logger.EndProcess(processId, stopwatch, output);

            return await Task.FromResult(sb.ToString()).ConfigureAwait(false);
        }
    }
}