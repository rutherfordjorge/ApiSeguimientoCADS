// <copyright file="TokenService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Models.Settings;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Globalization;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    /// <summary>
    /// Servicio para generación y validación de tokens JWT
    /// </summary>
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IAppLogger<TokenService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenService"/> class.
        /// </summary>
        /// <param name="jwtSettings">Configuración de JWT</param>
        /// <param name="logger">Logger de la aplicación</param>
        public TokenService(
            IOptions<JwtSettings> jwtSettings,
            IAppLogger<TokenService> logger)
        {
            this._jwtSettings = jwtSettings?.Value ?? throw new ArgumentNullException(nameof(jwtSettings));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public string GenerateToken(string rutTitular, string origen, string rol)
        {
            var (processId, stopwatch) = this._logger.StartProcess(new
            {
                RutTitular = rutTitular,
                Origen = origen,
                Rol = rol,
            });

            try
            {
                this._logger.Info("Generando token JWT");

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwtSettings.Key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, rutTitular),
                    new Claim("origen", origen),
                    new Claim("rol", rol),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
                };

                var token = new JwtSecurityToken(
                    issuer: this._jwtSettings.Issuer,
                    audience: this._jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(this._jwtSettings.ExpirationMinutes),
                    signingCredentials: credentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                this._logger.Info("Token JWT generado exitosamente");
                this._logger.EndProcess(processId, stopwatch);

                return tokenString;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex);
                this._logger.EndProcess(processId, stopwatch);
                throw;
            }
        }

        /// <inheritdoc/>
        public bool ValidateToken(string token)
        {
            var (processId, stopwatch) = this._logger.StartProcess();

            try
            {
                this._logger.Info("Validando token JWT");

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(this._jwtSettings.Key);

                tokenHandler.ValidateToken(
                    token,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = this._jwtSettings.Issuer,
                        ValidateAudience = true,
                        ValidAudience = this._jwtSettings.Audience,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                    },
                    out SecurityToken validatedToken);

                this._logger.Info("Token JWT validado exitosamente");
                this._logger.EndProcess(processId, stopwatch);

                return true;
            }
            catch (SecurityTokenException ex)
            {
                this._logger.LogError(ex);
                this._logger.LogError("Token JWT inválido");
                this._logger.EndProcess(processId, stopwatch);
                return false;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex);
                this._logger.EndProcess(processId, stopwatch);
                throw;
            }
        }
    }
}