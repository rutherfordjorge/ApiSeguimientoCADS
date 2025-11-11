// <copyright file="TokenServiceTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Tests.Services
{
    using ApiSeguimientoCADS.Api.Models.Enums;
    using ApiSeguimientoCADS.Api.Models.Requests;
    using ApiSeguimientoCADS.Api.Models.Settings;
    using ApiSeguimientoCADS.Api.Services;
    using Microsoft.Extensions.Options;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;

    /// <summary>
    /// Pruebas unitarias para <see cref="TokenService"/>.
    /// </summary>
    [TestFixture]
    public sealed class TokenServiceTests
    {
        private Mock<IOptions<JwtSettings>> _jwtSettingsMock = null!;
        private TokenService _tokenService = null!;

        [SetUp]
        public void SetUp()
        {
            this._jwtSettingsMock = new Mock<IOptions<JwtSettings>>();
            var jwtSettings = new JwtSettings
            {
                Key = "ThisIsASecretKeyForTesting123456",
                Issuer = "TestIssuer",
            };

            this._jwtSettingsMock.Setup(s => s.Value).Returns(jwtSettings);
            this._tokenService = new TokenService(this._jwtSettingsMock.Object);
        }

        [Test]
        public void GenerateToken_WhenDataIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => this._tokenService.GenerateToken(null!));
        }

        [Test]
        public void GenerateToken_WhenDataIsValid_ReturnsValidToken()
        {
            // Arrange
            var tokenData = new TokenData
            {
                Rol = (int)ERol.Titular,
                SessionId = "test-session-id",
                EsTitular = 1,
                Origen = (int)EOrigen.Web,
                Solicitante = "12345678-9",
                Nombres = "Juan",
                Apellidos = "Pérez",
                Email = "juan.perez@test.com",
                TokenOrigen = "test-token-origen",
            };

            // Act
            var token = this._tokenService.GenerateToken(tokenData);

            // Assert
            Assert.That(token, Is.Not.Null);
            Assert.That(token, Is.Not.Empty);

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            Assert.That(jwtToken.Issuer, Is.EqualTo("TestIssuer"));
            Assert.That(jwtToken.Claims.Any(c => c.Type == JwtRegisteredClaimNames.Jti && c.Value == "test-session-id"), Is.True);
        }

        [Test]
        public void GenerateToken_WhenKeyIsTooShort_ThrowsInvalidOperationException()
        {
            // Arrange
            var shortKeySettings = new JwtSettings
            {
                Key = "short",
                Issuer = "TestIssuer",
            };

            this._jwtSettingsMock.Setup(s => s.Value).Returns(shortKeySettings);
            this._tokenService = new TokenService(this._jwtSettingsMock.Object);

            var tokenData = new TokenData
            {
                Rol = (int)ERol.Titular,
                SessionId = "test-session-id",
                EsTitular = 1,
                Origen = (int)EOrigen.Web,
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => this._tokenService.GenerateToken(tokenData));
        }

        [Test]
        public void GenerateToken_WhenKeyIsEmpty_ThrowsInvalidOperationException()
        {
            // Arrange
            var emptyKeySettings = new JwtSettings
            {
                Key = string.Empty,
                Issuer = "TestIssuer",
            };

            this._jwtSettingsMock.Setup(s => s.Value).Returns(emptyKeySettings);
            this._tokenService = new TokenService(this._jwtSettingsMock.Object);

            var tokenData = new TokenData
            {
                Rol = (int)ERol.Titular,
                SessionId = "test-session-id",
                EsTitular = 1,
                Origen = (int)EOrigen.Web,
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => this._tokenService.GenerateToken(tokenData));
        }

        [Test]
        public void GenerateToken_WhenIssuerIsEmpty_ThrowsInvalidOperationException()
        {
            // Arrange
            var emptyIssuerSettings = new JwtSettings
            {
                Key = "ThisIsASecretKeyForTesting123456",
                Issuer = string.Empty,
            };

            this._jwtSettingsMock.Setup(s => s.Value).Returns(emptyIssuerSettings);
            this._tokenService = new TokenService(this._jwtSettingsMock.Object);

            var tokenData = new TokenData
            {
                Rol = (int)ERol.Titular,
                SessionId = "test-session-id",
                EsTitular = 1,
                Origen = (int)EOrigen.Web,
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => this._tokenService.GenerateToken(tokenData));
        }

        [Test]
        public void Constructor_WhenOptionsIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TokenService(null!));
        }
    }
}
