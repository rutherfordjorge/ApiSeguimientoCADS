// <copyright file="CadsServiceTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Tests.Services
{
    using ApiSeguimientoCADS.Api.Models.Enums;
    using ApiSeguimientoCADS.Api.Models.Requests.Cads;
    using ApiSeguimientoCADS.Api.Models.Responses.Cads;
    using ApiSeguimientoCADS.Api.Models.Responses.Http;
    using ApiSeguimientoCADS.Api.Models.Settings.ExternalApis;
    using ApiSeguimientoCADS.Api.Services;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using Microsoft.Extensions.Options;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// Pruebas unitarias para <see cref="CadsService"/>.
    /// </summary>
    [TestFixture]
    public sealed class CadsServiceTests
    {
        private Mock<IOptions<CadsSettings>> _settingsMock = null!;
        private Mock<IHttpService> _httpServiceMock = null!;
        private CadsService _cadsService = null!;

        [SetUp]
        public void SetUp()
        {
            this._settingsMock = new Mock<IOptions<CadsSettings>>();
            this._httpServiceMock = new Mock<IHttpService>();

            var settings = new CadsSettings
            {
                BasePath = "https://test.com",
                Endpoints = new ApiCadsEndpoints
                {
                    ValidarSessionID = "/api/validate",
                },
            };

            this._settingsMock.Setup(s => s.Value).Returns(settings);

            this._cadsService = new CadsService(
                this._settingsMock.Object,
                this._httpServiceMock.Object);
        }

        [Test]
        public void ValideUserAccess_WhenRequestIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await this._cadsService.ValideUserAccess(null!));
        }

        [Test]
        public async Task ValideUserAccess_WhenResponseIsSuccessful_ReturnsUserAccessResponse()
        {
            // Arrange
            var request = new ValidateAccessRequest
            {
                RutTitular = "12345678-9",
                SessionId = "test-session",
                Token = "test-token",
                Origen = EOrigen.Web,
            };

            var expectedResponse = new UserAccessResponse
            {
                Data = new UserDataResonse
                {
                    IdUsuario = 123,
                    Nombre = "Juan",
                    Apellido = "Pérez",
                    Email = "juan.perez@test.com",
                },
            };

            var httpResponse = new HttpApiResponse<UserAccessResponse>
            {
                Data = expectedResponse,
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
            };

            this._httpServiceMock
                .Setup(h => h.GetWithCircuitBreakerAsync<UserAccessResponse>(It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(httpResponse);

            // Act
            var result = await this._cadsService.ValideUserAccess(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Data, Is.Not.Null);
            Assert.That(result.Data!.IdUsuario, Is.EqualTo(123));
        }

        [Test]
        public async Task ValideUserAccess_WhenResponseIsUnauthorized_ReturnsNull()
        {
            // Arrange
            var request = new ValidateAccessRequest
            {
                RutTitular = "12345678-9",
                SessionId = "test-session",
                Token = "test-token",
                Origen = EOrigen.Web,
            };

            var httpResponse = new HttpApiResponse<UserAccessResponse>
            {
                StatusCode = HttpStatusCode.Unauthorized,
                IsSuccess = false,
            };

            this._httpServiceMock
                .Setup(h => h.GetWithCircuitBreakerAsync<UserAccessResponse>(It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(httpResponse);

            // Act
            var result = await this._cadsService.ValideUserAccess(request);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task ValideUserAccess_WhenResponseIsForbidden_ReturnsNull()
        {
            // Arrange
            var request = new ValidateAccessRequest
            {
                RutTitular = "12345678-9",
                SessionId = "test-session",
                Token = "test-token",
                Origen = EOrigen.Web,
            };

            var httpResponse = new HttpApiResponse<UserAccessResponse>
            {
                StatusCode = HttpStatusCode.Forbidden,
                IsSuccess = false,
            };

            this._httpServiceMock
                .Setup(h => h.GetWithCircuitBreakerAsync<UserAccessResponse>(It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(httpResponse);

            // Act
            var result = await this._cadsService.ValideUserAccess(request);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ValideUserAccess_WhenResponseIsNotSuccessful_ThrowsInvalidOperationException()
        {
            // Arrange
            var request = new ValidateAccessRequest
            {
                RutTitular = "12345678-9",
                SessionId = "test-session",
                Token = "test-token",
                Origen = EOrigen.Web,
            };

            var httpResponse = new HttpApiResponse<UserAccessResponse>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                IsSuccess = false,
                ErrorMessage = "Error interno",
            };

            this._httpServiceMock
                .Setup(h => h.GetWithCircuitBreakerAsync<UserAccessResponse>(It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(httpResponse);

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await this._cadsService.ValideUserAccess(request));
        }

        [Test]
        public void Constructor_WhenSettingsIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CadsService(
                null!,
                this._httpServiceMock.Object));
        }

        [Test]
        public void Constructor_WhenHttpServiceIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CadsService(
                this._settingsMock.Object,
                null!));
        }
    }
}
