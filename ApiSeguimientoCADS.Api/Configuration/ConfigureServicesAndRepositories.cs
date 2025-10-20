// <copyright file="ConfigureServicesAndRepositories.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Configuration
{
    using ApiSeguimientoCADS.Api.Handlers;
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Services;
    using ApiSeguimientoCADS.Api.Services.Interfaces;

    /// <summary>
    /// ConfigureServicesAndRepositories
    /// </summary>
    public static class ConfigureServicesAndRepositories
    {
        /// <summary>
        /// AddApiSeguimientoCadsServices
        /// </summary>
        /// <param name="builder">builder</param>
        /// <returns>WebApplicationBuilder</returns>
        public static WebApplicationBuilder AddSeguimientoCadsServices(this WebApplicationBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(builder);
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddHttpClient<IHttpClientService, HttpClientService>();
            builder.Services.AddScoped<IServiciosExternosHandler, ServiciosExternosHandler>();
            builder.Services.AddScoped<ICadsService, CadsService>();

            return builder;
        }
    }
}