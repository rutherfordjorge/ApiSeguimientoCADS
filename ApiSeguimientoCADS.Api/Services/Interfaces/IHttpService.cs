// <copyright file="IHttpService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Services.Interfaces
{
    using ApiSeguimientoCADS.Api.Models.Requests.Http;
    using ApiSeguimientoCADS.Api.Models.Responses.Http;

    /// <summary>
    /// IHttpService - Servicio genérico para realizar llamadas HTTP a APIs externas
    /// </summary>
    public interface IHttpService
    {
        /// <summary>
        /// Realiza una petición HTTP GET a una URL específica
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL completa del endpoint</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <returns>Respuesta deserializada del tipo especificado</returns>
        Task<TResponse?> GetAsync<TResponse>(Uri url, string? bearerToken = null)
            where TResponse : class;

        /// <summary>
        /// Realiza una petición HTTP POST a una URL específica
        /// </summary>
        /// <typeparam name="TRequest">Tipo de datos a enviar en el body</typeparam>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL completa del endpoint</param>
        /// <param name="body">Datos a enviar en el body</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <returns>Respuesta deserializada del tipo especificado</returns>
        Task<TResponse?> PostAsync<TRequest, TResponse>(Uri url, TRequest body, string? bearerToken = null)
            where TRequest : class
            where TResponse : class;

        /// <summary>
        /// Realiza una petición HTTP PUT a una URL específica
        /// </summary>
        /// <typeparam name="TRequest">Tipo de datos a enviar en el body</typeparam>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL completa del endpoint</param>
        /// <param name="body">Datos a enviar en el body</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <returns>Respuesta deserializada del tipo especificado</returns>
        Task<TResponse?> PutAsync<TRequest, TResponse>(Uri url, TRequest body, string? bearerToken = null)
            where TRequest : class
            where TResponse : class;

        /// <summary>
        /// Realiza una petición HTTP DELETE a una URL específica
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL completa del endpoint</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <returns>Respuesta deserializada del tipo especificado</returns>
        Task<TResponse?> DeleteAsync<TResponse>(Uri url, string? bearerToken = null)
            where TResponse : class;

        /// <summary>
        /// Realiza una petición HTTP con configuración personalizada
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="request">Configuración de la petición HTTP</param>
        /// <returns>Respuesta HTTP completa con datos y metadata</returns>
        Task<HttpApiResponse<TResponse>> SendCustomAsync<TResponse>(HttpRequest request)
            where TResponse : class;

        /// <summary>
        /// Realiza una petición HTTP GET con headers personalizados
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL completa del endpoint</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <param name="customHeaders">Headers personalizados adicionales (opcional)</param>
        /// <returns>Respuesta deserializada del tipo especificado</returns>
        Task<TResponse?> GetWithHeadersAsync<TResponse>(
            Uri url,
            string? bearerToken = null,
            Dictionary<string, string>? customHeaders = null)
            where TResponse : class;

        /// <summary>
        /// Realiza una petición HTTP POST con headers personalizados
        /// </summary>
        /// <typeparam name="TRequest">Tipo de datos a enviar en el body</typeparam>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL completa del endpoint</param>
        /// <param name="body">Datos a enviar en el body</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <param name="customHeaders">Headers personalizados adicionales (opcional)</param>
        /// <returns>Respuesta deserializada del tipo especificado</returns>
        Task<TResponse?> PostWithHeadersAsync<TRequest, TResponse>(
            Uri url,
            TRequest body,
            string? bearerToken = null,
            Dictionary<string, string>? customHeaders = null)
            where TRequest : class
            where TResponse : class;

        /// <summary>
        /// Realiza una petición HTTP GET con Circuit Breaker para servicios críticos
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL completa del endpoint</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <param name="customHeaders">Headers personalizados adicionales (opcional)</param>
        /// <returns>Respuesta HTTP completa con datos y metadata</returns>
        Task<HttpApiResponse<TResponse>> GetWithCircuitBreakerAsync<TResponse>(
            Uri url,
            string? bearerToken = null,
            Dictionary<string, string>? customHeaders = null)
            where TResponse : class;

        /// <summary>
        /// Realiza una petición HTTP POST con Circuit Breaker para servicios críticos
        /// </summary>
        /// <typeparam name="TRequest">Tipo de datos a enviar en el body</typeparam>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL completa del endpoint</param>
        /// <param name="body">Datos a enviar en el body</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <param name="customHeaders">Headers personalizados adicionales (opcional)</param>
        /// <returns>Respuesta HTTP completa con datos y metadata</returns>
        Task<HttpApiResponse<TResponse>> PostWithCircuitBreakerAsync<TRequest, TResponse>(
            Uri url,
            TRequest body,
            string? bearerToken = null,
            Dictionary<string, string>? customHeaders = null)
            where TRequest : class
            where TResponse : class;
    }
}