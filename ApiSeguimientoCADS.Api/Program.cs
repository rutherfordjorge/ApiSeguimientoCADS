// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ApiSeguimientoCADS.Api.Configuration;
using ApiSeguimientoCADS.Api.Handlers;
using ApiSeguimientoCADS.Api.Handlers.Interfaces;
using ApiSeguimientoCADS.Api.Middlewares;
using ApiSeguimientoCADS.Api.Services;
using ApiSeguimientoCADS.Api.Services.Interfaces;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using NLog.Extensions.Logging;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------
// Configuración de Logging
// -----------------------------
// -----------------------------
// Configuración de Logging
// -----------------------------
builder.Logging.ClearProviders();

if (builder.Environment.IsDevelopment())
{
    builder.Logging.AddConsole();
    builder.Logging.AddNLog(builder.Configuration.GetSection("NLog"));
}
else
{
    builder.Logging.AddConsole();

    // Si deseas habilitar NLog también fuera de desarrollo, descomenta la siguiente línea:
    // builder.Logging.AddNLog(builder.Configuration.GetSection("NLog"));
}

builder.Host.UseNLog();

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
builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddSingleton<IWeatherForecastHandler, WeatherForecastHandler>();
builder.Services.AddSingleton<ApiSeguimientoCADS.Api.Infrastructure.Repositories.IProductRepository, ApiSeguimientoCADS.Api.Infrastructure.Repositories.InMemoryProductRepository>();
builder.Services.AddSingleton<IProductHandler, ProductHandler>();
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

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.MapControllers();

app.Run();

/// <summary>
/// Clase Program parcial para pruebas de integración.
/// </summary>
public partial class Program
{
}