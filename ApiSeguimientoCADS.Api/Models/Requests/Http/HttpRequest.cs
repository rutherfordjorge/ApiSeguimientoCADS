// <copyright file="HttpRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Models.Requests.Http
{
    using System.Net.Http;

    /// <summary>
    /// HttpRequest - Modelo para configurar peticiones HTTP personalizadas
    /// </summary>
    public class HttpRequest
    {
        /// <summary>
        /// URL completa del endpoint
        /// </summary>
        required public Uri Url { get; set; }

        /// <summary>
        /// Método HTTP (GET, POST, PUT, DELETE, etc.)
        /// </summary>
        required public HttpMethod Method { get; set; }

        /// <summary>
        /// Token de autenticación Bearer (opcional)
        /// </summary>
        public string? BearerToken { get; set; }

        /// <summary>
        /// Cuerpo de la petición (para POST, PUT, PATCH)
        /// </summary>
        public object? Body { get; set; }

        /// <summary>
        /// Headers personalizados adicionales
        /// </summary>
        public Dictionary<string, string> CustomHeaders { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Timeout en segundos (opcional, por defecto usa el del servicio)
        /// </summary>
        public int? TimeoutSeconds { get; set; }

        /// <summary>
        /// Tipo de contenido del body (por defecto application/json)
        /// </summary>
        public string ContentType { get; set; } = "application/json";
    }
}