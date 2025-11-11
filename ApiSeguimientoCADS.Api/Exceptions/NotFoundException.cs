// <copyright file="NotFoundException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Exceptions
{
    using System;

    /// <summary>
    /// Excepción que representa un recurso no encontrado.
    /// </summary>
    /// <remarks>
    /// Esta excepción no implementa ISerializable porque la serialización binaria está
    /// obsoleta en .NET moderno. Para APIs REST/JSON, la serialización se maneja mediante
    /// el middleware GlobalExceptionMiddleware que convierte excepciones a JSON.
    /// </remarks>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NotFoundException"/>.
        /// </summary>
        public NotFoundException()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NotFoundException"/> con un mensaje específico.
        /// </summary>
        /// <param name="message">Mensaje descriptivo del error.</param>
        public NotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NotFoundException"/> con un mensaje y una excepción interna.
        /// </summary>
        /// <param name="message">Mensaje descriptivo del error.</param>
        /// <param name="innerException">Excepción interna que causó el error.</param>
        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}