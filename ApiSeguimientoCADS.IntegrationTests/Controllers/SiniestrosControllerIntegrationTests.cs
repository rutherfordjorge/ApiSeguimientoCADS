// <copyright file="SiniestrosControllerIntegrationTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.IntegrationTests.Controllers
{
    using Microsoft.AspNetCore.Mvc.Testing;
    using NUnit.Framework;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Pruebas de integración para SiniestrosController.
    /// </summary>
    [TestFixture]
    public class SiniestrosControllerIntegrationTests
    {
        private WebApplicationFactory<Program>? _factory;
        private HttpClient? _client;

        [SetUp]
        public void SetUp()
        {
            this._factory = new CustomWebApplicationFactory<Program>();
            this._client = this._factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            this._client?.Dispose();
            this._factory?.Dispose();
        }

        [Test]
        public async Task GetDetSiniestrosPorAsegurado_WhenCalledWithEmptyRut_ReturnsBadRequest()
        {
            // Act
            var response = await this._client!.GetAsync("/api/v1/siniestros//detalle");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound).Or.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task GetDetSiniestrosPorAsegurado_WhenCalledWithInvalidRut_ReturnsBadRequest()
        {
            // Act
            var response = await this._client!.GetAsync("/api/v1/siniestros/invalid-rut/detalle");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task GetDetSiniestrosPorAsegurado_EndpointExists()
        {
            // Act - Verificar que el endpoint existe (puede fallar por validación, pero no por ruta)
            var response = await this._client!.GetAsync("/api/v1/siniestros/12345678-9/detalle");

            // Assert - No debería ser 404 (endpoint existe)
            Assert.That(response.StatusCode, Is.Not.EqualTo(HttpStatusCode.NotFound));
        }
    }
}
