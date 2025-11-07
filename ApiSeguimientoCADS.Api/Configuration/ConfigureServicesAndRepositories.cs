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

            // Registrar servicio de políticas de resiliencia como Singleton
            // Las políticas de Polly son stateless y thread-safe, Singleton mejora el rendimiento
            builder.Services.AddSingleton<IResiliencePolicyService, ResiliencePolicyService>();

            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddHttpClient<IHttpClientService, HttpClientService>();
            builder.Services.AddScoped<IUsersHandler, UsersHandler>();
            builder.Services.AddScoped<ICadsService, CadsService>();
            builder.Services.AddScoped<ISiniestrosService, SiniestrosService>();
            builder.Services.AddScoped<ISiniestrosHandler, SiniestrosHandler>();
            builder.Services.AddScoped<IHttpService, HttpService>();
            builder.Services.AddScoped<IHttpHandler, HttpHandler>();
            return builder;
        }
    }
}