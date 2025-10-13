// <copyright file="ValidationException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Exceptions
{
    using System;

    /// <summary>
    /// Excepción que representa un error de validación.
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ValidationException"/>.
        /// </summary>
        public ValidationException()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ValidationException"/> con un mensaje específico.
        /// </summary>
        /// <param name="message">Mensaje descriptivo del error.</param>
        public ValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ValidationException"/> con un mensaje y una excepción interna.
        /// </summary>
        /// <param name="message">Mensaje descriptivo del error.</param>
        /// <param name="innerException">Excepción interna que causó el error.</param>
        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}