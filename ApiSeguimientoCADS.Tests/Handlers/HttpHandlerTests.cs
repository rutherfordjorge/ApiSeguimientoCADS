// <copyright file="HttpHandlerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Tests.Handlers
{
    using ApiSeguimientoCADS.Api.Handlers;
    using ApiSeguimientoCADS.Api.Models.Requests.Http;
    using ApiSeguimientoCADS.Api.Models.Responses.Http;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Pruebas unitarias para <see cref="HttpHandler"/>.
    /// </summary>
    [TestFixture]
    public sealed class HttpHandlerTests
    {
        private Mock<IHttpService> _httpServiceMock = null!;
        private Mock<IAppLogger<HttpHandler>> _loggerMock = null!;
        private HttpHandler _handler = null!;

        [SetUp]
        public void SetUp()
        {
            this._httpServiceMock = new Mock<IHttpService>();
            this._loggerMock = new Mock<IAppLogger<HttpHandler>>();
            this._handler = new HttpHandler(this._httpServiceMock.Object, this._loggerMock.Object);
        }

        [Test]
        public void Constructor_WhenHttpServiceIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HttpHandler(null!, this._loggerMock.Object));
        }

        [Test]
        public void Constructor_WhenLoggerIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HttpHandler(this._httpServiceMock.Object, null!));
        }

        #region GetWithValidationAsync Tests

        [Test]
        public async Task GetWithValidationAsync_WhenUrlIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await this._handler.GetWithValidationAsync<TestResponse>(null!));
        }

        [Test]
        public async Task GetWithValidationAsync_WhenResponseIsValid_ReturnsResponse()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var expectedResponse = new TestResponse { Value = "test" };

            this._httpServiceMock
                .Setup(s => s.GetAsync<TestResponse>(url, null))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await this._handler.GetWithValidationAsync<TestResponse>(url);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Value, Is.EqualTo("test"));
            this._httpServiceMock.Verify(s => s.GetAsync<TestResponse>(url, null), Times.Once);
        }

        [Test]
        public async Task GetWithValidationAsync_WhenResponseIsNull_ReturnsNull()
        {
            // Arrange
            var url = new Uri("https://test.com/api");

            this._httpServiceMock
                .Setup(s => s.GetAsync<TestResponse>(url, null))
                .ReturnsAsync((TestResponse?)null);

            // Act
            var result = await this._handler.GetWithValidationAsync<TestResponse>(url);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetWithValidationAsync_WithBearerToken_PassesTokenToService()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var token = "test-token";
            var expectedResponse = new TestResponse { Value = "test" };

            this._httpServiceMock
                .Setup(s => s.GetAsync<TestResponse>(url, token))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await this._handler.GetWithValidationAsync<TestResponse>(url, token);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            this._httpServiceMock.Verify(s => s.GetAsync<TestResponse>(url, token), Times.Once);
        }

        [Test]
        public async Task GetWithValidationAsync_WithValidationFunction_ValidatesResponse()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var response = new TestResponse { Value = "test" };

            this._httpServiceMock
                .Setup(s => s.GetAsync<TestResponse>(url, null))
                .ReturnsAsync(response);

            Func<TestResponse?, bool> validator = r => r != null && r.Value == "test";

            // Act
            var result = await this._handler.GetWithValidationAsync(url, validateResponse: validator);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Value, Is.EqualTo("test"));
        }

        [Test]
        public async Task GetWithValidationAsync_WhenValidationFails_ReturnsNull()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var response = new TestResponse { Value = "test" };

            this._httpServiceMock
                .Setup(s => s.GetAsync<TestResponse>(url, null))
                .ReturnsAsync(response);

            Func<TestResponse?, bool> validator = r => false; // Always fails

            // Act
            var result = await this._handler.GetWithValidationAsync(url, validateResponse: validator);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetWithValidationAsync_WhenServiceThrowsInvalidOperationException_Rethrows()
        {
            // Arrange
            var url = new Uri("https://test.com/api");

            this._httpServiceMock
                .Setup(s => s.GetAsync<TestResponse>(url, null))
                .ThrowsAsync(new InvalidOperationException("Test error"));

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await this._handler.GetWithValidationAsync<TestResponse>(url));
        }

        [Test]
        public async Task GetWithValidationAsync_WhenServiceThrowsHttpRequestException_Rethrows()
        {
            // Arrange
            var url = new Uri("https://test.com/api");

            this._httpServiceMock
                .Setup(s => s.GetAsync<TestResponse>(url, null))
                .ThrowsAsync(new HttpRequestException("Network error"));

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(async () =>
                await this._handler.GetWithValidationAsync<TestResponse>(url));
        }

        #endregion

        #region PostWithValidationAsync Tests

        [Test]
        public async Task PostWithValidationAsync_WhenUrlIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var body = new TestRequest { Data = "test" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await this._handler.PostWithValidationAsync<TestRequest, TestResponse>(null!, body));
        }

        [Test]
        public async Task PostWithValidationAsync_WhenBodyIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var url = new Uri("https://test.com/api");

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await this._handler.PostWithValidationAsync<TestRequest, TestResponse>(url, null!));
        }

        [Test]
        public async Task PostWithValidationAsync_WhenRequestIsValid_ReturnsResponse()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var body = new TestRequest { Data = "test" };
            var expectedResponse = new TestResponse { Value = "response" };

            this._httpServiceMock
                .Setup(s => s.PostAsync<TestRequest, TestResponse>(url, body, null))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await this._handler.PostWithValidationAsync<TestRequest, TestResponse>(url, body);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Value, Is.EqualTo("response"));
            this._httpServiceMock.Verify(s => s.PostAsync<TestRequest, TestResponse>(url, body, null), Times.Once);
        }

        [Test]
        public async Task PostWithValidationAsync_WhenRequestValidationFails_ThrowsArgumentException()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var body = new TestRequest { Data = "test" };

            Func<TestRequest, bool> requestValidator = r => false; // Always fails

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await this._handler.PostWithValidationAsync<TestRequest, TestResponse>(
                    url,
                    body,
                    validateRequest: requestValidator));
        }

        [Test]
        public async Task PostWithValidationAsync_WhenRequestValidationPasses_CallsService()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var body = new TestRequest { Data = "test" };
            var expectedResponse = new TestResponse { Value = "response" };

            this._httpServiceMock
                .Setup(s => s.PostAsync<TestRequest, TestResponse>(url, body, null))
                .ReturnsAsync(expectedResponse);

            Func<TestRequest, bool> requestValidator = r => r.Data == "test";

            // Act
            var result = await this._handler.PostWithValidationAsync<TestRequest, TestResponse>(
                url,
                body,
                validateRequest: requestValidator);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            this._httpServiceMock.Verify(s => s.PostAsync<TestRequest, TestResponse>(url, body, null), Times.Once);
        }

        [Test]
        public async Task PostWithValidationAsync_WhenResponseValidationFails_ReturnsNull()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var body = new TestRequest { Data = "test" };
            var response = new TestResponse { Value = "response" };

            this._httpServiceMock
                .Setup(s => s.PostAsync<TestRequest, TestResponse>(url, body, null))
                .ReturnsAsync(response);

            Func<TestResponse?, bool> responseValidator = r => false; // Always fails

            // Act
            var result = await this._handler.PostWithValidationAsync<TestRequest, TestResponse>(
                url,
                body,
                validateResponse: responseValidator);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task PostWithValidationAsync_WithBearerToken_PassesTokenToService()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var body = new TestRequest { Data = "test" };
            var token = "test-token";
            var expectedResponse = new TestResponse { Value = "response" };

            this._httpServiceMock
                .Setup(s => s.PostAsync<TestRequest, TestResponse>(url, body, token))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await this._handler.PostWithValidationAsync<TestRequest, TestResponse>(url, body, token);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            this._httpServiceMock.Verify(s => s.PostAsync<TestRequest, TestResponse>(url, body, token), Times.Once);
        }

        #endregion

        #region GetMultipleAsync Tests

        [Test]
        public async Task GetMultipleAsync_WhenUrlsIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await this._handler.GetMultipleAsync<TestResponse>(null!));
        }

        [Test]
        public async Task GetMultipleAsync_WhenUrlsIsEmpty_ReturnsEmptyList()
        {
            // Arrange
            var urls = new List<Uri>();

            // Act
            var result = await this._handler.GetMultipleAsync<TestResponse>(urls);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult, Is.Empty);
            this._httpServiceMock.Verify(s => s.GetAsync<TestResponse>(It.IsAny<Uri>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public async Task GetMultipleAsync_WithMultipleUrls_ReturnsAllResponses()
        {
            // Arrange
            var urls = new List<Uri>
            {
                new Uri("https://test.com/api1"),
                new Uri("https://test.com/api2"),
                new Uri("https://test.com/api3"),
            };

            var responses = new[]
            {
                new TestResponse { Value = "response1" },
                new TestResponse { Value = "response2" },
                new TestResponse { Value = "response3" },
            };

            this._httpServiceMock
                .Setup(s => s.GetAsync<TestResponse>(urls[0], null))
                .ReturnsAsync(responses[0]);

            this._httpServiceMock
                .Setup(s => s.GetAsync<TestResponse>(urls[1], null))
                .ReturnsAsync(responses[1]);

            this._httpServiceMock
                .Setup(s => s.GetAsync<TestResponse>(urls[2], null))
                .ReturnsAsync(responses[2]);

            // Act
            var result = await this._handler.GetMultipleAsync<TestResponse>(urls);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Count, Is.EqualTo(3));
            Assert.That(nonNullResult[0]!.Value, Is.EqualTo("response1"));
            Assert.That(nonNullResult[1]!.Value, Is.EqualTo("response2"));
            Assert.That(nonNullResult[2]!.Value, Is.EqualTo("response3"));
        }

        [Test]
        public async Task GetMultipleAsync_WhenSomeRequestsFail_ReturnsNullForFailedRequests()
        {
            // Arrange
            var urls = new List<Uri>
            {
                new Uri("https://test.com/api1"),
                new Uri("https://test.com/api2"),
            };

            this._httpServiceMock
                .Setup(s => s.GetAsync<TestResponse>(urls[0], null))
                .ReturnsAsync(new TestResponse { Value = "response1" });

            this._httpServiceMock
                .Setup(s => s.GetAsync<TestResponse>(urls[1], null))
                .ReturnsAsync((TestResponse?)null);

            // Act
            var result = await this._handler.GetMultipleAsync<TestResponse>(urls);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Count, Is.EqualTo(2));
            Assert.That(nonNullResult[0], Is.Not.Null);
            Assert.That(nonNullResult[1], Is.Null);
        }

        #endregion

        #region GetWithRetryAsync Tests

        [Test]
        public async Task GetWithRetryAsync_WhenUrlIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await this._handler.GetWithRetryAsync<TestResponse>(null!));
        }

        [Test]
        public async Task GetWithRetryAsync_WhenMaxRetriesIsZero_ThrowsArgumentException()
        {
            // Arrange
            var url = new Uri("https://test.com/api");

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await this._handler.GetWithRetryAsync<TestResponse>(url, maxRetries: 0));
        }

        [Test]
        public async Task GetWithRetryAsync_WhenMaxRetriesIsNegative_ThrowsArgumentException()
        {
            // Arrange
            var url = new Uri("https://test.com/api");

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await this._handler.GetWithRetryAsync<TestResponse>(url, maxRetries: -1));
        }

        [Test]
        public async Task GetWithRetryAsync_WhenDelayIsNegative_ThrowsArgumentException()
        {
            // Arrange
            var url = new Uri("https://test.com/api");

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await this._handler.GetWithRetryAsync<TestResponse>(url, delayMs: -1));
        }

        [Test]
        public async Task GetWithRetryAsync_WhenFirstAttemptSucceeds_ReturnsResponse()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var expectedResponse = new TestResponse { Value = "test" };

            this._httpServiceMock
                .Setup(s => s.GetAsync<TestResponse>(url, null))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await this._handler.GetWithRetryAsync<TestResponse>(url, maxRetries: 3);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Value, Is.EqualTo("test"));
            this._httpServiceMock.Verify(s => s.GetAsync<TestResponse>(url, null), Times.Once);
        }

        [Test]
        public async Task GetWithRetryAsync_WhenSecondAttemptSucceeds_ReturnsResponse()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var expectedResponse = new TestResponse { Value = "test" };

            this._httpServiceMock
                .SetupSequence(s => s.GetAsync<TestResponse>(url, null))
                .ThrowsAsync(new HttpRequestException("Network error"))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await this._handler.GetWithRetryAsync<TestResponse>(url, maxRetries: 3, delayMs: 10);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Value, Is.EqualTo("test"));
            this._httpServiceMock.Verify(s => s.GetAsync<TestResponse>(url, null), Times.Exactly(2));
        }

        [Test]
        public async Task GetWithRetryAsync_WhenAllAttemptsFailWithHttpRequestException_ThrowsException()
        {
            // Arrange
            var url = new Uri("https://test.com/api");

            this._httpServiceMock
                .Setup(s => s.GetAsync<TestResponse>(url, null))
                .ThrowsAsync(new HttpRequestException("Network error"));

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(async () =>
                await this._handler.GetWithRetryAsync<TestResponse>(url, maxRetries: 3, delayMs: 10));

            this._httpServiceMock.Verify(s => s.GetAsync<TestResponse>(url, null), Times.Exactly(3));
        }

        [Test]
        public async Task GetWithRetryAsync_WhenInvalidOperationException_ThrowsImmediately()
        {
            // Arrange
            var url = new Uri("https://test.com/api");

            this._httpServiceMock
                .Setup(s => s.GetAsync<TestResponse>(url, null))
                .ThrowsAsync(new InvalidOperationException("Invalid operation"));

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await this._handler.GetWithRetryAsync<TestResponse>(url, maxRetries: 3));

            this._httpServiceMock.Verify(s => s.GetAsync<TestResponse>(url, null), Times.Once); // No retry on InvalidOperationException
        }

        #endregion

        #region ExecuteCustomRequestAsync Tests

        [Test]
        public async Task ExecuteCustomRequestAsync_WhenRequestIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await this._handler.ExecuteCustomRequestAsync<TestResponse>(null!));
        }

        [Test]
        public async Task ExecuteCustomRequestAsync_WhenRequestIsValid_ReturnsResponse()
        {
            // Arrange
            var request = new HttpRequest
            {
                Url = new Uri("https://test.com/api"),
                Method = HttpMethod.Get,
            };

            var expectedResponse = new HttpApiResponse<TestResponse>
            {
                Data = new TestResponse { Value = "test" },
                StatusCode = HttpStatusCode.OK,
                ResponseTimeMs = 100,
            };

            this._httpServiceMock
                .Setup(s => s.SendCustomAsync<TestResponse>(request))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await this._handler.ExecuteCustomRequestAsync<TestResponse>(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.IsSuccess, Is.True);
            Assert.That(nonNullResult.Data!.Value, Is.EqualTo("test"));
            this._httpServiceMock.Verify(s => s.SendCustomAsync<TestResponse>(request), Times.Once);
        }

        [Test]
        public async Task ExecuteCustomRequestAsync_WithProcessResponse_ProcessesResponse()
        {
            // Arrange
            var request = new HttpRequest
            {
                Url = new Uri("https://test.com/api"),
                Method = HttpMethod.Get,
            };

            var originalResponse = new HttpApiResponse<TestResponse>
            {
                Data = new TestResponse { Value = "original" },
                StatusCode = HttpStatusCode.OK,
            };

            this._httpServiceMock
                .Setup(s => s.SendCustomAsync<TestResponse>(request))
                .ReturnsAsync(originalResponse);

            Func<HttpApiResponse<TestResponse>, Task<HttpApiResponse<TestResponse>>> processor = async response =>
            {
                response.Data!.Value = "processed";
                return await Task.FromResult(response);
            };

            // Act
            var result = await this._handler.ExecuteCustomRequestAsync(request, processor);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Data!.Value, Is.EqualTo("processed"));
        }

        [Test]
        public async Task ExecuteCustomRequestAsync_WhenServiceThrowsException_Rethrows()
        {
            // Arrange
            var request = new HttpRequest
            {
                Url = new Uri("https://test.com/api"),
                Method = HttpMethod.Get,
            };

            this._httpServiceMock
                .Setup(s => s.SendCustomAsync<TestResponse>(request))
                .ThrowsAsync(new HttpRequestException("Network error"));

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(async () =>
                await this._handler.ExecuteCustomRequestAsync<TestResponse>(request));
        }

        #endregion

        private sealed class TestRequest
        {
            public string Data { get; set; } = string.Empty;
        }

        private sealed class TestResponse
        {
            public string Value { get; set; } = string.Empty;
        }
    }
}
