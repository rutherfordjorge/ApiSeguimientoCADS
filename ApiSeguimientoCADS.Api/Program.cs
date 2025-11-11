// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ApiSeguimientoCADS.Api.Configuration;
using ApiSeguimientoCADS.Api.Middlewares;
using ApiSeguimientoCADS.Api.Security.Logger;
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
    Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");

    // CORS Configuration
    // WARNING: This policy allows all origins, methods, and headers.
    // This is appropriate for internal APIs or APIs behind authentication layers.
    // Consider restricting to specific origins in production if needed.
    #pragma warning disable S5122 // Having a permissive Cross-Origin Resource Sharing policy is security-sensitive
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
    });
    #pragma warning restore S5122

    // Configurar el ambiente
    var environment = builder.Environment.EnvironmentName;
    logger.Info($"Ambiente detectado: {environment}");

    // -----------------------------
    // Configuración de Logging con NLog
    // -----------------------------
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Registrar AppLogger en DI como Singleton
    // AppLogger no tiene estado mutable por request, puede ser Singleton
    // Esto permite su uso en servicios Singleton como ResiliencePolicyService
    builder.Services.AddSingleton(typeof(IAppLogger<>), typeof(AppLogger<>));
    builder.Services.AddHealthChecks();

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
    builder.AddSeguimientoCadsSettingsMap();
    builder.AddSeguimientoCadsServices();
    builder.AddSeguimientoCadsSecurity();

    // -----------------------------
    // Construcción y configuración de la app
    // -----------------------------
    var app = builder.Build();

    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        provider.ApiVersionDescriptions
            .OrderByDescending(d => d.ApiVersion)
            .Select(description => (description.GroupName, Url: $"/swagger/{description.GroupName}/swagger.json"))
            .ToList()
            .ForEach(item => options.SwaggerEndpoint(item.Url, item.GroupName.ToUpperInvariant()));
    });

    // CorrelationId debe ir primero para que todos los logs tengan el ID
    app.UseMiddleware<CorrelationIdMiddleware>();
    app.UseMiddleware<GlobalExceptionMiddleware>();
    app.UseCors("AllowAll");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapHealthChecks("/health");
    app.MapControllers();

    await app.RunAsync().ConfigureAwait(false);
}
catch (Exception ex)
{
    var wrapped = new InvalidOperationException("Error fatal al iniciar la API Seguimiento CADS.", ex);
    logger.Fatal(ex, wrapped.Message);
    throw wrapped;
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
    /// <summary>
    /// Constructor protegido para prevenir instanciación directa.
    /// </summary>
    protected Program()
    {
    }
}