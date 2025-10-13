namespace ApiSeguimientoCADS.Tests.Middlewares
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;
    using ApiSeguimientoCADS.Api.Exceptions;
    using ApiSeguimientoCADS.Api.Middlewares;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    /// <summary>
    /// Pruebas unitarias para <see cref="GlobalExceptionMiddleware"/>.
    /// </summary>
    public sealed class GlobalExceptionMiddlewareTests
    {
        [Fact]
        public async Task InvokeAsync_WhenNotFoundExceptionIsThrown_ReturnsNotFoundResponse()
        {
            const string expectedMessage = "Resource not found";
            var middleware = CreateMiddleware(_ => throw new NotFoundException(expectedMessage));
            var context = CreateHttpContext();

            await middleware.InvokeAsync(context).ConfigureAwait(false);

            Assert.Equal((int)HttpStatusCode.NotFound, context.Response.StatusCode);
            var payload = await ReadResponseAsync(context).ConfigureAwait(false);
            Assert.True(payload.TryGetValue("message", out var messageElement));
            Assert.Equal(expectedMessage, messageElement.GetString());
        }

        [Fact]
        public async Task InvokeAsync_WhenValidationExceptionIsThrown_ReturnsBadRequestResponse()
        {
            var middleware = CreateMiddleware(_ => throw new ValidationException("Validation failed"));
            var context = CreateHttpContext();

            await middleware.InvokeAsync(context).ConfigureAwait(false);

            Assert.Equal((int)HttpStatusCode.BadRequest, context.Response.StatusCode);
            var payload = await ReadResponseAsync(context).ConfigureAwait(false);
            Assert.True(payload.TryGetValue("statusCode", out var statusElement));
            Assert.Equal((int)HttpStatusCode.BadRequest, statusElement.GetInt32());
        }

        [Fact]
        public async Task InvokeAsync_WhenUnexpectedExceptionIsThrown_ReturnsInternalServerError()
        {
            const string exceptionMessage = "Unexpected";
            var middleware = CreateMiddleware(_ => throw new System.Exception(exceptionMessage));
            var context = CreateHttpContext();

            await middleware.InvokeAsync(context).ConfigureAwait(false);

            Assert.Equal((int)HttpStatusCode.InternalServerError, context.Response.StatusCode);
            var payload = await ReadResponseAsync(context).ConfigureAwait(false);
            Assert.True(payload.TryGetValue("message", out var messageElement));
            Assert.Equal(exceptionMessage, messageElement.GetString());
        }

        private static GlobalExceptionMiddleware CreateMiddleware(RequestDelegate requestDelegate)
        {
            var loggerMock = new Mock<ILogger<GlobalExceptionMiddleware>>();
            return new GlobalExceptionMiddleware(requestDelegate, loggerMock.Object);
        }

        private static DefaultHttpContext CreateHttpContext()
        {
            return new DefaultHttpContext
            {
                Response =
                {
                    Body = new MemoryStream(),
                },
            };
        }

        private static async Task<Dictionary<string, JsonElement>> ReadResponseAsync(HttpContext context)
        {
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(context.Response.Body, leaveOpen: true);
            var body = await reader.ReadToEndAsync().ConfigureAwait(false);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(body) ?? new Dictionary<string, JsonElement>();
        }
    }
}
