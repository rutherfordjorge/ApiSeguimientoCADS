// <copyright file="ConfigureProgram.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Configuration
{
    using ApiSeguimientoCADS.Api.Models.Settings;
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

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var jwtSettings = builder.Configuration.GetSection("Jwt");
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!)),
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidateAudience = true,
                    ValidAudience = jwtSettings["Issuer"],
                    ValidateLifetime = true,
                };
            });
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
            return builder;
        }
    }
}