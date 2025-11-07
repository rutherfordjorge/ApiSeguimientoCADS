namespace ApiSeguimientoCADS.Tests.Middlewares
{
    using ApiSeguimientoCADS.Api.Exceptions;
    using ApiSeguimientoCADS.Api.Middlewares;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Pruebas unitarias para <see cref="GlobalExceptionMiddleware"/>.
    /// </summary>
    [TestFixture]
    public sealed class GlobalExceptionMiddlewareTests
    {
        [Test]
        public async Task InvokeAsync_WhenNotFoundExceptionIsThrown_ReturnsNotFoundResponse()
        {
            const string expectedMessage = "Resource not found";
            var middleware = CreateMiddleware(_ => throw new NotFoundException(expectedMessage));
            var context = CreateHttpContext();

            await middleware.InvokeAsync(context);

            Assert.That(context.Response.StatusCode, Is.EqualTo((int)HttpStatusCode.NotFound));
            var payload = await ReadResponseAsync(context);
            Assert.That(payload.TryGetValue("message", out var messageElement), Is.True);
            Assert.That(messageElement.GetString(), Is.EqualTo(expectedMessage));
        }

        [Test]
        public async Task InvokeAsync_WhenValidationExceptionIsThrown_ReturnsBadRequestResponse()
        {
            var middleware = CreateMiddleware(_ => throw new ValidationException("Validation failed"));
            var context = CreateHttpContext();

            await middleware.InvokeAsync(context);

            Assert.That(context.Response.StatusCode, Is.EqualTo((int)HttpStatusCode.BadRequest));
            var payload = await ReadResponseAsync(context);
            Assert.That(payload.TryGetValue("statusCode", out var statusElement), Is.True);
            Assert.That(statusElement.GetInt32(), Is.EqualTo((int)HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task InvokeAsync_WhenUnexpectedExceptionIsThrown_ReturnsInternalServerError()
        {
            const string exceptionMessage = "Unexpected";
            var middleware = CreateMiddleware(_ => throw new System.Exception(exceptionMessage));
            var context = CreateHttpContext();

            await middleware.InvokeAsync(context);

            Assert.That(context.Response.StatusCode, Is.EqualTo((int)HttpStatusCode.InternalServerError));
            var payload = await ReadResponseAsync(context);
            Assert.That(payload.TryGetValue("message", out var messageElement), Is.True);
            Assert.That(messageElement.GetString(), Is.EqualTo(exceptionMessage));
        }

        private static GlobalExceptionMiddleware CreateMiddleware(RequestDelegate requestDelegate)
        {
            var loggerMock = new Mock<IAppLogger<GlobalExceptionMiddleware>>();
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