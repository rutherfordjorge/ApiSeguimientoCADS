// <copyright file="GlobalExceptionMiddleware.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Middlewares
{
    using ApiSeguimientoCADS.Api.Exceptions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Middleware que captura todas las excepciones no controladas y genera una respuesta JSON uniforme.
    /// </summary>
    public sealed class GlobalExceptionMiddleware
    {
        private static readonly JsonSerializerOptions _serializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GlobalExceptionMiddleware"/>.
        /// </summary>
        /// <param name="next">Delegado que representa el siguiente middleware en la canalización.</param>
        /// <param name="logger">Instancia de <see cref="ILogger"/> para registrar eventos.</param>
        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            this._next = next ?? throw new ArgumentNullException(nameof(next));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Ejecuta el middleware y captura las excepciones producidas por los componentes siguientes.
        /// </summary>
        /// <param name="context">Contexto HTTP actual.</param>
        /// <returns>Una tarea asincrónica.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            try
            {
                await this._next(context).ConfigureAwait(false);
            }
            catch (Exception exception) when (exception is not OperationCanceledException)
            {
                LogUnhandledException(this._logger, nameof(GlobalExceptionMiddleware), exception);
                await HandleExceptionAsync(context, exception).ConfigureAwait(false);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = exception switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                ValidationException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError,
            };

            if (context.Response.HasStarted)
            {
                throw exception;
            }

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var response = new
            {
                statusCode,
                message = exception.Message,
            };

            var payload = JsonSerializer.Serialize(response, _serializerOptions);
            await context.Response.WriteAsync(payload).ConfigureAwait(false);
        }

        private static readonly Action<ILogger, string, Exception?> LogUnhandledException = LoggerMessage.Define<string>(
            LogLevel.Error,
            new EventId(1, nameof(LogUnhandledException)),
            "Unhandled exception captured by {Middleware}");
    }
}