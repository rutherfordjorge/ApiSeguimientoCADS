// <copyright file="HttpServiceTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Tests.Services
{
    using ApiSeguimientoCADS.Api.Models.Requests.Http;
    using ApiSeguimientoCADS.Api.Models.Responses.Http;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using ApiSeguimientoCADS.Api.Services.Models;
    using Moq;
    using NUnit.Framework;
    using Polly;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Pruebas unitarias para <see cref="HttpService"/>.
    /// </summary>
    [TestFixture]
    public sealed class HttpServiceTests
    {
        private Mock<IHttpClientService> _httpClientServiceMock = null!;
        private Mock<IAppLogger<HttpService>> _loggerMock = null!;
        private Mock<IResiliencePolicyService> _resiliencePolicyServiceMock = null!;
        private HttpService _service = null!;

        [SetUp]
        public void SetUp()
        {
            this._httpClientServiceMock = new Mock<IHttpClientService>();
            this._loggerMock = new Mock<IAppLogger<HttpService>>();
            this._resiliencePolicyServiceMock = new Mock<IResiliencePolicyService>();

            // Setup default pipelines
            var defaultPipeline = new ResiliencePipelineBuilder().Build();
            this._resiliencePolicyServiceMock.Setup(r => r.CircuitBreakerPipeline).Returns(defaultPipeline);

            this._service = new HttpService(
                this._httpClientServiceMock.Object,
                this._loggerMock.Object,
                this._resiliencePolicyServiceMock.Object);
        }

        [Test]
        public void Constructor_WhenHttpClientServiceIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HttpService(
                null!,
                this._loggerMock.Object,
                this._resiliencePolicyServiceMock.Object));
        }

        [Test]
        public void Constructor_WhenLoggerIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HttpService(
                this._httpClientServiceMock.Object,
                null!,
                this._resiliencePolicyServiceMock.Object));
        }

        [Test]
        public void Constructor_WhenResiliencePolicyServiceIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HttpService(
                this._httpClientServiceMock.Object,
                this._loggerMock.Object,
                null!));
        }

        #region GetAsync Tests

        [Test]
        public async Task GetAsync_WhenUrlIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this._service.GetAsync<TestResponse>(null!));
        }

        [Test]
        public async Task GetAsync_WhenRequestIsSuccessful_ReturnsData()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var expectedData = new TestResponse { Value = "test" };
            var apiResponse = new ApiResponse<TestResponse>
            {
                Data = expectedData,
                StatusCode = HttpStatusCode.OK,
            };

            this._httpClientServiceMock
                .Setup(s => s.SendAsync<TestResponse>(It.IsAny<ApiRequest>()))
                .ReturnsAsync(apiResponse);

            // Act
            var result = await this._service.GetAsync<TestResponse>(url);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result?.Value, Is.EqualTo("test"));
        }

        [Test]
        public async Task GetAsync_WhenRequestFails_ReturnsNull()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var apiResponse = new ApiResponse<TestResponse>
            {
                Data = null,
                StatusCode = HttpStatusCode.NotFound,
            };

            this._httpClientServiceMock
                .Setup(s => s.SendAsync<TestResponse>(It.IsAny<ApiRequest>()))
                .ReturnsAsync(apiResponse);

            // Act
            var result = await this._service.GetAsync<TestResponse>(url);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetAsync_WithBearerToken_PassesTokenToClient()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var token = "test-token";
            var expectedData = new TestResponse { Value = "test" };
            var apiResponse = new ApiResponse<TestResponse>
            {
                Data = expectedData,
                StatusCode = HttpStatusCode.OK,
            };

            ApiRequest? capturedRequest = null;

            this._httpClientServiceMock
                .Setup(s => s.SendAsync<TestResponse>(It.IsAny<ApiRequest>()))
                .Callback<ApiRequest>(req => capturedRequest = req)
                .ReturnsAsync(apiResponse);

            // Act
            await this._service.GetAsync<TestResponse>(url, token);

            // Assert
            Assert.That(capturedRequest, Is.Not.Null);
            var request = capturedRequest ?? throw new AssertionException("Expected API request to be captured.");
            Assert.That(request.BearerToken, Is.EqualTo(token));
            Assert.That(request.Method, Is.EqualTo(HttpMethod.Get));
        }

        #endregion

        #region PostAsync Tests

        [Test]
        public async Task PostAsync_WhenUrlIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var body = new TestRequest { Data = "test" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this._service.PostAsync<TestRequest, TestResponse>(null!, body));
        }

        [Test]
        public async Task PostAsync_WhenBodyIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var url = new Uri("https://test.com/api");

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this._service.PostAsync<TestRequest, TestResponse>(url, null!));
        }

        [Test]
        public async Task PostAsync_WhenRequestIsSuccessful_ReturnsData()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var body = new TestRequest { Data = "test" };
            var expectedData = new TestResponse { Value = "response" };
            var apiResponse = new ApiResponse<TestResponse>
            {
                Data = expectedData,
                StatusCode = HttpStatusCode.OK,
            };

            this._httpClientServiceMock
                .Setup(s => s.SendAsync<TestResponse>(It.IsAny<ApiRequest>()))
                .ReturnsAsync(apiResponse);

            // Act
            var result = await this._service.PostAsync<TestRequest, TestResponse>(url, body);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result?.Value, Is.EqualTo("response"));
        }

        #endregion

        #region PutAsync Tests

        [Test]
        public async Task PutAsync_WhenUrlIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var body = new TestRequest { Data = "test" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this._service.PutAsync<TestRequest, TestResponse>(null!, body));
        }

        [Test]
        public async Task PutAsync_WhenBodyIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var url = new Uri("https://test.com/api");

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this._service.PutAsync<TestRequest, TestResponse>(url, null!));
        }

        [Test]
        public async Task PutAsync_WhenRequestIsSuccessful_ReturnsData()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var body = new TestRequest { Data = "test" };
            var expectedData = new TestResponse { Value = "response" };
            var apiResponse = new ApiResponse<TestResponse>
            {
                Data = expectedData,
                StatusCode = HttpStatusCode.OK,
            };

            ApiRequest? capturedRequest = null;

            this._httpClientServiceMock
                .Setup(s => s.SendAsync<TestResponse>(It.IsAny<ApiRequest>()))
                .Callback<ApiRequest>(req => capturedRequest = req)
                .ReturnsAsync(apiResponse);

            // Act
            var result = await this._service.PutAsync<TestRequest, TestResponse>(url, body);

            // Assert
            Assert.That(result, Is.Not.Null);
            var request = capturedRequest ?? throw new AssertionException("Expected API request to be captured.");
            Assert.That(request.Method, Is.EqualTo(HttpMethod.Put));
        }

        #endregion

        #region DeleteAsync Tests

        [Test]
        public async Task DeleteAsync_WhenUrlIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this._service.DeleteAsync<TestResponse>(null!));
        }

        [Test]
        public async Task DeleteAsync_WhenRequestIsSuccessful_ReturnsData()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var expectedData = new TestResponse { Value = "deleted" };
            var apiResponse = new ApiResponse<TestResponse>
            {
                Data = expectedData,
                StatusCode = HttpStatusCode.OK,
            };

            ApiRequest? capturedRequest = null;

            this._httpClientServiceMock
                .Setup(s => s.SendAsync<TestResponse>(It.IsAny<ApiRequest>()))
                .Callback<ApiRequest>(req => capturedRequest = req)
                .ReturnsAsync(apiResponse);

            // Act
            var result = await this._service.DeleteAsync<TestResponse>(url);

            // Assert
            Assert.That(result, Is.Not.Null);
            var request = capturedRequest ?? throw new AssertionException("Expected API request to be captured.");
            Assert.That(request.Method, Is.EqualTo(HttpMethod.Delete));
        }

        #endregion

        #region SendCustomAsync Tests

        [Test]
        public async Task SendCustomAsync_WhenRequestIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this._service.SendCustomAsync<TestResponse>(null!));
        }

        [Test]
        public async Task SendCustomAsync_WhenRequestIsValid_ReturnsFullResponse()
        {
            // Arrange
            var request = new HttpRequest
            {
                Url = new Uri("https://test.com/api"),
                Method = HttpMethod.Get,
            };

            var expectedData = new TestResponse { Value = "test" };
            var apiResponse = new ApiResponse<TestResponse>
            {
                Data = expectedData,
                StatusCode = HttpStatusCode.OK,
            };

            this._httpClientServiceMock
                .Setup(s => s.SendAsync<TestResponse>(It.IsAny<ApiRequest>()))
                .ReturnsAsync(apiResponse);

            // Act
            var result = await this._service.SendCustomAsync<TestResponse>(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result?.IsSuccess, Is.True);
            Assert.That(result?.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(result?.Data, Is.Not.Null);
            Assert.That(result?.Data?.Value, Is.EqualTo("test"));
        }

        [Test]
        public async Task SendCustomAsync_WhenRequestFails_ReturnsFailedResponse()
        {
            // Arrange
            var request = new HttpRequest
            {
                Url = new Uri("https://test.com/api"),
                Method = HttpMethod.Get,
            };

            var apiResponse = new ApiResponse<TestResponse>
            {
                Data = null,
                StatusCode = HttpStatusCode.BadRequest,
            };

            this._httpClientServiceMock
                .Setup(s => s.SendAsync<TestResponse>(It.IsAny<ApiRequest>()))
                .ReturnsAsync(apiResponse);

            // Act
            var result = await this._service.SendCustomAsync<TestResponse>(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        #endregion

        #region GetWithHeadersAsync Tests

        [Test]
        public async Task GetWithHeadersAsync_WhenUrlIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this._service.GetWithHeadersAsync<TestResponse>(null!));
        }

        [Test]
        public async Task GetWithHeadersAsync_WithCustomHeaders_IncludesHeaders()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var customHeaders = new Dictionary<string, string>
            {
                ["X-Custom-Header"] = "custom-value",
                ["X-Another-Header"] = "another-value",
            };

            var expectedData = new TestResponse { Value = "test" };
            var apiResponse = new ApiResponse<TestResponse>
            {
                Data = expectedData,
                StatusCode = HttpStatusCode.OK,
            };

            ApiRequest? capturedRequest = null;

            this._httpClientServiceMock
                .Setup(s => s.SendAsync<TestResponse>(It.IsAny<ApiRequest>()))
                .Callback<ApiRequest>(req => capturedRequest = req)
                .ReturnsAsync(apiResponse);

            // Act
            var result = await this._service.GetWithHeadersAsync<TestResponse>(url, customHeaders: customHeaders);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(capturedRequest, Is.Not.Null);
            var requestWithHeaders = capturedRequest ?? throw new AssertionException("Expected API request to be captured.");
            Assert.That(requestWithHeaders.Headers.ContainsKey("X-Custom-Header"), Is.True);
            Assert.That(requestWithHeaders.Headers["X-Custom-Header"], Is.EqualTo("custom-value"));
        }

        #endregion

        #region PostWithHeadersAsync Tests

        [Test]
        public async Task PostWithHeadersAsync_WhenUrlIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var body = new TestRequest { Data = "test" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this._service.PostWithHeadersAsync<TestRequest, TestResponse>(null!, body));
        }

        [Test]
        public async Task PostWithHeadersAsync_WhenBodyIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var url = new Uri("https://test.com/api");

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this._service.PostWithHeadersAsync<TestRequest, TestResponse>(url, null!));
        }

        [Test]
        public async Task PostWithHeadersAsync_WithCustomHeaders_IncludesHeaders()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var body = new TestRequest { Data = "test" };
            var customHeaders = new Dictionary<string, string>
            {
                ["X-Custom-Header"] = "custom-value",
            };

            var expectedData = new TestResponse { Value = "response" };
            var apiResponse = new ApiResponse<TestResponse>
            {
                Data = expectedData,
                StatusCode = HttpStatusCode.OK,
            };

            ApiRequest? capturedRequest = null;

            this._httpClientServiceMock
                .Setup(s => s.SendAsync<TestResponse>(It.IsAny<ApiRequest>()))
                .Callback<ApiRequest>(req => capturedRequest = req)
                .ReturnsAsync(apiResponse);

            // Act
            var result = await this._service.PostWithHeadersAsync<TestRequest, TestResponse>(
                url,
                body,
                customHeaders: customHeaders);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(capturedRequest, Is.Not.Null);
            var requestWithHeaders = capturedRequest ?? throw new AssertionException("Expected API request to be captured.");
            Assert.That(requestWithHeaders.Headers.ContainsKey("X-Custom-Header"), Is.True);
            Assert.That(requestWithHeaders.Method, Is.EqualTo(HttpMethod.Post));
        }

        #endregion

        #region GetWithCircuitBreakerAsync Tests

        [Test]
        public async Task GetWithCircuitBreakerAsync_WhenUrlIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this._service.GetWithCircuitBreakerAsync<TestResponse>(null!));
        }

        [Test]
        public async Task GetWithCircuitBreakerAsync_WhenRequestIsSuccessful_ReturnsResponse()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var expectedData = new TestResponse { Value = "test" };
            var apiResponse = new ApiResponse<TestResponse>
            {
                Data = expectedData,
                StatusCode = HttpStatusCode.OK,
            };

            this._httpClientServiceMock
                .Setup(s => s.SendWithoutRetryAsync<TestResponse>(It.IsAny<ApiRequest>()))
                .ReturnsAsync(apiResponse);

            // Act
            var result = await this._service.GetWithCircuitBreakerAsync<TestResponse>(url);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result?.IsSuccess, Is.True);
            Assert.That(result?.Data, Is.Not.Null);
            Assert.That(result?.Data?.Value, Is.EqualTo("test"));
        }

        [Test]
        public async Task GetWithCircuitBreakerAsync_UsesCircuitBreakerPipeline()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var expectedData = new TestResponse { Value = "test" };
            var apiResponse = new ApiResponse<TestResponse>
            {
                Data = expectedData,
                StatusCode = HttpStatusCode.OK,
            };

            var circuitBreakerPipeline = new ResiliencePipelineBuilder().Build();
            this._resiliencePolicyServiceMock.Setup(r => r.CircuitBreakerPipeline).Returns(circuitBreakerPipeline);

            this._httpClientServiceMock
                .Setup(s => s.SendWithoutRetryAsync<TestResponse>(It.IsAny<ApiRequest>()))
                .ReturnsAsync(apiResponse);

            // Act
            var result = await this._service.GetWithCircuitBreakerAsync<TestResponse>(url);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.True);
            this._resiliencePolicyServiceMock.Verify(r => r.CircuitBreakerPipeline, Times.Once);
        }

        #endregion

        #region PostWithCircuitBreakerAsync Tests

        [Test]
        public async Task PostWithCircuitBreakerAsync_WhenUrlIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var body = new TestRequest { Data = "test" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this._service.PostWithCircuitBreakerAsync<TestRequest, TestResponse>(null!, body));
        }

        [Test]
        public async Task PostWithCircuitBreakerAsync_WhenBodyIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var url = new Uri("https://test.com/api");

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this._service.PostWithCircuitBreakerAsync<TestRequest, TestResponse>(url, null!));
        }

        [Test]
        public async Task PostWithCircuitBreakerAsync_WhenRequestIsSuccessful_ReturnsResponse()
        {
            // Arrange
            var url = new Uri("https://test.com/api");
            var body = new TestRequest { Data = "test" };
            var expectedData = new TestResponse { Value = "response" };
            var apiResponse = new ApiResponse<TestResponse>
            {
                Data = expectedData,
                StatusCode = HttpStatusCode.OK,
            };

            this._httpClientServiceMock
                .Setup(s => s.SendWithoutRetryAsync<TestResponse>(It.IsAny<ApiRequest>()))
                .ReturnsAsync(apiResponse);

            // Act
            var result = await this._service.PostWithCircuitBreakerAsync<TestRequest, TestResponse>(url, body);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result?.IsSuccess, Is.True);
            Assert.That(result?.Data, Is.Not.Null);
            Assert.That(result?.Data?.Value, Is.EqualTo("response"));
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
