// <copyright file="AppLogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Security.Logger
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.Encodings.Web;
    using System.Text.Json;

    /// <summary>
    /// Implementación del logger de la aplicación.
    /// </summary>
    /// <typeparam name="T">Tipo de clase que usa el logger.</typeparam>
    public class AppLogger<T> : IAppLogger<T>
    {
        private const string _blueAsciiColor = "\x1b[34m";
        private const string _greenAsciiColor = "\x1b[32m";
        private const string _redAsciiColor = "\x1b[31m";
        private static readonly string _genericName = typeof(T).Name;

        private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        // Delegados LoggerMessage para mejor performance
        private static readonly Action<ILogger, string, Exception?> _logDebugMessage =
            LoggerMessage.Define<string>(
                LogLevel.Debug,
                new EventId(1, nameof(Debug)),
                "{Message}");

        private static readonly Action<ILogger, string, Exception?> _logInfoMessage =
            LoggerMessage.Define<string>(
                LogLevel.Information,
                new EventId(2, nameof(Info)),
                "{Message}");

        private static readonly Action<ILogger, string, Exception?> _logErrorMessage =
            LoggerMessage.Define<string>(
                LogLevel.Error,
                new EventId(3, nameof(LogError)),
                "{Message}");

        private static readonly Action<ILogger, string, Exception?> _logKeyMessage =
            LoggerMessage.Define<string>(
                LogLevel.Information,
                new EventId(4, "LogKey"),
                "{Key}");

        private readonly ILogger<T> _logger;
        private string _key = _genericName;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AppLogger{T}"/>.
        /// </summary>
        /// <param name="logger">Logger de Microsoft.</param>
        public AppLogger(ILogger<T> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Registra mensajes de debug.
        /// </summary>
        /// <param name="messages">Mensajes a registrar.</param>
        /// <returns>Instancia del logger.</returns>
        public IAppLogger<T> Debug(params object?[] messages) => this.Log(LogLevel.Debug, messages);

        /// <summary>
        /// Registra mensajes informativos.
        /// </summary>
        /// <param name="messages">Mensajes a registrar.</param>
        /// <returns>Instancia del logger.</returns>
        public IAppLogger<T> Info(params object?[] messages) => this.Log(LogLevel.Information, messages);

        /// <summary>
        /// Registra mensajes de error.
        /// </summary>
        /// <param name="messages">Mensajes a registrar.</param>
        /// <returns>Instancia del logger.</returns>
        public IAppLogger<T> LogError(params object?[] messages) => this.Log(LogLevel.Error, messages);

        /// <summary>
        /// Registra una excepción.
        /// </summary>
        /// <param name="ex">Excepción a registrar.</param>
        /// <returns>Instancia del logger.</returns>
        public IAppLogger<T> LogError(Exception ex)
        {
            ArgumentNullException.ThrowIfNull(ex);

            // Log el mensaje de la excepción primero
            _logErrorMessage(this._logger, $"{_redAsciiColor}Exception: {ex.Message}", ex);

            // Luego el detalle completo
            this.BaseErrorLogs(ex);

            return this;
        }

        /// <summary>
        /// Inicia el proceso de medición de tiempo.
        /// </summary>
        /// <param name="methodName">Nombre del método.</param>
        /// <returns>Tupla con el ID del proceso y el cronómetro.</returns>
        public (Guid ProcessId, Stopwatch Stopwatch) StartProcess(string methodName = "")
        {
            var id = Guid.NewGuid();
            this._key = $"{_genericName}|{id}";
            this.Info($"Start Process. Method: {methodName}");
            return (id, Stopwatch.StartNew());
        }

        /// <summary>
        /// Inicia el proceso con input.
        /// </summary>
        /// <param name="input">Datos de entrada.</param>
        /// <param name="methodName">Nombre del método.</param>
        /// <returns>Tupla con el ID del proceso y el cronómetro.</returns>
        public (Guid ProcessId, Stopwatch Stopwatch) StartProcess(object input, string methodName = "")
        {
            this.Info("Input received");
            this.Debug(input);
            return this.StartProcess(methodName);
        }

        /// <summary>
        /// Finaliza el proceso de medición.
        /// </summary>
        /// <param name="id">ID del proceso.</param>
        /// <param name="sw">Cronómetro.</param>
        /// <param name="methodName">Nombre del método.</param>
        public void EndProcess(Guid id, Stopwatch sw, string methodName = "")
        {
            ArgumentNullException.ThrowIfNull(sw);

            sw.Stop();
            this.Info($"End Process. Method: {methodName}. Took: {sw.Elapsed.TotalMilliseconds}ms");
        }

        /// <summary>
        /// Finaliza el proceso con output.
        /// </summary>
        /// <param name="id">ID del proceso.</param>
        /// <param name="sw">Cronómetro.</param>
        /// <param name="output">Datos de salida.</param>
        /// <param name="methodName">Nombre del método.</param>
        public void EndProcess(Guid id, Stopwatch sw, object output, string methodName = "")
        {
            this.EndProcess(id, sw, methodName);
            this.Info("Output returned");
            this.Debug(output);
        }

        private static string[] ProcessMessages(params object?[] messages)
        {
            return messages
                .Where(m => m is not null)
                .Select(m => m as string ?? JsonSerializer.Serialize(m, _jsonSerializerOptions))
                .ToArray();
        }

        private void BaseErrorLogs(Exception ex)
        {
            new BciExceptionLog().RecibirExcepcion(ex, this.GetType());
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1859:Use concrete types when possible for improved performance", Justification = "El método privado debe retornar IAppLogger<T> para mantener consistencia con la API fluent pública")]

        private IAppLogger<T> Log(LogLevel level, params object?[] messages)
        {
            Action<ILogger, string, Exception?> logAction = level switch
            {
                LogLevel.Debug => _logDebugMessage,
                LogLevel.Information => _logInfoMessage,
                LogLevel.Error => _logErrorMessage,
                _ => throw new ArgumentOutOfRangeException(nameof(level), level, null),
            };

            var colorPrefix = level switch
            {
                LogLevel.Debug => _blueAsciiColor,
                LogLevel.Information => _greenAsciiColor,
                LogLevel.Error => _redAsciiColor,
                _ => string.Empty,
            };

            foreach (var message in ProcessMessages(messages))
            {
                _logKeyMessage(this._logger, $"{_greenAsciiColor}At {this._key}", null);
                logAction(this._logger, $"{colorPrefix}{message}", null);
            }

            return this;
        }
    }
}