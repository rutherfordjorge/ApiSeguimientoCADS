// <copyright file="RequestIdMiddleware.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Middlewares
{
    using ApiSeguimientoCADS.Api.Security.Logger;
    using Microsoft.AspNetCore.Http;
    using NLog;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Middleware para gestionar el X-Request-ID en cada petición HTTP.
    /// </summary>
    public class RequestIdMiddleware
    {
        private const string _requestIdHeader = "X-Request-ID";
        private readonly RequestDelegate _next;
        private readonly IAppLogger<RequestIdMiddleware> _logger;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RequestIdMiddleware"/>.
        /// </summary>
        /// <param name="next">El siguiente middleware en el pipeline.</param>
        /// <param name="logger">El logger de la aplicación.</param>
        public RequestIdMiddleware(RequestDelegate next, IAppLogger<RequestIdMiddleware> logger)
        {
            this._next = next ?? throw new ArgumentNullException(nameof(next));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Invoca el middleware para manejar el X-Request-ID.
        /// </summary>
        /// <param name="context">Contexto HTTP actual.</param>
        /// <returns>Una tarea asincrónica.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            // Obtener o generar X-Request-ID
            var requestId = context.Request.Headers.TryGetValue(_requestIdHeader, out var headerValue)
                ? headerValue.ToString()
                : Guid.NewGuid().ToString();

            // Agregar al contexto de NLog usando ScopeContext
            using (ScopeContext.PushProperty(_requestIdHeader, requestId))
            {
                // Agregar X-Request-ID a la respuesta HTTP
                context.Response.Headers.TryAdd(_requestIdHeader, requestId);

                // Agregar al contexto de ASP.NET Core
                context.Items[_requestIdHeader] = requestId;

                this._logger.Info($"Request iniciado: {context.Request.Method} {context.Request.Path} - X-Request-ID: {requestId}");

                try
                {
                    await this._next(context).ConfigureAwait(false);

                    this._logger.Info($"Request completado: {context.Request.Method} {context.Request.Path} - Status: {context.Response.StatusCode} - X-Request-ID: {requestId}");
                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex);
                    throw;
                }
            }
        }
    }
}