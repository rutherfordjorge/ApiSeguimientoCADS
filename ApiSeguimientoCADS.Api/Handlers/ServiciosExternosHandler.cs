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

        /// <summary>
        /// ServiciosExternosHandler
        /// </summary>
        public ServiciosExternosHandler(ILogger<ServiciosExternosHandler> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// GenerarUrlFrontend
        /// </summary>
        /// <returns>Url componente front</returns>
        public async Task<string> GenerarUrlFrontend(ExternalRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var sessionId = Guid.NewGuid().ToString();

            var origenTexto = request.Origen switch
            {
                EOrigen.Web => "SITIO PRIVADO",
                EOrigen.App => "APP",
                EOrigen.Ofv => "OFICINA VIRTUAL",
                _ => "Origen desconocido",
            };

            // 3) Generar Token

            // 4) Construcción de URL
            StringBuilder sb = new StringBuilder();
            sb.Append("Url Base a donde vamos a redirigir ej: \"https://seguimientocads.desa.bciseguros.cl/redirect/\"");

            char sep = '?';
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
            AppendParam("origen", ((int)request.Rol).ToString(CultureInfo.InvariantCulture));
            AppendParam("urlOrigen", string.IsNullOrEmpty(request.RutaOrigen) ? "-" : request.RutaOrigen.Replace("/", "|", StringComparison.Ordinal));
            AppendParam("urlDestino", string.IsNullOrEmpty(request.RutaDestino) ? "-" : request.RutaDestino.Replace("/", "|", StringComparison.Ordinal));
            AppendParam("sessionId", "sessionId");
            AppendParam("idUsuario", "Id_usuario");
            AppendParam("nombres", "nombre_usuario");
            AppendParam("apellidos", "apellido_usuario");
            AppendParam("email", "email_usuario");
            AppendParam("origenTexto", origenTexto);
            AppendParam("token", "token_nuestro");

            return await Task.FromResult("url").ConfigureAwait(false);
        }
    }
}