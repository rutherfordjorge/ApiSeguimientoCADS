// <copyright file="HttpApiResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Models.Responses.Http
{
    using System.Net;

    /// <summary>
    /// HttpApiResponse - Respuesta completa de una petición HTTP con metadata
    /// </summary>
    /// <typeparam name="T">Tipo de datos de la respuesta</typeparam>
    public class HttpApiResponse<T>
        where T : class
    {
        /// <summary>
        /// Datos deserializados de la respuesta
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Código de estado HTTP
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Indica si la petición fue exitosa (2xx)
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Mensaje de error (si existe)
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Headers de la respuesta
        /// </summary>
        public Dictionary<string, string> ResponseHeaders { get; } = new();

        /// <summary>
        /// Tiempo de respuesta en milisegundos
        /// </summary>
        public long ResponseTimeMs { get; set; }

        /// <summary>
        /// Contenido raw de la respuesta (útil para debugging)
        /// </summary>
        public string? RawContent { get; set; }
    }
}