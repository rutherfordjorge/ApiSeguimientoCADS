// <copyright file="HeaderBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Headers
{
    using System;

    /// <summary>
    /// Representa la información estándar incluida en las respuestas HTTP.
    /// </summary>
    public sealed class HeaderBase
    {
        /// <summary>
        /// Obtiene o establece el identificador correlacional para rastreo.
        /// </summary>
        public string CorrelationId { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Obtiene o establece el mensaje de estado asociado a la respuesta.
        /// </summary>
        public string Message { get; set; } = "Operación ejecutada correctamente.";
    }
}