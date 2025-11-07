// <copyright file="IHttpHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Handlers.Interfaces
{
    using ApiSeguimientoCADS.Api.Models.Requests.Http;
    using ApiSeguimientoCADS.Api.Models.Responses.Http;

    /// <summary>
    /// IHttpHandler - Handler para gestionar lógica de negocio de peticiones HTTP
    /// </summary>
    public interface IHttpHandler
    {
        /// <summary>
        /// Obtiene datos de una API externa con validación de negocio
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL del endpoint</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <param name="validateResponse">Delegado para validar la respuesta (opcional)</param>
        /// <returns>Respuesta validada del tipo especificado</returns>
        Task<TResponse?> GetWithValidationAsync<TResponse>(
            Uri url,
            string? bearerToken = null,
            Func<TResponse?, bool>? validateResponse = null)
            where TResponse : class;

        /// <summary>
        /// Envía datos a una API externa con validación de negocio
        /// </summary>
        /// <typeparam name="TRequest">Tipo de datos a enviar</typeparam>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL del endpoint</param>
        /// <param name="body">Datos a enviar</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <param name="validateRequest">Delegado para validar el request antes de enviarlo (opcional)</param>
        /// <param name="validateResponse">Delegado para validar la respuesta (opcional)</param>
        /// <returns>Respuesta validada del tipo especificado</returns>
        Task<TResponse?> PostWithValidationAsync<TRequest, TResponse>(
            Uri url,
            TRequest body,
            string? bearerToken = null,
            Func<TRequest, bool>? validateRequest = null,
            Func<TResponse?, bool>? validateResponse = null)
            where TRequest : class
            where TResponse : class;

        /// <summary>
        /// Ejecuta múltiples peticiones HTTP en paralelo
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="urls">Lista de URLs a consultar</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <returns>Lista de respuestas en el mismo orden que las URLs</returns>
        Task<List<TResponse?>> GetMultipleAsync<TResponse>(
            IEnumerable<Uri> urls,
            string? bearerToken = null)
            where TResponse : class;

        /// <summary>
        /// Ejecuta una petición HTTP con retry automático en caso de fallo
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL del endpoint</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <param name="maxRetries">Número máximo de reintentos (por defecto 3)</param>
        /// <param name="delayMs">Delay entre reintentos en milisegundos (por defecto 1000)</param>
        /// <returns>Respuesta del tipo especificado o null si todos los intentos fallan</returns>
        Task<TResponse?> GetWithRetryAsync<TResponse>(
            Uri url,
            string? bearerToken = null,
            int maxRetries = 3,
            int delayMs = 1000)
            where TResponse : class;

        /// <summary>
        /// Ejecuta una petición HTTP personalizada con procesamiento de respuesta
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="request">Configuración de la petición HTTP</param>
        /// <param name="processResponse">Delegado para procesar la respuesta antes de devolverla (opcional)</param>
        /// <returns>Respuesta HTTP completa procesada</returns>
        Task<HttpApiResponse<TResponse>> ExecuteCustomRequestAsync<TResponse>(
            HttpRequest request,
            Func<HttpApiResponse<TResponse>, Task<HttpApiResponse<TResponse>>>? processResponse = null)
            where TResponse : class;
    }
}