// <copyright file="GlobalExceptionMiddleware.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Middlewares
{
    using ApiSeguimientoCADS.Api.Exceptions;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using Microsoft.AspNetCore.Http;
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

        private readonly IAppLogger<GlobalExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GlobalExceptionMiddleware"/>.
        /// </summary>
        /// <param name="next">Delegado que representa el siguiente middleware en la canalización.</param>
        /// <param name="logger">Logger de la aplicación.</param>
        public GlobalExceptionMiddleware(RequestDelegate next, IAppLogger<GlobalExceptionMiddleware> logger)
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
                this._logger.LogError(exception, $"Excepción no controlada capturada en {context.Request.Path} [{context.Request.Method}]. Tipo: {exception.GetType().Name}");
                await HandleExceptionAsync(context, exception, this._logger).ConfigureAwait(false);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception, IAppLogger<GlobalExceptionMiddleware> logger)
        {
            var statusCode = exception switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                ValidationException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError,
            };

            if (context.Response.HasStarted)
            {
                logger.LogError($"No se puede manejar la excepción porque la respuesta ya fue enviada. Path: {context.Request.Path}, Exception: {exception.GetType().Name}");
                throw exception;
            }

            logger.Info($"Enviando respuesta de error. StatusCode: {statusCode}, Message: {exception.Message}, Path: {context.Request.Path}");
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
    }
}