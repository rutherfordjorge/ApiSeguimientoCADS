// <copyright file="SiniestrosControllerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Tests.Controllers
{
    using ApiSeguimientoCADS.Api.Controllers;
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Models.DTOs.Siniestros;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Pruebas unitarias para <see cref="SiniestrosController"/>.
    /// </summary>
    [TestFixture]
    public sealed class SiniestrosControllerTests
    {
        private Mock<ISiniestrosHandler> _handlerMock = null!;
        private Mock<IAppLogger<SiniestrosController>> _loggerMock = null!;
        private SiniestrosController _controller = null!;

        [SetUp]
        public void SetUp()
        {
            this._handlerMock = new Mock<ISiniestrosHandler>();
            this._loggerMock = new Mock<IAppLogger<SiniestrosController>>();
            this._controller = new SiniestrosController(this._handlerMock.Object, this._loggerMock.Object);
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
        public async Task GetDetSiniestrosPorAsegurado_WhenRutIsValid_ReturnsOkWithData()
        {
            // Arrange
            const string rut = "12345678-9";
            var siniestrosData = new SiniestrosDataDto();
            siniestrosData.Siniestros.Add(new SiniestroDto
            {
                NumSiniestro = "123",
                TipoSinistros = "auto",
                GlosaSiniestro = "Test",
                FechaDenuncio = "2025-01-01",
                EstadoSinistro = "Aceptado",
                EstadoDenuncio = "A",
                AccionesPendientes = false,
            });

            this._handlerMock
                .Setup(h => h.GetSiniestrosDetallePorAsegurado(It.IsAny<string>()))
                .ReturnsAsync(siniestrosData);

            // Act
            var result = await this._controller.GetDetSiniestrosPorAsegurado(rut);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            this._handlerMock.Verify(h => h.GetSiniestrosDetallePorAsegurado(rut), Times.Once);
        }

        [Test]
        public async Task GetDetSiniestrosPorAsegurado_WhenNoSiniestrosFound_ReturnsOkWithNullData()
        {
            // Arrange
            const string rut = "12345678-9";
            var siniestrosData = new SiniestrosDataDto();

            this._handlerMock
                .Setup(h => h.GetSiniestrosDetallePorAsegurado(It.IsAny<string>()))
                .ReturnsAsync(siniestrosData);

            // Act
            var result = await this._controller.GetDetSiniestrosPorAsegurado(rut);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task GetDetSiniestrosPorAsegurado_WhenArgumentExceptionIsThrown_ReturnsBadRequest()
        {
            // Arrange
            const string rut = "invalid-rut";

            this._handlerMock
                .Setup(h => h.GetSiniestrosDetallePorAsegurado(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("RUT inválido"));

            // Act
            var result = await this._controller.GetDetSiniestrosPorAsegurado(rut);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task GetDetSiniestrosPorAsegurado_WhenOperationCanceledExceptionIsThrown_ReturnsRequestTimeout()
        {
            // Arrange
            const string rut = "12345678-9";

            this._handlerMock
                .Setup(h => h.GetSiniestrosDetallePorAsegurado(It.IsAny<string>()))
                .ThrowsAsync(new OperationCanceledException("Operación cancelada"));

            // Act
            var result = await this._controller.GetDetSiniestrosPorAsegurado(rut);

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            var objectResult = result as ObjectResult;
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult!.StatusCode, Is.EqualTo(StatusCodes.Status408RequestTimeout));
        }

        [Test]
        public async Task GetDetSiniestrosPorAsegurado_WhenInvalidOperationExceptionIsThrown_ReturnsInternalServerError()
        {
            // Arrange
            const string rut = "12345678-9";

            this._handlerMock
                .Setup(h => h.GetSiniestrosDetallePorAsegurado(It.IsAny<string>()))
                .ThrowsAsync(new InvalidOperationException("Error interno"));

            // Act
            var result = await this._controller.GetDetSiniestrosPorAsegurado(rut);

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            var objectResult = result as ObjectResult;
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult!.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
        }

        [Test]
        public async Task GetDetSiniestrosPorAsegurado_WhenKeyNotFoundExceptionIsThrown_ReturnsNotFound()
        {
            // Arrange
            const string rut = "12345678-9";

            this._handlerMock
                .Setup(h => h.GetSiniestrosDetallePorAsegurado(It.IsAny<string>()))
                .ThrowsAsync(new KeyNotFoundException("Asegurado no encontrado"));

            // Act
            var result = await this._controller.GetDetSiniestrosPorAsegurado(rut);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
        }

        [Test]
        public void Constructor_WhenHandlerIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SiniestrosController(null!, this._loggerMock.Object));
        }

        [Test]
        public void Constructor_WhenLoggerIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SiniestrosController(this._handlerMock.Object, null!));
        }
    }
}
