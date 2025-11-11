// <copyright file="HttpClientServiceTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Tests.Services
{
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using ApiSeguimientoCADS.Api.Services.Models;
    using Moq;
    using Moq.Protected;
    using NUnit.Framework;
    using Polly;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Pruebas unitarias para <see cref="HttpClientService"/>.
    /// </summary>
    [TestFixture]
    public sealed class HttpClientServiceTests
    {
        private Mock<HttpMessageHandler> _httpMessageHandlerMock = null!;
        private HttpClient _httpClient = null!;
        private Mock<IAppLogger<HttpClientService>> _loggerMock = null!;
        private Mock<IResiliencePolicyService> _resiliencePolicyServiceMock = null!;
        private HttpClientService _service = null!;

        [SetUp]
        public void SetUp()
        {
            this._httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            this._httpClient = new HttpClient(this._httpMessageHandlerMock.Object);
            this._loggerMock = new Mock<IAppLogger<HttpClientService>>();
            this._resiliencePolicyServiceMock = new Mock<IResiliencePolicyService>();

            // Setup default retry pipeline
            var retryPipeline = new ResiliencePipelineBuilder().Build();
            this._resiliencePolicyServiceMock.Setup(r => r.RetryPipeline).Returns(retryPipeline);

            this._service = new HttpClientService(
                this._httpClient,
                this._loggerMock.Object,
                this._resiliencePolicyServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this._httpClient?.Dispose();
        }

        [Test]
        public void Constructor_WhenHttpClientIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HttpClientService(
                null!,
                this._loggerMock.Object,
                this._resiliencePolicyServiceMock.Object));
        }

        [Test]
        public void Constructor_WhenLoggerIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HttpClientService(
                this._httpClient,
                null!,
                this._resiliencePolicyServiceMock.Object));
        }

        [Test]
        public void Constructor_WhenResiliencePolicyServiceIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HttpClientService(
                this._httpClient,
                this._loggerMock.Object,
                null!));
        }

        #region SendAsync Tests

        [Test]
        public async Task SendAsync_WhenRequestIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await this._service.SendAsync<TestResponse>(null!));
        }

        [Test]
        public async Task SendAsync_WhenRequestIsSuccessful_ReturnsData()
        {
            // Arrange
            var request = new ApiRequest
            {
                Url = new Uri("https://test.com/api"),
                Method = HttpMethod.Get,
            };

            var responseData = new TestResponse { Value = "test" };
            var responseJson = JsonSerializer.Serialize(responseData);

            this._httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseJson),
                });

            // Act
            var result = await this._service.SendAsync<TestResponse>(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data!.Value, Is.EqualTo("test"));
        }

        [Test]
        public async Task SendAsync_WhenResponseIsNotSuccessful_ReturnsFailedResponse()
        {
            // Arrange
            var request = new ApiRequest
            {
                Url = new Uri("https://test.com/api"),
                Method = HttpMethod.Get,
            };

            this._httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("Error message"),
                });

            // Act
            var result = await this._service.SendAsync<TestResponse>(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task SendAsync_WithPostMethod_IncludesBodyInRequest()
        {
            // Arrange
            var requestBody = new { Data = "test-data" };
            var request = new ApiRequest
            {
                Url = new Uri("https://test.com/api"),
                Method = HttpMethod.Post,
                Body = requestBody,
            };

            var responseData = new TestResponse { Value = "response" };
            var responseJson = JsonSerializer.Serialize(responseData);

            HttpRequestMessage? capturedRequest = null;

            this._httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback<HttpRequestMessage, CancellationToken>((req, ct) => capturedRequest = req)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseJson),
                });

            // Act
            var result = await this._service.SendAsync<TestResponse>(request);

            // Assert
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(capturedRequest, Is.Not.Null);
            Assert.That(capturedRequest!.Method, Is.EqualTo(HttpMethod.Post));
            Assert.That(capturedRequest.Content, Is.Not.Null);
        }

        [Test]
        public async Task SendAsync_WithBearerToken_IncludesAuthorizationHeader()
        {
            // Arrange
            var request = new ApiRequest
            {
                Url = new Uri("https://test.com/api"),
                Method = HttpMethod.Get,
                BearerToken = "test-token",
            };

            var responseData = new TestResponse { Value = "test" };
            var responseJson = JsonSerializer.Serialize(responseData);

            HttpRequestMessage? capturedRequest = null;

            this._httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback<HttpRequestMessage, CancellationToken>((req, ct) => capturedRequest = req)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseJson),
                });

            // Act
            await this._service.SendAsync<TestResponse>(request);

            // Assert
            Assert.That(capturedRequest, Is.Not.Null);
            Assert.That(capturedRequest!.Headers.Authorization, Is.Not.Null);
            Assert.That(capturedRequest.Headers.Authorization!.Scheme, Is.EqualTo("Bearer"));
            Assert.That(capturedRequest.Headers.Authorization.Parameter, Is.EqualTo("test-token"));
        }

        [Test]
        public async Task SendAsync_WithCustomHeaders_IncludesHeadersInRequest()
        {
            // Arrange
            var request = new ApiRequest
            {
                Url = new Uri("https://test.com/api"),
                Method = HttpMethod.Get,
            };
            request.Headers["X-Custom-Header"] = "custom-value";
            request.Headers["X-Another-Header"] = "another-value";

            var responseData = new TestResponse { Value = "test" };
            var responseJson = JsonSerializer.Serialize(responseData);

            HttpRequestMessage? capturedRequest = null;

            this._httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback<HttpRequestMessage, CancellationToken>((req, ct) => capturedRequest = req)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseJson),
                });

            // Act
            await this._service.SendAsync<TestResponse>(request);

            // Assert
            Assert.That(capturedRequest, Is.Not.Null);
            Assert.That(capturedRequest!.Headers.Contains("X-Custom-Header"), Is.True);
            Assert.That(capturedRequest.Headers.GetValues("X-Custom-Header"), Does.Contain("custom-value"));
        }

        [Test]
        public async Task SendAsync_WithEmptyDataResponse_ReplacesWithEmptyArray()
        {
            // Arrange
            var request = new ApiRequest
            {
                Url = new Uri("https://test.com/api"),
                Method = HttpMethod.Get,
            };

            // Response with empty string in data field
            var responseJson = "{\"data\":\"\"}";

            this._httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseJson),
                });

            // Act
            var result = await this._service.SendAsync<TestResponse>(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.True);
        }

        #endregion

        #region SendWithoutRetryAsync Tests

        [Test]
        public async Task SendWithoutRetryAsync_WhenRequestIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await this._service.SendWithoutRetryAsync<TestResponse>(null!));
        }

        [Test]
        public async Task SendWithoutRetryAsync_WhenRequestIsSuccessful_ReturnsData()
        {
            // Arrange
            var request = new ApiRequest
            {
                Url = new Uri("https://test.com/api"),
                Method = HttpMethod.Get,
            };

            var responseData = new TestResponse { Value = "test" };
            var responseJson = JsonSerializer.Serialize(responseData);

            this._httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseJson),
                });

            // Act
            var result = await this._service.SendWithoutRetryAsync<TestResponse>(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data!.Value, Is.EqualTo("test"));
        }

        [Test]
        public async Task SendWithoutRetryAsync_DoesNotUseRetryPipeline()
        {
            // Arrange
            var request = new ApiRequest
            {
                Url = new Uri("https://test.com/api"),
                Method = HttpMethod.Get,
            };

            var responseData = new TestResponse { Value = "test" };
            var responseJson = JsonSerializer.Serialize(responseData);

            this._httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseJson),
                });

            // Act
            await this._service.SendWithoutRetryAsync<TestResponse>(request);

            // Assert
            // Verify RetryPipeline was not accessed
            this._resiliencePolicyServiceMock.Verify(r => r.RetryPipeline, Times.Never);
        }

        #endregion

        #region PostAsync Tests

        [Test]
        public async Task PostAsync_WhenRequestIsSuccessful_ReturnsResponseBody()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var jsonBody = "{\"data\":\"test\"}";
            var headers = new Dictionary<string, string>
            {
                ["X-Custom-Header"] = "test-value",
            };

            var responseJson = "{\"result\":\"success\"}";

            this._httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseJson),
                });

            // Act
            var result = await this._service.PostAsync(url, jsonBody, headers);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(responseJson));
        }

        [Test]
        public async Task PostAsync_WhenRequestFails_ThrowsHttpRequestException()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var jsonBody = "{\"data\":\"test\"}";

            this._httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent("Server error"),
                });

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(async () =>
                await this._service.PostAsync(url, jsonBody));
        }

        #endregion

        #region Exception Handling Tests

        [Test]
        public async Task SendAsync_WhenTaskCanceledException_ReturnsTimeoutResponse()
        {
            // Arrange
            var request = new ApiRequest
            {
                Url = new Uri("https://test.com/api"),
                Method = HttpMethod.Get,
            };

            this._httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new TaskCanceledException("Request timeout"));

            // Act
            var result = await this._service.SendAsync<TestResponse>(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.RequestTimeout));
            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public async Task SendAsync_WhenHttpRequestException_ReturnsUnavailableResponse()
        {
            // Arrange
            var request = new ApiRequest
            {
                Url = new Uri("https://test.com/api"),
                Method = HttpMethod.Get,
            };

            this._httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new HttpRequestException("Network error"));

            // Act
            var result = await this._service.SendAsync<TestResponse>(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.ServiceUnavailable));
            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public async Task SendAsync_WhenJsonException_ReturnsBadGatewayResponse()
        {
            // Arrange
            var request = new ApiRequest
            {
                Url = new Uri("https://test.com/api"),
                Method = HttpMethod.Get,
            };

            // Return invalid JSON
            this._httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("invalid json {{{"),
                });

            // Act
            var result = await this._service.SendAsync<TestResponse>(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadGateway));
            Assert.That(result.IsSuccess, Is.False);
        }

        #endregion

        private sealed class TestResponse
        {
            public string Value { get; set; } = string.Empty;
        }
    }
}
