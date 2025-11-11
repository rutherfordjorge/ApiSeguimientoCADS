// <copyright file="SiniestrosHandlerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Tests.Handlers
{
    using ApiSeguimientoCADS.Api.Handlers;
    using ApiSeguimientoCADS.Api.Models.DTOs.Siniestros;
    using ApiSeguimientoCADS.Api.Models.Requests.Siniestros;
    using ApiSeguimientoCADS.Api.Models.Responses.Siniestros;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using Moq;
    using NUnit.Framework;
    using Polly;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Pruebas unitarias para <see cref="SiniestrosHandler"/>.
    /// </summary>
    [TestFixture]
    public sealed class SiniestrosHandlerTests
    {
        private Mock<IAppLogger<SiniestrosHandler>> _loggerMock = null!;
        private Mock<ISiniestrosService> _siniestrosServiceMock = null!;
        private Mock<IResiliencePolicyService> _resiliencePolicyServiceMock = null!;
        private SiniestrosHandler _handler = null!;

        [SetUp]
        public void SetUp()
        {
            this._loggerMock = new Mock<IAppLogger<SiniestrosHandler>>();
            this._siniestrosServiceMock = new Mock<ISiniestrosService>();
            this._resiliencePolicyServiceMock = new Mock<IResiliencePolicyService>();

            // Setup default bulkhead pipeline that executes immediately
            var bulkheadPipeline = new ResiliencePipelineBuilder()
                .Build();

            this._resiliencePolicyServiceMock
                .Setup(r => r.BulkheadPipeline)
                .Returns(bulkheadPipeline);

            this._handler = new SiniestrosHandler(
                this._loggerMock.Object,
                this._siniestrosServiceMock.Object,
                this._resiliencePolicyServiceMock.Object);
        }

        [Test]
        public void Constructor_WhenLoggerIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SiniestrosHandler(
                null!,
                this._siniestrosServiceMock.Object,
                this._resiliencePolicyServiceMock.Object));
        }

        [Test]
        public void Constructor_WhenSiniestrosServiceIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SiniestrosHandler(
                this._loggerMock.Object,
                null!,
                this._resiliencePolicyServiceMock.Object));
        }

        [Test]
        public void Constructor_WhenResiliencePolicyServiceIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SiniestrosHandler(
                this._loggerMock.Object,
                this._siniestrosServiceMock.Object,
                null!));
        }

        [Test]
        public async Task GetSiniestrosPorAsegurado_WhenRequestIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await this._handler.GetSiniestrosPorAsegurado(null!));
        }

        [Test]
        public async Task GetSiniestrosPorAsegurado_WhenRutAseguradoIsNull_ThrowsArgumentException()
        {
            // Arrange
            var request = new SiniestrosRequest { RutAsegurado = null! };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await this._handler.GetSiniestrosPorAsegurado(request));
        }

        [Test]
        public async Task GetSiniestrosPorAsegurado_WhenRutAseguradoIsEmpty_ThrowsArgumentException()
        {
            // Arrange
            var request = new SiniestrosRequest { RutAsegurado = string.Empty };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await this._handler.GetSiniestrosPorAsegurado(request));
        }

        [Test]
        public async Task GetSiniestrosPorAsegurado_WhenRutAseguradoIsWhiteSpace_ThrowsArgumentException()
        {
            // Arrange
            var request = new SiniestrosRequest { RutAsegurado = "   " };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await this._handler.GetSiniestrosPorAsegurado(request));
        }

        [Test]
        public async Task GetSiniestrosPorAsegurado_WhenServiceReturnsNull_ThrowsInvalidOperationException()
        {
            // Arrange
            var request = new SiniestrosRequest { RutAsegurado = "12345678" };

            this._siniestrosServiceMock
                .Setup(s => s.GetSiniestrosPorAsegurado(It.IsAny<SiniestrosRequest>()))
                .ReturnsAsync((SiniestrosResponse)null!);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await this._handler.GetSiniestrosPorAsegurado(request));
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
                        NumeroPoliza = "12345",
                    },
                },
            };

            this._siniestrosServiceMock
                .Setup(s => s.GetSiniestrosPorAsegurado(request))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await this._handler.GetSiniestrosPorAsegurado(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Data, Is.Not.Null);
            var nonNullData = nonNullResult.Data!;
            Assert.That(nonNullData.Count, Is.EqualTo(1));
            this._siniestrosServiceMock.Verify(s => s.GetSiniestrosPorAsegurado(request), Times.Once);
        }

        [Test]
        public async Task GetDetalleSiniestros_WhenRequestIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await this._handler.GetDetalleSiniestros(null!));
        }

        [Test]
        public async Task GetDetalleSiniestros_WhenINsinieIsZero_ThrowsArgumentException()
        {
            // Arrange
            var request = new SiniestrosDetRequest { INsinie = 0, INdocto = 100 };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await this._handler.GetDetalleSiniestros(request));
        }

        [Test]
        public async Task GetDetalleSiniestros_WhenINsinieIsNegative_ThrowsArgumentException()
        {
            // Arrange
            var request = new SiniestrosDetRequest { INsinie = -1, INdocto = 100 };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await this._handler.GetDetalleSiniestros(request));
        }

        [Test]
        public async Task GetDetalleSiniestros_WhenINdoctoIsZero_ThrowsArgumentException()
        {
            // Arrange
            var request = new SiniestrosDetRequest { INsinie = 100, INdocto = 0 };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await this._handler.GetDetalleSiniestros(request));
        }

        [Test]
        public async Task GetDetalleSiniestros_WhenINdoctoIsNegative_ThrowsArgumentException()
        {
            // Arrange
            var request = new SiniestrosDetRequest { INsinie = 100, INdocto = -1 };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await this._handler.GetDetalleSiniestros(request));
        }

        [Test]
        public async Task GetDetalleSiniestros_WhenRequestIsValid_ReturnsResponse()
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

            this._siniestrosServiceMock
                .Setup(s => s.GetDatosDelSiniestro(request))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await this._handler.GetDetalleSiniestros(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Data, Is.Not.Null);
            var nonNullData = nonNullResult.Data!;
            Assert.That(nonNullData.Count, Is.EqualTo(1));
            this._siniestrosServiceMock.Verify(s => s.GetDatosDelSiniestro(request), Times.Once);
        }

        [Test]
        public async Task GetSiniestrosDetallePorAsegurado_WhenRutIsNull_ThrowsArgumentException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await this._handler.GetSiniestrosDetallePorAsegurado(null!));
        }

        [Test]
        public async Task GetSiniestrosDetallePorAsegurado_WhenRutIsEmpty_ThrowsArgumentException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await this._handler.GetSiniestrosDetallePorAsegurado(string.Empty));
        }

        [Test]
        public async Task GetSiniestrosDetallePorAsegurado_WhenRutIsWhiteSpace_ThrowsArgumentException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await this._handler.GetSiniestrosDetallePorAsegurado("   "));
        }

        [Test]
        public async Task GetSiniestrosDetallePorAsegurado_WhenRutIsInvalid_ThrowsArgumentException()
        {
            // Arrange
            var invalidRut = "12345678-0"; // Invalid checksum

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await this._handler.GetSiniestrosDetallePorAsegurado(invalidRut));
        }

        [Test]
        public async Task GetSiniestrosDetallePorAsegurado_WhenNoSiniestrosFound_ReturnsEmptyDto()
        {
            // Arrange
            var validRut = "11111111-1";
            var emptyResponse = new SiniestrosResponse
            {
                Data = new List<SiniestrosDataResponse>(),
            };

            this._siniestrosServiceMock
                .Setup(s => s.GetSiniestrosPorAsegurado(It.IsAny<SiniestrosRequest>()))
                .ReturnsAsync(emptyResponse);

            // Act
            var result = await this._handler.GetSiniestrosDetallePorAsegurado(validRut);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Siniestros, Is.Not.Null);
            var nonNullSiniestros = nonNullResult.Siniestros!;
            Assert.That(nonNullSiniestros.Count, Is.EqualTo(0));
            Assert.That(nonNullResult.TiposSiniestros.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetSiniestrosDetallePorAsegurado_WhenDataIsNull_ReturnsEmptyDto()
        {
            // Arrange
            var validRut = "11111111-1";
            var responseWithNullData = new SiniestrosResponse
            {
                Data = null,
            };

            this._siniestrosServiceMock
                .Setup(s => s.GetSiniestrosPorAsegurado(It.IsAny<SiniestrosRequest>()))
                .ReturnsAsync(responseWithNullData);

            // Act
            var result = await this._handler.GetSiniestrosDetallePorAsegurado(validRut);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Siniestros.Count, Is.EqualTo(0));
            Assert.That(nonNullResult.TiposSiniestros.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetSiniestrosDetallePorAsegurado_WhenNoVPSiniestros_ReturnsEmptyDto()
        {
            // Arrange
            var validRut = "11111111-1";
            var responseWithNonVPRamo = new SiniestrosResponse
            {
                Data = new List<SiniestrosDataResponse>
                {
                    new SiniestrosDataResponse
                    {
                        NumeroSiniestro = 123,
                        Ramo = "INCENDIO", // Not VP
                        NumeroPoliza = "12345",
                    },
                },
            };

            this._siniestrosServiceMock
                .Setup(s => s.GetSiniestrosPorAsegurado(It.IsAny<SiniestrosRequest>()))
                .ReturnsAsync(responseWithNonVPRamo);

            // Act
            var result = await this._handler.GetSiniestrosDetallePorAsegurado(validRut);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Siniestros.Count, Is.EqualTo(0));
            Assert.That(nonNullResult.TiposSiniestros.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetSiniestrosDetallePorAsegurado_WhenValidVPSiniestro_ReturnsEnrichedDto()
        {
            // Arrange
            var validRut = "11111111-1";
            var siniestrosResponse = new SiniestrosResponse
            {
                Data = new List<SiniestrosDataResponse>
                {
                    new SiniestrosDataResponse
                    {
                        NumeroSiniestro = 123,
                        Ramo = "VP",
                        NumeroPoliza = "ABC-12345",
                        FechaDenuncia = "2024-01-01",
                        Estado = "En Proceso",
                        CodigoEstado = "EP",
                    },
                },
            };

            var detalleResponse = new SiniestrosDetalleResponse
            {
                Data = new List<SiniestroDetalleDataResponse>
                {
                    new SiniestroDetalleDataResponse
                    {
                        Patente = "ABC123",
                    },
                },
            };

            this._siniestrosServiceMock
                .Setup(s => s.GetSiniestrosPorAsegurado(It.IsAny<SiniestrosRequest>()))
                .ReturnsAsync(siniestrosResponse);

            this._siniestrosServiceMock
                .Setup(s => s.GetDatosDelSiniestro(It.IsAny<SiniestrosDetRequest>()))
                .ReturnsAsync(detalleResponse);

            // Act
            var result = await this._handler.GetSiniestrosDetallePorAsegurado(validRut);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Siniestros, Is.Not.Null);
            var nonNullSiniestros = nonNullResult.Siniestros!;
            Assert.That(nonNullSiniestros.Count, Is.EqualTo(1));
            Assert.That(nonNullResult.TiposSiniestros.Count, Is.EqualTo(1));
            Assert.That(nonNullResult.TiposSiniestros[0].Nombre, Is.EqualTo("Vehículo"));

            var siniestro = nonNullSiniestros[0];
            Assert.That(siniestro.NumSiniestro, Is.EqualTo("123"));
            Assert.That(siniestro.TipoSinistros, Is.EqualTo("auto"));
            Assert.That(siniestro.GlosaSiniestro, Does.Contain("ABC123"));
        }

        [Test]
        public async Task GetSiniestrosDetallePorAsegurado_WhenPolizaHasInvalidFormat_SkipsSiniestro()
        {
            // Arrange
            var validRut = "11111111-1";
            var siniestrosResponse = new SiniestrosResponse
            {
                Data = new List<SiniestrosDataResponse>
                {
                    new SiniestrosDataResponse
                    {
                        NumeroSiniestro = 123,
                        Ramo = "VP",
                        NumeroPoliza = "ABC-DEF", // No digits
                        FechaDenuncia = "2024-01-01",
                        Estado = "En Proceso",
                        CodigoEstado = "EP",
                    },
                },
            };

            this._siniestrosServiceMock
                .Setup(s => s.GetSiniestrosPorAsegurado(It.IsAny<SiniestrosRequest>()))
                .ReturnsAsync(siniestrosResponse);

            // Act
            var result = await this._handler.GetSiniestrosDetallePorAsegurado(validRut);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Siniestros.Count, Is.EqualTo(0));
            Assert.That(nonNullResult.TiposSiniestros.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetSiniestrosDetallePorAsegurado_WhenDetalleServiceFails_ContinuesWithOtherSiniestros()
        {
            // Arrange
            var validRut = "11111111-1";
            var siniestrosResponse = new SiniestrosResponse
            {
                Data = new List<SiniestrosDataResponse>
                {
                    new SiniestrosDataResponse
                    {
                        NumeroSiniestro = 123,
                        Ramo = "VP",
                        NumeroPoliza = "12345",
                    },
                },
            };

            this._siniestrosServiceMock
                .Setup(s => s.GetSiniestrosPorAsegurado(It.IsAny<SiniestrosRequest>()))
                .ReturnsAsync(siniestrosResponse);

            this._siniestrosServiceMock
                .Setup(s => s.GetDatosDelSiniestro(It.IsAny<SiniestrosDetRequest>()))
                .ThrowsAsync(new ArgumentException("Test exception"));

            // Act
            var result = await this._handler.GetSiniestrosDetallePorAsegurado(validRut);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Siniestros.Count, Is.EqualTo(0)); // Failed, so no siniestros added
        }

        [Test]
        public async Task GetSiniestrosDetallePorAsegurado_WhenDetalleReturnsNull_SkipsSiniestro()
        {
            // Arrange
            var validRut = "11111111-1";
            var siniestrosResponse = new SiniestrosResponse
            {
                Data = new List<SiniestrosDataResponse>
                {
                    new SiniestrosDataResponse
                    {
                        NumeroSiniestro = 123,
                        Ramo = "VP",
                        NumeroPoliza = "12345",
                    },
                },
            };

            var detalleResponseWithNullData = new SiniestrosDetalleResponse
            {
                Data = null,
            };

            this._siniestrosServiceMock
                .Setup(s => s.GetSiniestrosPorAsegurado(It.IsAny<SiniestrosRequest>()))
                .ReturnsAsync(siniestrosResponse);

            this._siniestrosServiceMock
                .Setup(s => s.GetDatosDelSiniestro(It.IsAny<SiniestrosDetRequest>()))
                .ReturnsAsync(detalleResponseWithNullData);

            // Act
            var result = await this._handler.GetSiniestrosDetallePorAsegurado(validRut);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Siniestros.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetSiniestrosDetallePorAsegurado_RemovesDuplicateSiniestros()
        {
            // Arrange
            var validRut = "11111111-1";
            var siniestrosResponse = new SiniestrosResponse
            {
                Data = new List<SiniestrosDataResponse>
                {
                    new SiniestrosDataResponse
                    {
                        NumeroSiniestro = 123,
                        Ramo = "VP",
                        NumeroPoliza = "12345",
                    },
                    new SiniestrosDataResponse
                    {
                        NumeroSiniestro = 123, // Same siniestro number
                        Ramo = "VP",
                        NumeroPoliza = "12345", // Same poliza number
                    },
                },
            };

            var detalleResponse = new SiniestrosDetalleResponse
            {
                Data = new List<SiniestroDetalleDataResponse>
                {
                    new SiniestroDetalleDataResponse { Patente = "ABC123" },
                },
            };

            this._siniestrosServiceMock
                .Setup(s => s.GetSiniestrosPorAsegurado(It.IsAny<SiniestrosRequest>()))
                .ReturnsAsync(siniestrosResponse);

            this._siniestrosServiceMock
                .Setup(s => s.GetDatosDelSiniestro(It.IsAny<SiniestrosDetRequest>()))
                .ReturnsAsync(detalleResponse);

            // Act
            var result = await this._handler.GetSiniestrosDetallePorAsegurado(validRut);

            // Assert
            Assert.That(result, Is.Not.Null);
            var nonNullResult = result!;
            Assert.That(nonNullResult.Siniestros.Count, Is.EqualTo(1)); // Only one, duplicates removed
            this._siniestrosServiceMock.Verify(
                s => s.GetDatosDelSiniestro(It.IsAny<SiniestrosDetRequest>()),
                Times.Once); // Called only once due to deduplication
        }
    }
}
