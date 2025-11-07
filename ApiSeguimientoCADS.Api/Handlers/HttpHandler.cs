// <copyright file="HttpHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Handlers
{
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Models.Requests.Http;
    using ApiSeguimientoCADS.Api.Models.Responses.Http;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// HttpHandler - Handler para gestionar lógica de negocio de peticiones HTTP
    /// </summary>
    public class HttpHandler : IHttpHandler
    {
        private readonly IHttpService _httpService;
        private readonly IAppLogger<HttpHandler> _logger;

        /// <summary>
        /// Constructor de HttpHandler
        /// </summary>
        /// <param name="httpService">Servicio HTTP</param>
        /// <param name="logger">Logger de la aplicación</param>
        public HttpHandler(
            IHttpService httpService,
            IAppLogger<HttpHandler> logger)
        {
            this._httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Obtiene datos de una API externa con validación de negocio
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL del endpoint</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <param name="validateResponse">Delegado para validar la respuesta (opcional)</param>
        /// <returns>Respuesta validada del tipo especificado</returns>
        public async Task<TResponse?> GetWithValidationAsync<TResponse>(
            Uri url,
            string? bearerToken = null,
            Func<TResponse?, bool>? validateResponse = null)
            where TResponse : class
        {
            ArgumentNullException.ThrowIfNull(url);

            this._logger.Info($"Iniciando GET con validación a: {url}");

            try
            {
                var response = await this._httpService.GetAsync<TResponse>(url, bearerToken).ConfigureAwait(false);

                if (response == null)
                {
                    this._logger.Info($"Respuesta nula desde: {url}");
                    return null;
                }

                // REGLA DE NEGOCIO: Validar respuesta si se proporciona un validador
                if (validateResponse != null && !validateResponse(response))
                {
                    this._logger.Info($"La respuesta no pasó la validación de negocio desde: {url}");
                    return null;
                }

                this._logger.Info($"GET exitoso con validación desde: {url}");
                return response;
            }
            catch (InvalidOperationException ex)
            {
                this._logger.LogError(ex, $"Error de operación al obtener datos desde: {url}");
                throw;
            }
            catch (HttpRequestException ex)
            {
                this._logger.LogError(ex, $"Error de red al obtener datos desde: {url}");
                throw;
            }
        }

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
        public async Task<TResponse?> PostWithValidationAsync<TRequest, TResponse>(
            Uri url,
            TRequest body,
            string? bearerToken = null,
            Func<TRequest, bool>? validateRequest = null,
            Func<TResponse?, bool>? validateResponse = null)
            where TRequest : class
            where TResponse : class
        {
            ArgumentNullException.ThrowIfNull(url);
            ArgumentNullException.ThrowIfNull(body);

            this._logger.Info($"Iniciando POST con validación a: {url}");

            try
            {
                // REGLA DE NEGOCIO: Validar request antes de enviarlo
                if (validateRequest != null && !validateRequest(body))
                {
                    this._logger.Info($"El request no pasó la validación de negocio para: {url}");
                    throw new ArgumentException("El request no cumple con las reglas de negocio");
                }

                var response = await this._httpService.PostAsync<TRequest, TResponse>(url, body, bearerToken).ConfigureAwait(false);

                if (response == null)
                {
                    this._logger.Info($"Respuesta nula desde: {url}");
                    return null;
                }

                // REGLA DE NEGOCIO: Validar respuesta si se proporciona un validador
                if (validateResponse != null && !validateResponse(response))
                {
                    this._logger.Info($"La respuesta no pasó la validación de negocio desde: {url}");
                    return null;
                }

                this._logger.Info($"POST exitoso con validación a: {url}");
                return response;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (InvalidOperationException ex)
            {
                this._logger.LogError(ex, $"Error de operación al enviar datos a: {url}");
                throw;
            }
            catch (HttpRequestException ex)
            {
                this._logger.LogError(ex, $"Error de red al enviar datos a: {url}");
                throw;
            }
        }

        /// <summary>
        /// Ejecuta múltiples peticiones HTTP en paralelo
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="urls">Lista de URLs a consultar</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <returns>Lista de respuestas en el mismo orden que las URLs</returns>
        public async Task<List<TResponse?>> GetMultipleAsync<TResponse>(
        IEnumerable<Uri> urls,
        string? bearerToken = null)
        where TResponse : class
        {
            ArgumentNullException.ThrowIfNull(urls);

            // Materializar la colección una sola vez
            var urlList = urls.ToList();

            if (urlList.Count == 0)
            {
                this._logger.Info("Lista de URLs vacía para peticiones múltiples");
                return new List<TResponse?>();
            }

            this._logger.Info($"Iniciando {urlList.Count} peticiones GET en paralelo");

            try
            {
                // Ejecutar todas las peticiones en paralelo
                var tasks = urlList.Select(url => this._httpService.GetAsync<TResponse>(url, bearerToken)).ToList();

                var results = await Task.WhenAll(tasks).ConfigureAwait(false);

                var successCount = results.Count(r => r != null);
                this._logger.Info($"Completadas {successCount}/{urlList.Count} peticiones exitosas");

                return results.ToList();
            }
            catch (InvalidOperationException ex)
            {
                this._logger.LogError(ex, "Error de operación en peticiones múltiples");
                throw;
            }
            catch (HttpRequestException ex)
            {
                this._logger.LogError(ex, "Error de red en peticiones múltiples");
                throw;
            }
        }

        /// <summary>
        /// Ejecuta una petición HTTP con retry automático en caso de fallo
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="url">URL del endpoint</param>
        /// <param name="bearerToken">Token de autenticación (opcional)</param>
        /// <param name="maxRetries">Número máximo de reintentos (por defecto 3)</param>
        /// <param name="delayMs">Delay entre reintentos en milisegundos (por defecto 1000)</param>
        /// <returns>Respuesta del tipo especificado o null si todos los intentos fallan</returns>
        public async Task<TResponse?> GetWithRetryAsync<TResponse>(
            Uri url,
            string? bearerToken = null,
            int maxRetries = 3,
            int delayMs = 1000)
            where TResponse : class
        {
            ArgumentNullException.ThrowIfNull(url);

            if (maxRetries < 1)
            {
                throw new ArgumentException("El número de reintentos debe ser mayor a 0", nameof(maxRetries));
            }

            if (delayMs < 0)
            {
                throw new ArgumentException("El delay debe ser mayor o igual a 0", nameof(delayMs));
            }

            this._logger.Info($"Iniciando GET con retry (max: {maxRetries}) a: {url}");

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    this._logger.Debug($"Intento {attempt}/{maxRetries} para: {url}");

                    var response = await this._httpService.GetAsync<TResponse>(url, bearerToken).ConfigureAwait(false);

                    if (response != null)
                    {
                        this._logger.Info($"GET exitoso en intento {attempt}/{maxRetries} para: {url}");
                        return response;
                    }

                    this._logger.Info($"Respuesta nula en intento {attempt}/{maxRetries} para: {url}");
                }
                catch (HttpRequestException ex)
                {
                    this._logger.Info($"Error en intento {attempt}/{maxRetries} para: {url} - {ex.Message}");

                    // REGLA DE NEGOCIO: Si no es el último intento, esperar antes de reintentar
                    if (attempt < maxRetries)
                    {
                        this._logger.Debug($"Esperando {delayMs}ms antes del siguiente intento...");
                        await Task.Delay(delayMs).ConfigureAwait(false);
                    }
                    else
                    {
                        this._logger.LogError(ex, $"Todos los intentos fallaron para: {url}");
                        throw;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    this._logger.LogError(ex, $"Error de operación en intento {attempt}/{maxRetries} para: {url}");
                    throw;
                }
            }

            this._logger.Info($"Todos los {maxRetries} intentos resultaron en respuesta nula para: {url}");
            return null;
        }

        /// <summary>
        /// Ejecuta una petición HTTP personalizada con procesamiento de respuesta
        /// </summary>
        /// <typeparam name="TResponse">Tipo de respuesta esperada</typeparam>
        /// <param name="request">Configuración de la petición HTTP</param>
        /// <param name="processResponse">Delegado para procesar la respuesta antes de devolverla (opcional)</param>
        /// <returns>Respuesta HTTP completa procesada</returns>
        public async Task<HttpApiResponse<TResponse>> ExecuteCustomRequestAsync<TResponse>(
            HttpRequest request,
            Func<HttpApiResponse<TResponse>, Task<HttpApiResponse<TResponse>>>? processResponse = null)
            where TResponse : class
        {
            ArgumentNullException.ThrowIfNull(request);

            this._logger.Info($"Iniciando petición personalizada {request.Method} a: {request.Url}");

            try
            {
                var response = await this._httpService.SendCustomAsync<TResponse>(request).ConfigureAwait(false);

                // REGLA DE NEGOCIO: Procesar respuesta si se proporciona un procesador
                if (processResponse != null)
                {
                    this._logger.Debug($"Procesando respuesta personalizada de: {request.Url}");
                    response = await processResponse(response).ConfigureAwait(false);
                }

                this._logger.Info($"Petición personalizada completada. Status: {response.StatusCode}, Time: {response.ResponseTimeMs}ms");

                return response;
            }
            catch (InvalidOperationException ex)
            {
                this._logger.LogError(ex, $"Error de operación en petición personalizada a: {request.Url}");
                throw;
            }
            catch (HttpRequestException ex)
            {
                this._logger.LogError(ex, $"Error de red en petición personalizada a: {request.Url}");
                throw;
            }
        }
    }
}