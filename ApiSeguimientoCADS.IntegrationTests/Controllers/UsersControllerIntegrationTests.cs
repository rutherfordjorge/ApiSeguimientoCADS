// <copyright file="UsersControllerIntegrationTests.cs" company="PlaceholderCompany">
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
    /// Pruebas de integración para UsersController.
    /// </summary>
    [TestFixture]
    public class UsersControllerIntegrationTests
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
        public async Task Validate_WhenCalledWithoutData_ReturnsBadRequest()
        {
            // Act
            var response = await this._client!.PostAsync("/api/v1/Users/Validate", null!);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest).Or.EqualTo(HttpStatusCode.UnsupportedMediaType));
        }

        [Test]
        public async Task ApiIsAccessible_ReturnsSuccess()
        {
            // Act - Intentar acceder a la raíz o a un endpoint de salud si existe
            var response = await this._client!.GetAsync("/");

            // Assert - La API debería responder (puede ser 404, pero no error de servidor)
            Assert.That((int)response.StatusCode, Is.LessThan(500));
        }
    }
}
