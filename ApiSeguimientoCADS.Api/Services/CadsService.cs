// <copyright file="CadsService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Models.Requests.Cads;
    using ApiSeguimientoCADS.Api.Models.Responses.Cads;
    using ApiSeguimientoCADS.Api.Models.Settings.ExternalApis;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using Microsoft.Extensions.Options;
    using System.Globalization;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web;

    /// <summary>
    /// CadsService
    /// </summary>
    public class CadsService(
        IOptions<CadsSettings> settings,
        IHttpService httpService) : ICadsService
    {
        private readonly CadsSettings _cadssettings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
        private readonly IHttpService _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));

        /// <summary>
        /// ValideUserAccess
        /// </summary>
        /// <param name="request">ExternalRequest</param>
        /// <returns>UserAccessResponse si el acceso es válido, null si no está autorizado</returns>
        /// <exception cref="InvalidOperationException">Cuando hay errores de configuración o el servicio no responde</exception>
        public async Task<UserAccessResponse?> ValideUserAccess(ValidateAccessRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            try
            {
                // Construir URL de forma segura con UriBuilder
                var url = this.BuildValidateAccessUrl(request);

                // Ejecutar con Circuit Breaker para proteger servicio crítico de autenticación
                var result = await this._httpService.GetWithCircuitBreakerAsync<UserAccessResponse>(
                    url,
                    request.Token).ConfigureAwait(false);

                // Usuario no autorizado (caso esperado, no es error)
                if (result.StatusCode == HttpStatusCode.Unauthorized || result.StatusCode == HttpStatusCode.Forbidden)
                {
                    return null;
                }

                // Respuesta exitosa
                if (result.IsSuccess && result.Data != null)
                {
                    return result.Data;
                }

                // Otros casos de error
                if (!result.IsSuccess)
                {
                    throw new InvalidOperationException($"El servicio de validación de acceso respondió con estado: {result.StatusCode}. Mensaje: {result.ErrorMessage}");
                }

                return null;
            }
            catch (UriFormatException ex)
            {
                throw new InvalidOperationException("Error al construir la URL de validación de acceso", ex);
            }
            catch (InvalidOperationException)
            {
                // Re-lanzar InvalidOperationException sin modificar
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error inesperado al validar acceso de usuario", ex);
            }
        }

        /// <summary>
        /// Construye la URL para validación de acceso usando UriBuilder con codificación segura
        /// </summary>
        /// <param name="request">Request con datos de validación</param>
        /// <returns>Uri válida</returns>
        private Uri BuildValidateAccessUrl(ValidateAccessRequest request)
        {
            // Validar basePath
            if (string.IsNullOrWhiteSpace(this._cadssettings.BasePath))
            {
                throw new InvalidOperationException("La configuración 'BasePath' de CADS no está configurada");
            }

            // Construir URL base con endpoint
            var baseUrl = $"{this._cadssettings.BasePath.TrimEnd('/')}/{this._cadssettings.Endpoints.ValidarSessionID?.TrimStart('/') ?? string.Empty}";

            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out var baseUri))
            {
                throw new InvalidOperationException($"No se pudo generar una URL base válida: {baseUrl}");
            }

            // Usar UriBuilder para agregar query parameters de forma segura
            var uriBuilder = new UriBuilder(baseUri);
            var query = HttpUtility.ParseQueryString(string.Empty);

            query["rut"] = request.RutTitular;
            query["sessionId"] = request.SessionId;
            query["token"] = request.Token;
            query["origen"] = ((int)request.Origen).ToString(CultureInfo.InvariantCulture);

            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }
    }
}