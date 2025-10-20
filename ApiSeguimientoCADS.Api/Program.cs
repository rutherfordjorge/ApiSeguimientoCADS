// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ApiSeguimientoCADS.Api.Configuration;
using ApiSeguimientoCADS.Api.Handlers;
using ApiSeguimientoCADS.Api.Handlers.Interfaces;
using ApiSeguimientoCADS.Api.Infrastructure.Repositories;
using ApiSeguimientoCADS.Api.Middlewares;
using ApiSeguimientoCADS.Api.Security.Logger;
using ApiSeguimientoCADS.Api.Services;
using ApiSeguimientoCADS.Api.Services.Interfaces;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using NLog;
using NLog.Web;

// Configurar NLog antes de construir el builder
var logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();
logger.Info("========== Iniciando API Seguimiento CADS ==========");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Configurar el ambiente
    var environment = builder.Environment.EnvironmentName;
    logger.Info($"Ambiente detectado: {environment}");

    // -----------------------------
    // Configuración de Logging con NLog
    // -----------------------------
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Registrar AppLogger en DI
    builder.Services.AddScoped(typeof(IAppLogger<>), typeof(AppLogger<>));

    // -----------------------------
    // Configuración de Servicios
    // -----------------------------
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

    // Versionamiento de API
    builder.Services.AddApiVersioning(options =>
    {
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.ReportApiVersions = true;
    }).AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

    // Servicios de la aplicación
    builder.Services.AddHttpClient<IHttpClientService, HttpClientService>();
    builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
    builder.Services.AddScoped<IServiciosExternosHandler, ServiciosExternosHandler>();

    // -----------------------------
    // Construcción y configuración de la app
    // -----------------------------
    var app = builder.Build();

    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }
        });
    }

    app.UseMiddleware<RequestIdMiddleware>();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.UseMiddleware<GlobalExceptionMiddleware>();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Fatal(ex, "La aplicación se detuvo inesperadamente durante el inicio");
    throw;
}
finally
{
    logger.Info("========== Cerrando API Seguimiento CADS ==========");
    LogManager.Shutdown();
}

/// <summary>
/// Clase Program parcial para pruebas de integración.
/// </summary>
public partial class Program
{
}