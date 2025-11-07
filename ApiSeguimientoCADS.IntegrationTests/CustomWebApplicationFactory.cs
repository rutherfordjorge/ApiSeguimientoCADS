// <copyright file="CustomWebApplicationFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.IntegrationTests
{
    using ApiSeguimientoCADS.Api;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Factory personalizada para pruebas de integración.
    /// </summary>
    /// <typeparam name="TProgram">Tipo del programa de inicio.</typeparam>
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram>
        where TProgram : class
    {
        /// <summary>
        /// Configura el host web para las pruebas.
        /// </summary>
        /// <param name="builder">Constructor del host web.</param>
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Aquí se pueden agregar servicios mock o configuraciones especiales para las pruebas
            });

            builder.UseEnvironment("Testing");
        }
    }
}
