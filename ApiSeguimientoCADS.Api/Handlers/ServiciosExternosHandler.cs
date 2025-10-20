// <copyright file="ServiciosExternosHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Handlers
{
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Models.Enums;
    using ApiSeguimientoCADS.Api.Models.Requests;
    using System.Globalization;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// ServiciosExternosHandler
    /// </summary>
    public class ServiciosExternosHandler : IServiciosExternosHandler
    {
        private readonly ILogger<ServiciosExternosHandler> _logger;
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
        public ServiciosExternosHandler(ILogger<ServiciosExternosHandler> logger, IConfiguration configuration)
        {
            this._logger = logger;
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

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(request.RutTitular))
            {
                throw new ArgumentException("El RUT del titular es obligatorio.", nameof(request));
            }

            if (request.Origen == EOrigen.None)
            {
                throw new ArgumentException("El origen es obligatorio.", nameof(request));
            }

            if (request.Rol == ERol.None)
            {
                throw new ArgumentException("El rol es obligatorio.", nameof(request));
            }

            // Obtener URL base desde configuración
            var urlBase = this._configuration["Frontend:BaseUrl"]
                ?? "https://seguimientocads.desa.bciseguros.cl/redirect/";

            // Generar SessionId único
            var sessionId = Guid.NewGuid().ToString("N");

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

            return await Task.FromResult(sb.ToString()).ConfigureAwait(false);
        }
    }
}