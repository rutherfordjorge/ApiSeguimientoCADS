// <copyright file="HeaderValidationAttribute.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Security
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;

    /// <summary>
    /// Valida que el encabezado <c>X-Correlation-Id</c> esté presente en cada solicitud.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    internal sealed class HeaderValidationAttribute : Attribute, IActionFilter
    {
        /// <inheritdoc />
        public void OnActionExecuting(ActionExecutingContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            if (!context.HttpContext.Request.Headers.TryGetValue("X-Correlation-Id", out var correlationId) || string.IsNullOrWhiteSpace(correlationId))
            {
                context.Result = new BadRequestObjectResult(new
                {
                    Message = "El encabezado X-Correlation-Id es obligatorio.",
                });
            }
        }

        /// <inheritdoc />
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No se requiere implementación posterior a la acción.
        }
    }
}