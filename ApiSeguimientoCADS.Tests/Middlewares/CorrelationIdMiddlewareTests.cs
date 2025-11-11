// <copyright file="CorrelationIdMiddlewareTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Tests.Middlewares
{
    using ApiSeguimientoCADS.Api.Middlewares;
    using Microsoft.AspNetCore.Http;
    using NLog;
    using NUnit.Framework;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Pruebas unitarias para <see cref="CorrelationIdMiddleware"/>.
    /// </summary>
    [TestFixture]
    public sealed class CorrelationIdMiddlewareTests
    {
        private const string CorrelationIdHeaderName = "X-Correlation-ID";
        private const string CorrelationIdPropertyName = "X-Request-ID";

        [TearDown]
        public void TearDown()
        {
            // Clear NLog context after each test
            ScopeContext.Clear();
        }

        [Test]
        public void Constructor_WhenNextIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CorrelationIdMiddleware(null!));
        }

        [Test]
        public void InvokeAsync_WhenContextIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var middleware = new CorrelationIdMiddleware(context =>
            {
                return Task.CompletedTask;
            });

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await middleware.InvokeAsync(null!));
        }

        [Test]
        public async Task InvokeAsync_WhenNoCorrelationIdInRequest_GeneratesNewOne()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var middleware = new CorrelationIdMiddleware(ctx =>
            {
                return Task.CompletedTask;
            });

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            Assert.That(context.Response.Headers.ContainsKey(CorrelationIdHeaderName), Is.True);
            var correlationId = context.Response.Headers[CorrelationIdHeaderName].ToString();
            Assert.That(correlationId, Is.Not.Null);
            Assert.That(correlationId, Is.Not.Empty);
            Assert.That(Guid.TryParse(correlationId, out _), Is.True, "Correlation ID should be a valid GUID");
        }

        [Test]
        public async Task InvokeAsync_WhenCorrelationIdExistsInRequest_UsesExistingOne()
        {
            // Arrange
            var existingCorrelationId = "existing-correlation-id-123";
            var context = new DefaultHttpContext();
            context.Request.Headers[CorrelationIdHeaderName] = existingCorrelationId;

            var middleware = new CorrelationIdMiddleware(ctx =>
            {
                return Task.CompletedTask;
            });

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            Assert.That(context.Response.Headers.ContainsKey(CorrelationIdHeaderName), Is.True);
            var responseCorrelationId = context.Response.Headers[CorrelationIdHeaderName].ToString();
            Assert.That(responseCorrelationId, Is.EqualTo(existingCorrelationId));
        }

        [Test]
        public async Task InvokeAsync_AddsCorrelationIdToResponseHeaders()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var middleware = new CorrelationIdMiddleware(ctx =>
            {
                return Task.CompletedTask;
            });

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            Assert.That(context.Response.Headers.ContainsKey(CorrelationIdHeaderName), Is.True);
        }

        [Test]
        public async Task InvokeAsync_SetsCorrelationIdInNLogContext()
        {
            // Arrange
            var context = new DefaultHttpContext();
            string? capturedCorrelationId = null;

            var middleware = new CorrelationIdMiddleware(ctx =>
            {
                // Capture the correlation ID from NLog context inside the middleware execution
                capturedCorrelationId = ScopeContext.TryGetProperty(CorrelationIdPropertyName, out var value)
                    ? value?.ToString()
                    : null;
                return Task.CompletedTask;
            });

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            Assert.That(capturedCorrelationId, Is.Not.Null);
            Assert.That(capturedCorrelationId, Is.Not.Empty);
        }

        [Test]
        public async Task InvokeAsync_CorrelationIdInContextMatchesResponseHeader()
        {
            // Arrange
            var context = new DefaultHttpContext();
            string? contextCorrelationId = null;

            var middleware = new CorrelationIdMiddleware(ctx =>
            {
                // Capture correlation ID from NLog context
                contextCorrelationId = ScopeContext.TryGetProperty(CorrelationIdPropertyName, out var value)
                    ? value?.ToString()
                    : null;
                return Task.CompletedTask;
            });

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            var responseCorrelationId = context.Response.Headers[CorrelationIdHeaderName].ToString();
            Assert.That(contextCorrelationId, Is.EqualTo(responseCorrelationId));
        }

        [Test]
        public async Task InvokeAsync_CallsNextMiddleware()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var nextMiddlewareCalled = false;

            var middleware = new CorrelationIdMiddleware(ctx =>
            {
                nextMiddlewareCalled = true;
                return Task.CompletedTask;
            });

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            Assert.That(nextMiddlewareCalled, Is.True);
        }

        [Test]
        public async Task InvokeAsync_WithEmptyCorrelationIdInRequest_GeneratesNewOne()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Headers[CorrelationIdHeaderName] = string.Empty;

            var middleware = new CorrelationIdMiddleware(ctx =>
            {
                return Task.CompletedTask;
            });

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            var responseCorrelationId = context.Response.Headers[CorrelationIdHeaderName].ToString();
            Assert.That(responseCorrelationId, Is.Not.Null);
            Assert.That(responseCorrelationId, Is.Not.Empty);
            Assert.That(Guid.TryParse(responseCorrelationId, out _), Is.True);
        }

        [Test]
        public async Task InvokeAsync_WithWhitespaceCorrelationIdInRequest_GeneratesNewOne()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Headers[CorrelationIdHeaderName] = "   ";

            var middleware = new CorrelationIdMiddleware(ctx =>
            {
                return Task.CompletedTask;
            });

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            var responseCorrelationId = context.Response.Headers[CorrelationIdHeaderName].ToString();
            Assert.That(responseCorrelationId, Is.Not.Null);
            Assert.That(responseCorrelationId, Is.Not.Empty);
            Assert.That(Guid.TryParse(responseCorrelationId, out _), Is.True);
        }

        [Test]
        public async Task InvokeAsync_PreservesCustomCorrelationIdFormat()
        {
            // Arrange
            var customCorrelationId = "custom-format-12345-ABC";
            var context = new DefaultHttpContext();
            context.Request.Headers[CorrelationIdHeaderName] = customCorrelationId;

            var middleware = new CorrelationIdMiddleware(ctx =>
            {
                return Task.CompletedTask;
            });

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            var responseCorrelationId = context.Response.Headers[CorrelationIdHeaderName].ToString();
            Assert.That(responseCorrelationId, Is.EqualTo(customCorrelationId));
        }

        [Test]
        public async Task InvokeAsync_WhenNextMiddlewareThrows_CorrelationIdStillSetInResponse()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var middleware = new CorrelationIdMiddleware(ctx =>
            {
                throw new InvalidOperationException("Test exception");
            });

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await middleware.InvokeAsync(context));

            // Verify correlation ID was still set before the exception
            Assert.That(context.Response.Headers.ContainsKey(CorrelationIdHeaderName), Is.True);
        }

        [Test]
        public async Task InvokeAsync_MultipleInvocations_GeneratesDifferentCorrelationIds()
        {
            // Arrange
            var context1 = new DefaultHttpContext();
            var context2 = new DefaultHttpContext();

            var middleware = new CorrelationIdMiddleware(ctx =>
            {
                return Task.CompletedTask;
            });

            // Act
            await middleware.InvokeAsync(context1);
            await middleware.InvokeAsync(context2);

            // Assert
            var correlationId1 = context1.Response.Headers[CorrelationIdHeaderName].ToString();
            var correlationId2 = context2.Response.Headers[CorrelationIdHeaderName].ToString();

            Assert.That(correlationId1, Is.Not.EqualTo(correlationId2));
        }

        [Test]
        public async Task InvokeAsync_CleansUpNLogContextAfterExecution()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var middleware = new CorrelationIdMiddleware(ctx =>
            {
                return Task.CompletedTask;
            });

            // Act
            await middleware.InvokeAsync(context);

            // Assert - The scope should be disposed after middleware execution
            // We can verify that a new invocation doesn't carry over the previous context
            var hasProperty = ScopeContext.TryGetProperty(CorrelationIdPropertyName, out var value);

            // The property should either not exist or be null after scope disposal
            Assert.That(!hasProperty || value == null, Is.True);
        }
    }
}
