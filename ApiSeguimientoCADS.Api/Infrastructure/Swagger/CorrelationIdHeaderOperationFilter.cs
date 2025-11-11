// <copyright file="CorrelationIdHeaderOperationFilter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Infrastructure.Swagger
{
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System;
    using System.Linq;

    /// <summary>
    /// Agrega la definición del encabezado <c>X-Correlation-Id</c> a la documentación de Swagger.
    /// </summary>
    internal sealed class CorrelationIdHeaderOperationFilter : IOperationFilter
    {
        /// <inheritdoc />
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            ArgumentNullException.ThrowIfNull(operation);
            ArgumentNullException.ThrowIfNull(context);

            operation.Parameters ??= Array.Empty<OpenApiParameter>();

            if (operation.Parameters.Any(parameter => parameter.In == ParameterLocation.Header && parameter.Name == "X-Correlation-Id"))
            {
                return;
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "X-Correlation-Id",
                In = ParameterLocation.Header,
                Description = "Identificador único para rastrear la solicitud.",
                Required = true,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Format = "uuid",
                },
            });
        }
    }
}