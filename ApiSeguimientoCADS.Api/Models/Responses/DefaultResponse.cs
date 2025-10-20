// <copyright file="DefaultResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Responses
{
    /// <summary>
    /// Respuesta genérica estándar para el frontend Angular
    /// </summary>
    /// <typeparam name="T">Tipo de dato en la respuesta</typeparam>
    public class DefaultResponse<T>
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
        /// Código de error (opcional)
        /// </summary>
        public string? ErrorCode { get; set; }

        /// <summary>
        /// Timestamp de la respuesta (opcional)
        /// </summary>
        public string? Timestamp { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public DefaultResponse()
        {
            this.Timestamp = DateTime.UtcNow.ToString("o");
        }

        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="success">Indica si fue exitoso</param>
        /// <param name="message">Mensaje de respuesta</param>
        /// <param name="data">Datos de respuesta</param>
        /// <param name="errorCode">Código de error opcional</param>
        public DefaultResponse(bool success, string message, T? data = default, string? errorCode = null)
        {
            this.Success = success;
            this.Message = message;
            this.Data = data;
            this.ErrorCode = errorCode;
            this.Timestamp = DateTime.UtcNow.ToString("o");
        }
    }
}
