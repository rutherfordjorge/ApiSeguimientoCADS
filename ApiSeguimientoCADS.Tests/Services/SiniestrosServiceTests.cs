// <copyright file="SiniestrosServiceTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Tests.Services
{
    using ApiSeguimientoCADS.Api.Models.Requests.Siniestros;
    using ApiSeguimientoCADS.Api.Models.Responses.Siniestros;
    using ApiSeguimientoCADS.Api.Models.Settings.ExternalApis;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using Microsoft.Extensions.Options;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Pruebas unitarias para <see cref="SiniestrosService"/>.
    /// </summary>
    [TestFixture]
    public sealed class SiniestrosServiceTests
    {
        private Mock<IOptions<EPSiniestroPorAseguradoSettings>> _siniestroPorAseguradoSettingsMock = null!;
        private Mock<IOptions<EPGetdatosdelsiniestroSettings>> _getdatosdelsiniestroSettingsMock = null!;
        private Mock<IHttpService> _httpServiceMock = null!;
        private Mock<IAppLogger<SiniestrosService>> _loggerMock = null!;
        private SiniestrosService _service = null!;

        [SetUp]
        public void SetUp()
        {
            this._siniestroPorAseguradoSettingsMock = new Mock<IOptions<EPSiniestroPorAseguradoSettings>>();
            this._getdatosdelsiniestroSettingsMock = new Mock<IOptions<EPGetdatosdelsiniestroSettings>>();
            this._httpServiceMock = new Mock<IHttpService>();
            this._loggerMock = new Mock<IAppLogger<SiniestrosService>>();

            var siniestroPorAseguradoSettings = new EPSiniestroPorAseguradoSettings
            {
                BasePath = "https://api.test.com/siniestros",
                Auth = "test-auth-token",
                TokenCABName = "TokenCAB",
                TokenCABValue = "token-value",
                CookieName = "CookieName",
                CookieValue = "cookie-value",
            };

            var getdatosdelsiniestroSettings = new EPGetdatosdelsiniestroSettings
            {
                BasePath = "https://api.test.com/detalle",
                Auth = "test-auth-token-2",
            };

            this._siniestroPorAseguradoSettingsMock.Setup(s => s.Value).Returns(siniestroPorAseguradoSettings);
            this._getdatosdelsiniestroSettingsMock.Setup(s => s.Value).Returns(getdatosdelsiniestroSettings);

            this._service = new SiniestrosService(
                this._siniestroPorAseguradoSettingsMock.Object,
                this._getdatosdelsiniestroSettingsMock.Object,
                this._httpServiceMock.Object,
                this._loggerMock.Object);
        }

        [Test]
        public void Constructor_WhenSiniestroPorAseguradoSettingsIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SiniestrosService(
                null!,
                this._getdatosdelsiniestroSettingsMock.Object,
                this._httpServiceMock.Object,
                this._loggerMock.Object));
        }

        [Test]
        public void Constructor_WhenGetdatosdelsiniestroSettingsIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SiniestrosService(
                this._siniestroPorAseguradoSettingsMock.Object,
                null!,
                this._httpServiceMock.Object,
                this._loggerMock.Object));
        }

        [Test]
        public void Constructor_WhenHttpServiceIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SiniestrosService(
                this._siniestroPorAseguradoSettingsMock.Object,
                this._getdatosdelsiniestroSettingsMock.Object,
                null!,
                this._loggerMock.Object));
        }

        [Test]
        public void Constructor_WhenLoggerIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SiniestrosService(
                this._siniestroPorAseguradoSettingsMock.Object,
                this._getdatosdelsiniestroSettingsMock.Object,
                this._httpServiceMock.Object,
                null!));
        }

        #region GetSiniestrosPorAsegurado Tests

        [Test]
        public async Task GetSiniestrosPorAsegurado_WhenRequestIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this._service.GetSiniestrosPorAsegurado(null!));
        }

        [Test]
        public async Task GetSiniestrosPorAsegurado_WhenRutAseguradoIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var request = new SiniestrosRequest { RutAsegurado = null! };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this._service.GetSiniestrosPorAsegurado(request));
        }

        [Test]
        public async Task GetSiniestrosPorAsegurado_WhenRequestIsValid_ReturnsResponse()
        {
            // Arrange
            var request = new SiniestrosRequest { RutAsegurado = "12345678" };
            var expectedResponse = new SiniestrosResponse
            {
                Data = new List<SiniestrosDataResponse>
                {
                    new SiniestrosDataResponse
                    {
                        NumeroSiniestro = 123,
                        Ramo = "VP",
                    },
                },
            };

            this._httpServiceMock
                .Setup(s => s.PostWithHeadersAsync<object, SiniestrosResponse>(
                    It.IsAny<Uri>(),
                    It.IsAny<object>(),
                    null,
                    It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await this._service.GetSiniestrosPorAsegurado(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result?.Data, Is.Not.Null);
            Assert.That(result?.Data, Has.Count.EqualTo(1));
            this._httpServiceMock.Verify(
                s => s.PostWithHeadersAsync<object, SiniestrosResponse>(
                    It.IsAny<Uri>(),
                    It.IsAny<object>(),
                    null,
                    It.IsAny<Dictionary<string, string>>()),
                Times.Once);
        }

        [Test]
        public async Task GetSiniestrosPorAsegurado_WhenServiceReturnsNull_ThrowsInvalidOperationException()
        {
            // Arrange
            var request = new SiniestrosRequest { RutAsegurado = "12345678" };

            this._httpServiceMock
                .Setup(s => s.PostWithHeadersAsync<object, SiniestrosResponse>(
                    It.IsAny<Uri>(),
                    It.IsAny<object>(),
                    null,
                    It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync((SiniestrosResponse?)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                this._service.GetSiniestrosPorAsegurado(request));
        }

        [Test]
        public async Task GetSiniestrosPorAsegurado_WhenBasePathIsEmpty_ThrowsInvalidOperationException()
        {
            // Arrange
            var invalidSettings = new EPSiniestroPorAseguradoSettings
            {
                BasePath = string.Empty,
                Auth = "test-auth",
                TokenCABName = "TokenCAB",
                TokenCABValue = "token-value",
                CookieName = "CookieName",
                CookieValue = "cookie-value",
            };

            this._siniestroPorAseguradoSettingsMock.Setup(s => s.Value).Returns(invalidSettings);

            var service = new SiniestrosService(
                this._siniestroPorAseguradoSettingsMock.Object,
                this._getdatosdelsiniestroSettingsMock.Object,
                this._httpServiceMock.Object,
                this._loggerMock.Object);

            var request = new SiniestrosRequest { RutAsegurado = "12345678" };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.GetSiniestrosPorAsegurado(request));
        }

        [Test]
        public async Task GetSiniestrosPorAsegurado_WhenBasePathIsInvalid_ThrowsInvalidOperationException()
        {
            // Arrange
            var invalidSettings = new EPSiniestroPorAseguradoSettings
            {
                BasePath = "not-a-valid-url",
                Auth = "test-auth",
                TokenCABName = "TokenCAB",
                TokenCABValue = "token-value",
                CookieName = "CookieName",
                CookieValue = "cookie-value",
            };

            this._siniestroPorAseguradoSettingsMock.Setup(s => s.Value).Returns(invalidSettings);

            var service = new SiniestrosService(
                this._siniestroPorAseguradoSettingsMock.Object,
                this._getdatosdelsiniestroSettingsMock.Object,
                this._httpServiceMock.Object,
                this._loggerMock.Object);

            var request = new SiniestrosRequest { RutAsegurado = "12345678" };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.GetSiniestrosPorAsegurado(request));
        }

        #endregion

        #region GetDatosDelSiniestro Tests

        [Test]
        public async Task GetDatosDelSiniestro_WhenRequestIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this._service.GetDatosDelSiniestro(null!));
        }

        [Test]
        public async Task GetDatosDelSiniestro_WhenINsinieIsZero_ThrowsArgumentException()
        {
            // Arrange
            var request = new SiniestrosDetRequest { INsinie = 0, INdocto = 100 };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>
                this._service.GetDatosDelSiniestro(request));
        }

        [Test]
        public async Task GetDatosDelSiniestro_WhenINsinieIsNegative_ThrowsArgumentException()
        {
            // Arrange
            var request = new SiniestrosDetRequest { INsinie = -1, INdocto = 100 };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>
                this._service.GetDatosDelSiniestro(request));
        }

        [Test]
        public async Task GetDatosDelSiniestro_WhenINdoctoIsZero_ThrowsArgumentException()
        {
            // Arrange
            var request = new SiniestrosDetRequest { INsinie = 100, INdocto = 0 };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>
                this._service.GetDatosDelSiniestro(request));
        }

        [Test]
        public async Task GetDatosDelSiniestro_WhenINdoctoIsNegative_ThrowsArgumentException()
        {
            // Arrange
            var request = new SiniestrosDetRequest { INsinie = 100, INdocto = -1 };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>
                this._service.GetDatosDelSiniestro(request));
        }

        [Test]
        public async Task GetDatosDelSiniestro_WhenRequestIsValid_ReturnsResponse()
        {
            // Arrange
            var request = new SiniestrosDetRequest { INsinie = 123, INdocto = 456 };
            var expectedResponse = new SiniestrosDetalleResponse
            {
                Data = new List<SiniestroDetalleDataResponse>
                {
                    new SiniestroDetalleDataResponse
                    {
                        Patente = "ABC123",
                    },
                },
            };

            this._httpServiceMock
                .Setup(s => s.GetWithHeadersAsync<SiniestrosDetalleResponse>(
                    It.IsAny<Uri>(),
                    null,
                    It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await this._service.GetDatosDelSiniestro(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result?.Data, Is.Not.Null);
            Assert.That(result?.Data, Has.Count.EqualTo(1));
            Assert.That(result?.Data?.ElementAt(0).Patente, Is.EqualTo("ABC123"));
        }

        [Test]
        public async Task GetDatosDelSiniestro_WhenServiceReturnsNull_ThrowsInvalidOperationException()
        {
            // Arrange
            var request = new SiniestrosDetRequest { INsinie = 123, INdocto = 456 };

            this._httpServiceMock
                .Setup(s => s.GetWithHeadersAsync<SiniestrosDetalleResponse>(
                    It.IsAny<Uri>(),
                    null,
                    It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync((SiniestrosDetalleResponse?)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                this._service.GetDatosDelSiniestro(request));
        }

        [Test]
        public async Task GetDatosDelSiniestro_WhenBasePathIsEmpty_ThrowsInvalidOperationException()
        {
            // Arrange
            var invalidSettings = new EPGetdatosdelsiniestroSettings
            {
                BasePath = string.Empty,
                Auth = "test-auth",
            };

            this._getdatosdelsiniestroSettingsMock.Setup(s => s.Value).Returns(invalidSettings);

            var service = new SiniestrosService(
                this._siniestroPorAseguradoSettingsMock.Object,
                this._getdatosdelsiniestroSettingsMock.Object,
                this._httpServiceMock.Object,
                this._loggerMock.Object);

            var request = new SiniestrosDetRequest { INsinie = 123, INdocto = 456 };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.GetDatosDelSiniestro(request));
        }

        [Test]
        public async Task GetDatosDelSiniestro_WhenBasePathIsInvalid_ThrowsInvalidOperationException()
        {
            // Arrange
            var invalidSettings = new EPGetdatosdelsiniestroSettings
            {
                BasePath = "not-a-valid-url",
                Auth = "test-auth",
            };

            this._getdatosdelsiniestroSettingsMock.Setup(s => s.Value).Returns(invalidSettings);

            var service = new SiniestrosService(
                this._siniestroPorAseguradoSettingsMock.Object,
                this._getdatosdelsiniestroSettingsMock.Object,
                this._httpServiceMock.Object,
                this._loggerMock.Object);

            var request = new SiniestrosDetRequest { INsinie = 123, INdocto = 456 };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.GetDatosDelSiniestro(request));
        }

        [Test]
        public async Task GetDatosDelSiniestro_IncludesAuthorizationHeaderWithBasicAuth()
        {
            // Arrange
            var request = new SiniestrosDetRequest { INsinie = 123, INdocto = 456 };
            var expectedResponse = new SiniestrosDetalleResponse
            {
                Data = new List<SiniestroDetalleDataResponse>(),
            };

            Dictionary<string, string>? capturedHeaders = null;

            this._httpServiceMock
                .Setup(s => s.GetWithHeadersAsync<SiniestrosDetalleResponse>(
                    It.IsAny<Uri>(),
                    null,
                    It.IsAny<Dictionary<string, string>>()))
                .Callback<Uri, string?, Dictionary<string, string>?>((url, token, headers) =>
                {
                    capturedHeaders = headers;
                })
                .ReturnsAsync(expectedResponse);

            // Act
            await this._service.GetDatosDelSiniestro(request);

            // Assert
            Assert.That(capturedHeaders, Is.Not.Null);
            var headers = capturedHeaders ?? throw new AssertionException("Expected headers to be captured.");
            Assert.That(headers.ContainsKey("Authorization"), Is.True);
            Assert.That(headers["Authorization"], Does.StartWith("Basic "));
        }

        [Test]
        public async Task GetDatosDelSiniestro_IncludesNSiniestroHeader()
        {
            // Arrange
            var request = new SiniestrosDetRequest { INsinie = 12345, INdocto = 456 };
            var expectedResponse = new SiniestrosDetalleResponse
            {
                Data = new List<SiniestroDetalleDataResponse>(),
            };

            Dictionary<string, string>? capturedHeaders = null;

            this._httpServiceMock
                .Setup(s => s.GetWithHeadersAsync<SiniestrosDetalleResponse>(
                    It.IsAny<Uri>(),
                    null,
                    It.IsAny<Dictionary<string, string>>()))
                .Callback<Uri, string?, Dictionary<string, string>?>((url, token, headers) =>
                {
                    capturedHeaders = headers;
                })
                .ReturnsAsync(expectedResponse);

            // Act
            await this._service.GetDatosDelSiniestro(request);

            // Assert
            Assert.That(capturedHeaders, Is.Not.Null);
            var headers = capturedHeaders ?? throw new AssertionException("Expected headers to be captured.");
            Assert.That(headers.ContainsKey("nSiniestro"), Is.True);
            Assert.That(headers["nSiniestro"], Is.EqualTo("12345"));
        }

        #endregion
    }
}
