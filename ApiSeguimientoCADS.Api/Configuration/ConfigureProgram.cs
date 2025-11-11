// <copyright file="ConfigureProgram.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Configuration
{
    using ApiSeguimientoCADS.Api.Models.Settings;
    using ApiSeguimientoCADS.Api.Models.Settings.ExternalApis;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

    /// <summary>
    /// ConfigureProgram
    /// </summary>
    public static class ConfigureProgram
    {
        /// <summary>
        /// AddSeguimientoCadsSecurity
        /// </summary>
        /// <param name="builder">builder</param>
        /// <returns>WebApplicationBuilder</returns>
        public static WebApplicationBuilder AddSeguimientoCadsSecurity(this WebApplicationBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            var jwtKey = builder.Configuration["Jwt:Key"]
              ?? throw new InvalidOperationException("JWT Key is missing in configuration");

            var jwtIssuer = builder.Configuration["Jwt:Issuer"]
                                ?? throw new InvalidOperationException("JWT Issuer is missing in configuration");

            // En Development, JWT no se valida para facilitar pruebas locales
            // En otros ambientes (QA, Production), se valida completamente
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ValidateIssuerSigningKey = false,
                       };
                   });
            }
            else
            {
                builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ValidateIssuerSigningKey = true,
                           ValidIssuer = jwtIssuer,
                           ValidAudience = jwtIssuer,
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                       };
                   });
            }

            return builder;
        }

        /// <summary>
        /// AddSeguimientoSettingsMap
        /// </summary>
        /// <param name="builder">builder</param>
        /// <returns>config</returns>
        public static WebApplicationBuilder AddSeguimientoCadsSettingsMap(this WebApplicationBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            // Aquí se pueden agregar los mapeos de configuración adicionales
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
            builder.Services.Configure<CadsSettings>(builder.Configuration.GetSection("ApiCads"));
            builder.Services.Configure<EPSiniestroPorAseguradoSettings>(builder.Configuration.GetSection("EPDGetSiniestrosPorAsegurado"));
            builder.Services.Configure<EPGetdatosdelsiniestroSettings>(builder.Configuration.GetSection("EPGetdatosdelsiniestro"));
            return builder;
        }
    }
}