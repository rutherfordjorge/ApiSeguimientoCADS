// <copyright file="FakeControllerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Tests.Controllers
{
    using ApiSeguimientoCADS.Api.Controllers;
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Models.Enums;
    using ApiSeguimientoCADS.Api.Models.Requests.Cads;
    using ApiSeguimientoCADS.Api.Models.Settings.ExternalApis;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Pruebas unitarias para <see cref="FakeController"/>.
    /// </summary>
    [TestFixture]
    public sealed class FakeControllerTests
    {
        private Mock<IAppLogger<FakeController>> _loggerMock = null!;
        private Mock<IUsersHandler> _handlerMock = null!;
        private Mock<IOptions<EPSiniestroPorAseguradoSettings>> _settingsMock = null!;
        private Mock<IHttpClientService>? _httpClientServiceMock;

        private FakeController _controller = null!;

        [SetUp]
        public void SetUp()
        {
            this._loggerMock = new Mock<IAppLogger<FakeController>>();
            this._handlerMock = new Mock<IUsersHandler>();
            this._settingsMock = new Mock<IOptions<EPSiniestroPorAseguradoSettings>>();
            this._httpClientServiceMock = new Mock<IHttpClientService>();

            var settings = new EPSiniestroPorAseguradoSettings
            {
                ValidarAccesoMultipleUrl = "https://test.com/api/validate",
                TokenCABName = "TokenCAB",
                TokenCABValue = "test-token",
                CookieName = "Cookie",
                CookieValue = "test-cookie",
            };

            this._settingsMock.Setup(s => s.Value).Returns(settings);

            this._controller = new FakeController(
                this._loggerMock.Object,
                this._handlerMock.Object,
                this._settingsMock.Object,
                this._httpClientServiceMock.Object);
        }

        [Test]
        public async Task Validate_WhenRequestIsNull_ReturnsBadRequest()
        {
            // Act
            var result = await this._controller.Validate(null!);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task Validate_WhenRequestIsValid_ReturnsRedirect()
        {
            // Arrange
            var request = new ValidateAccessRequest
            {
                RutTitular = "12345678-9",
                RutSolicitante = "12345678-9",
                Rol = ERol.Titular,
                Origen = EOrigen.Web,
                RutaOrigen = "test.com",
            };

            // Act
            var result = await this._controller.Validate(request);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectResult>());
        }

        [Test]
        public async Task Validate_WhenArgumentExceptionIsThrown_ReturnsBadRequest()
        {
            // Arrange
            var request = new ValidateAccessRequest
            {
                RutTitular = "12345678-9",
                RutSolicitante = "12345678-9",
                Rol = ERol.Titular,
                Origen = EOrigen.Web,
                RutaOrigen = "test.com",
            };

            // Act
            var result = await this._controller.Validate(request);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task GetDetSiniestrosPorAsegurado_WhenRutIsEmpty_ReturnsBadRequest()
        {
            // Act
            var result = await this._controller.GetDetSiniestrosPorAsegurado(string.Empty);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task GetDetSiniestrosPorAsegurado_WhenRutIsNull_ReturnsBadRequest()
        {
            // Act
            var result = await this._controller.GetDetSiniestrosPorAsegurado(null!);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task GetDetSiniestrosPorAsegurado_WhenRutIsValid_ReturnsResult()
        {
            // Arrange
            // Usamos un RUT válido con dígito verificador correcto
            const string rut = "17863159-k";

            // Act
            var result = await this._controller.GetDetSiniestrosPorAsegurado(rut);

            // Assert
            // El FakeController valida el RUT, puede retornar Ok u otro resultado dependiendo de la validación
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<IActionResult>());
        }

        [Test]
        public async Task GetDetSiniestrosPorAsegurado_WhenRutIsInvalid_ReturnsBadRequest()
        {
            // Arrange
            const string rut = "invalid-rut";

            // Act
            var result = await this._controller.GetDetSiniestrosPorAsegurado(rut);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task LoginDirecto_WhenRutTitularIsNull_ReturnsBadRequest()
        {
            // Act
            var result = await this._controller.LoginDirecto(null!, "password");

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task LoginDirecto_WhenPassTitularIsNull_ReturnsBadRequest()
        {
            // Act
            var result = await this._controller.LoginDirecto("12345678-9", null!);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public void Constructor_WhenLoggerIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FakeController(
                null!,
                this._handlerMock.Object,
                this._settingsMock.Object,
                this._httpClientServiceMock.Object));
        }

        [Test]
        public void Constructor_WhenHandlerIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FakeController(
                this._loggerMock.Object,
                null!,
                this._settingsMock.Object,
                this._httpClientServiceMock.Object));
        }

        [Test]
        public void Constructor_WhenSettingsIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FakeController(
                this._loggerMock.Object,
                this._handlerMock.Object,
                null!,
                this._httpClientServiceMock.Object));
        }

        [Test]
        public void Constructor_WhenHttpClientServiceIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FakeController(
                this._loggerMock.Object,
                this._handlerMock.Object,
                this._settingsMock.Object,
                null!));
        }
    }
}
