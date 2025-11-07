// <copyright file="CorrelationIdMiddleware.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using NLog;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Middleware que maneja el CorrelationId para rastreo de peticiones
    /// </summary>
    public sealed class CorrelationIdMiddleware
    {
        private const string CorrelationIdHeaderName = "X-Correlation-ID";
        private const string CorrelationIdPropertyName = "X-Request-ID";
        private readonly RequestDelegate _next;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CorrelationIdMiddleware"/>.
        /// </summary>
        /// <param name="next">Delegado que representa el siguiente middleware en la canalización.</param>
        public CorrelationIdMiddleware(RequestDelegate next)
        {
            this._next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// Ejecuta el middleware y establece el CorrelationId en el contexto
        /// </summary>
        /// <param name="context">Contexto HTTP actual.</param>
        /// <returns>Una tarea asincrónica.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            // Intentar obtener el CorrelationId del header de la petición
            // Si no existe, generar uno nuevo
            var correlationId = context.Request.Headers[CorrelationIdHeaderName].ToString();

            if (string.IsNullOrWhiteSpace(correlationId))
            {
                correlationId = Guid.NewGuid().ToString();
            }

            // Establecer el CorrelationId en el contexto de NLog usando ScopeContext (NLog 5.0+)
            using (ScopeContext.PushProperty(CorrelationIdPropertyName, correlationId))
            {
                // Agregar el CorrelationId a los headers de respuesta
                context.Response.Headers[CorrelationIdHeaderName] = correlationId;

                // Continuar con el siguiente middleware
                await this._next(context).ConfigureAwait(false);
            }
        }
    }
}