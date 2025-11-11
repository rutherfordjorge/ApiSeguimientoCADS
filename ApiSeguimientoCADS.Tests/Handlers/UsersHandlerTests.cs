// <copyright file="UsersHandlerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Tests.Handlers
{
    using ApiSeguimientoCADS.Api.Handlers;
    using ApiSeguimientoCADS.Api.Models.Enums;
    using ApiSeguimientoCADS.Api.Models.Requests.Cads;
    using ApiSeguimientoCADS.Api.Models.Responses.Cads;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Pruebas unitarias para <see cref="UsersHandler"/>.
    /// </summary>
    [TestFixture]
    public sealed class UsersHandlerTests
    {
        private Mock<IAppLogger<UsersHandler>> _loggerMock = null!;
        private Mock<IConfiguration> _configurationMock = null!;
        private Mock<ICadsService> _cadsServiceMock = null!;
        private Mock<ITokenService> _tokenServiceMock = null!;
        private UsersHandler _handler = null!;

        [SetUp]
        public void SetUp()
        {
            this._loggerMock = new Mock<IAppLogger<UsersHandler>>();
            this._configurationMock = new Mock<IConfiguration>();
            this._cadsServiceMock = new Mock<ICadsService>();
            this._tokenServiceMock = new Mock<ITokenService>();

            this._configurationMock
                .Setup(c => c["Frontend:BaseUrl"])
                .Returns("https://frontend.test.com");

            this._handler = new UsersHandler(
                this._loggerMock.Object,
                this._configurationMock.Object,
                this._cadsServiceMock.Object,
                this._tokenServiceMock.Object);
        }

        [Test]
        public void GenerarUrlFrontend_WhenRequestIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await this._handler.GenerarUrlFrontend(null!));
        }

        [Test]
        public void GenerarUrlFrontend_WhenRutTitularIsEmpty_ThrowsArgumentException()
        {
            // Arrange
            var request = new ValidateAccessRequest
            {
                RutTitular = string.Empty,
                Origen = EOrigen.Web,
                Rol = ERol.Titular,
            };

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await this._handler.GenerarUrlFrontend(request));
        }

        [Test]
        public void GenerarUrlFrontend_WhenOrigenIsNone_ThrowsArgumentException()
        {
            // Arrange
            var request = new ValidateAccessRequest
            {
                RutTitular = "12345678-9",
                Origen = EOrigen.None,
                Rol = ERol.Titular,
            };

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await this._handler.GenerarUrlFrontend(request));
        }

        [Test]
        public void GenerarUrlFrontend_WhenRolIsNone_ThrowsArgumentException()
        {
            // Arrange
            var request = new ValidateAccessRequest
            {
                RutTitular = "12345678-9",
                Origen = EOrigen.Web,
                Rol = ERol.None,
            };

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await this._handler.GenerarUrlFrontend(request));
        }

        [Test]
        public async Task GenerarUrlFrontend_WhenUserAccessIsValid_ReturnsUrl()
        {
            // Arrange
            var request = new ValidateAccessRequest
            {
                RutTitular = "12345678-9",
                RutSolicitante = "12345678-9",
                Origen = EOrigen.Web,
                Rol = ERol.Titular,
                RutaOrigen = "test.com",
                Token = "test-token",
            };

            var userAccessResponse = new UserAccessResponse
            {
                Data = new UserDataResonse
                {
                    IdUsuario = 123,
                    Nombre = "Juan",
                    Apellido = "Pérez",
                    Email = "juan.perez@test.com",
                },
            };

            this._cadsServiceMock
                .Setup(s => s.ValideUserAccess(It.IsAny<ValidateAccessRequest>()))
                .ReturnsAsync(userAccessResponse);

            this._tokenServiceMock
                .Setup(t => t.GenerateToken(It.IsAny<Api.Models.Requests.TokenData>()))
                .Returns("generated-token");

            // Act
            var result = await this._handler.GenerarUrlFrontend(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Does.StartWith("https://"));
            this._cadsServiceMock.Verify(s => s.ValideUserAccess(request), Times.Once);
            this._tokenServiceMock.Verify(t => t.GenerateToken(It.IsAny<Api.Models.Requests.TokenData>()), Times.Once);
        }

        [Test]
        public async Task GenerarUrlFrontend_WhenUserAccessResponseIsNull_ReturnsRutaOrigen()
        {
            // Arrange
            var request = new ValidateAccessRequest
            {
                RutTitular = "12345678-9",
                Origen = EOrigen.Web,
                Rol = ERol.Titular,
                RutaOrigen = "test.com",
            };

            this._cadsServiceMock
                .Setup(s => s.ValideUserAccess(It.IsAny<ValidateAccessRequest>()))
                .ReturnsAsync((UserAccessResponse?)null);

            // Act
            var result = await this._handler.GenerarUrlFrontend(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Does.Contain("test.com"));
        }

        [Test]
        public void GenerarUrlFrontend_WhenFrontendBaseUrlIsNotConfigured_ThrowsInvalidOperationException()
        {
            // Arrange
            this._configurationMock
                .Setup(c => c["Frontend:BaseUrl"])
                .Returns((string?)null);

            var request = new ValidateAccessRequest
            {
                RutTitular = "12345678-9",
                Origen = EOrigen.Web,
                Rol = ERol.Titular,
                RutaOrigen = "test.com",
                Token = "test-token",
            };

            var userAccessResponse = new UserAccessResponse
            {
                Data = new UserDataResonse
                {
                    IdUsuario = 123,
                    Nombre = "Juan",
                    Apellido = "Pérez",
                    Email = "juan.perez@test.com",
                },
            };

            this._cadsServiceMock
                .Setup(s => s.ValideUserAccess(It.IsAny<ValidateAccessRequest>()))
                .ReturnsAsync(userAccessResponse);

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await this._handler.GenerarUrlFrontend(request));
        }

        [Test]
        public void Constructor_WhenLoggerIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersHandler(
                null!,
                this._configurationMock.Object,
                this._cadsServiceMock.Object,
                this._tokenServiceMock.Object));
        }

        [Test]
        public void Constructor_WhenConfigurationIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersHandler(
                this._loggerMock.Object,
                null!,
                this._cadsServiceMock.Object,
                this._tokenServiceMock.Object));
        }

        [Test]
        public void Constructor_WhenCadsServiceIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersHandler(
                this._loggerMock.Object,
                this._configurationMock.Object,
                null!,
                this._tokenServiceMock.Object));
        }

        [Test]
        public void Constructor_WhenTokenServiceIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersHandler(
                this._loggerMock.Object,
                this._configurationMock.Object,
                this._cadsServiceMock.Object,
                null!));
        }
    }
}
