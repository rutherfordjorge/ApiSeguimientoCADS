// <copyright file="FrontResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Common
{
    /// <summary>
    /// Respuesta genérica para Front
    /// </summary>
    /// <typeparam name="T">Tipo de dato de la respuesta</typeparam>
    public class FrontResponse<T>
    {
        /// <summary>
        /// Indica si la operación fue exitosa
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Mensaje descriptivo de la respuesta
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Datos de la respuesta
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Código de error opcional
        /// </summary>
        public string? ErrorCode { get; set; }

        /// <summary>
        /// Timestamp de la respuesta
        /// </summary>
        public string? Timestamp { get; set; }
    }
}