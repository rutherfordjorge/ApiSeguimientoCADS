// <copyright file="TokenService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Models.Requests;
    using ApiSeguimientoCADS.Api.Models.Settings;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System.Globalization;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    /// <summary>
    /// TokenService
    /// </summary>
    public class TokenService(IOptions<JwtSettings> options) : ITokenService
    {
        private readonly JwtSettings _jwtSettings = options?.Value ?? throw new ArgumentNullException(nameof(options));

        /// <summary>
        /// GenerateToken
        /// </summary>
        /// <param name="data">data</param>
        /// <returns>token</returns>
        public string GenerateToken(TokenData data)
        {
            ArgumentNullException.ThrowIfNull(data);

            try
            {
                var secretKey = this._jwtSettings.Key;
                var issuer = this._jwtSettings.Issuer;

                if (string.IsNullOrEmpty(secretKey) || string.IsNullOrEmpty(issuer))
                {
                    throw new InvalidOperationException("Configuración de JWT (Key, Issuer) no encontrada o incompleta.");
                }

                // Validar longitud mínima de la clave
                if (secretKey.Length < 16)
                {
                    throw new InvalidOperationException("La clave JWT debe tener al menos 16 caracteres.");
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new(ClaimTypes.Role, data.Rol.ToString(CultureInfo.InvariantCulture)),
                    new(JwtRegisteredClaimNames.Jti, data.SessionId),
                    new(ClaimTypes.NameIdentifier, data.EsTitular.ToString(CultureInfo.InvariantCulture)),
                    new(ClaimTypes.Dns, data.Origen.ToString(CultureInfo.InvariantCulture)),
                    new("solicitante", !string.IsNullOrWhiteSpace(data.Solicitante) ? data.Solicitante.ToString() : string.Empty),
                    new("nombres", !string.IsNullOrWhiteSpace(data.Nombres) ? data.Nombres.ToString() : string.Empty),
                    new("apellidos", !string.IsNullOrWhiteSpace(data.Apellidos) ? data.Apellidos.ToString() : string.Empty),
                    new("email", !string.IsNullOrWhiteSpace(data.Email) ? data.Email.ToString() : string.Empty),
                    new("tokenOrigen", !string.IsNullOrWhiteSpace(data.TokenOrigen) ? data.TokenOrigen.ToString() : string.Empty),
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    Issuer = issuer,
                    Audience = issuer,
                    SigningCredentials = creds,
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {
                throw new InvalidOperationException("Error en la operación criptográfica al generar token", ex);
            }
            catch (EncoderFallbackException ex)
            {
                throw new InvalidOperationException("Error de codificación al generar token", ex);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException("Error al generar token JWT - argumentos inválidos", ex);
            }
        }
    }
}