// <copyright file="UsersControllerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Tests.Controllers
{
    using ApiSeguimientoCADS.Api.Controllers;
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Models.Enums;
    using ApiSeguimientoCADS.Api.Models.Requests.Cads;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Pruebas unitarias para <see cref="UsersController"/>.
    /// </summary>
    [TestFixture]
    public sealed class UsersControllerTests
    {
        private Mock<IUsersHandler> _handlerMock = null!;
        private Mock<IAppLogger<UsersController>> _loggerMock = null!;
        private UsersController _controller = null!;

        [SetUp]
        public void SetUp()
        {
            this._handlerMock = new Mock<IUsersHandler>();
            this._loggerMock = new Mock<IAppLogger<UsersController>>();
            this._controller = new UsersController(this._handlerMock.Object, this._loggerMock.Object);
        }

        [Test]
        public async Task Validate_WhenRequestIsNull_ReturnsBadRequest()
        {
            // Act
            var result = await this._controller.Validate(null!);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult, Is.Not.Null);
        }

        [Test]
        public async Task Validate_WhenRequestIsValid_ReturnsRedirect()
        {
            // Arrange
            const string expectedUrl = "https://example.com/frontend";
            var request = new ValidateAccessRequest
            {
                RutTitular = "12345678-9",
                RutSolicitante = "12345678-9",
                Rol = ERol.Titular,
                Origen = EOrigen.Web,
                RutaOrigen = "test.com",
                Token = "test-token",
            };

            this._handlerMock
                .Setup(h => h.GenerarUrlFrontend(It.IsAny<ValidateAccessRequest>()))
                .ReturnsAsync(expectedUrl);

            // Act
            var result = await this._controller.Validate(request);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectResult>());
            var redirectResult = result as RedirectResult;
            Assert.That(redirectResult, Is.Not.Null);
            Assert.That(redirectResult!.Url, Is.EqualTo(expectedUrl));
            this._handlerMock.Verify(h => h.GenerarUrlFrontend(request), Times.Once);
        }

        [Test]
        public async Task Validate_WhenArgumentNullExceptionIsThrown_ReturnsBadRequest()
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

            this._handlerMock
                .Setup(h => h.GenerarUrlFrontend(It.IsAny<ValidateAccessRequest>()))
                .ThrowsAsync(new ArgumentNullException("Token"));

            // Act
            var result = await this._controller.Validate(request);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
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

            this._handlerMock
                .Setup(h => h.GenerarUrlFrontend(It.IsAny<ValidateAccessRequest>()))
                .ThrowsAsync(new ArgumentException("Invalid argument"));

            // Act
            var result = await this._controller.Validate(request);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task Validate_WhenInvalidOperationExceptionIsThrown_ReturnsInternalServerError()
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

            this._handlerMock
                .Setup(h => h.GenerarUrlFrontend(It.IsAny<ValidateAccessRequest>()))
                .ThrowsAsync(new InvalidOperationException("Invalid operation"));

            // Act
            var result = await this._controller.Validate(request);

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            var objectResult = result as ObjectResult;
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult!.StatusCode, Is.EqualTo(500));
        }

        [Test]
        public void Constructor_WhenHandlerIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersController(null!, this._loggerMock.Object));
        }

        [Test]
        public void Constructor_WhenLoggerIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersController(this._handlerMock.Object, null!));
        }
    }
}
