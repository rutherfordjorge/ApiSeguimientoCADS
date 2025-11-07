// <copyright file="IAppLogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Security.Logger
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Interfaz para el logger de la aplicación.
    /// </summary>
    /// <typeparam name="T">Tipo de clase que usa el logger.</typeparam>
    public interface IAppLogger<T>
    {
        /// <summary>
        /// Registra mensajes de debug.
        /// </summary>
        /// <param name="messages">Mensajes a registrar.</param>
        /// <returns>Instancia del logger.</returns>
        IAppLogger<T> Debug(params object?[] messages);

        /// <summary>
        /// Registra mensajes informativos.
        /// </summary>
        /// <param name="messages">Mensajes a registrar.</param>
        /// <returns>Instancia del logger.</returns>
        IAppLogger<T> Info(params object?[] messages);

        /// <summary>
        /// Registra mensajes de error.
        /// </summary>
        /// <param name="messages">Mensajes a registrar.</param>
        /// <returns>Instancia del logger.</returns>
        IAppLogger<T> LogError(params object?[] messages);

        /// <summary>
        /// Registra una excepción.
        /// </summary>
        /// <param name="ex">Excepción a registrar.</param>
        /// <returns>Instancia del logger.</returns>
        IAppLogger<T> LogError(Exception ex);

        /// <summary>
        /// Registra una excepción con mensaje personalizado.
        /// </summary>
        /// <param name="ex">Excepción a registrar.</param>
        /// <param name="message">Mensaje personalizado.</param>
        /// <returns>Instancia del logger.</returns>
        IAppLogger<T> LogError(Exception ex, string message);

        /// <summary>
        /// Inicia el proceso de medición de tiempo.
        /// </summary>
        /// <param name="methodName">Nombre del método.</param>
        /// <returns>Tupla con el ID del proceso y el cronómetro.</returns>
        (Guid ProcessId, Stopwatch Stopwatch) StartProcess([CallerMemberName] string methodName = "");

        /// <summary>
        /// Inicia el proceso con input.
        /// </summary>
        /// <param name="input">Datos de entrada.</param>
        /// <param name="methodName">Nombre del método.</param>
        /// <returns>Tupla con el ID del proceso y el cronómetro.</returns>
        (Guid ProcessId, Stopwatch Stopwatch) StartProcess(object input, [CallerMemberName] string methodName = "");

        /// <summary>
        /// Finaliza el proceso de medición.
        /// </summary>
        /// <param name="id">ID del proceso.</param>
        /// <param name="sw">Cronómetro.</param>
        /// <param name="methodName">Nombre del método.</param>
        void EndProcess(Guid id, Stopwatch sw, [CallerMemberName] string methodName = "");

        /// <summary>
        /// Finaliza el proceso con output.
        /// </summary>
        /// <param name="id">ID del proceso.</param>
        /// <param name="sw">Cronómetro.</param>
        /// <param name="output">Datos de salida.</param>
        /// <param name="methodName">Nombre del método.</param>
        void EndProcess(Guid id, Stopwatch sw, object output, [CallerMemberName] string methodName = "");
    }
}