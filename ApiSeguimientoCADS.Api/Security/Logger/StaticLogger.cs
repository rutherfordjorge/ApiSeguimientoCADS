// <copyright file="StaticLogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Security.Logger
{
    using NLog;
    using System;
    using System.Globalization;
    using System.Text;
    using LogLevel = Microsoft.Extensions.Logging.LogLevel;

    /// <summary>
    /// Clase estática que escribe los mensajes en logger según corresponda el grado.
    /// </summary>
    public static class StaticLogger
    {
        private const string _redAsciiColor = "\x1b[31m";

        /// <summary>
        /// Log de información.
        /// </summary>
        /// <param name="logger">Tipo de logger.</param>
        /// <param name="mensaje">Mensaje.</param>
        public static void LogInfo(Type logger, string mensaje)
        {
            ArgumentNullException.ThrowIfNull(logger);

            var nlogger = LogManager.GetLogger(logger.FullName ?? string.Empty);

            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeFormateado = new StringBuilder();

                mensajeFormateado.AppendLine();
                mensajeFormateado.AppendLine(CultureInfo.InvariantCulture, $"**********{DateTime.Now}:{LogLevel.Information}**********");
                mensajeFormateado.AppendLine();
                mensajeFormateado.AppendLine(mensaje);

                nlogger.Info(mensajeFormateado);
                mensajeFormateado.Clear();
            }
        }

        /// <summary>
        /// Log de warning.
        /// </summary>
        /// <param name="logger">Tipo de logger.</param>
        /// <param name="mensaje">Mensaje.</param>
        public static void LogWarning(Type logger, string mensaje)
        {
            ArgumentNullException.ThrowIfNull(logger);

            var nlogger = LogManager.GetLogger(logger.FullName ?? string.Empty);

            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeFormateado = new StringBuilder();

                mensajeFormateado.AppendLine();
                mensajeFormateado.AppendLine(CultureInfo.InvariantCulture, $"**********{DateTime.Now}:{LogLevel.Warning}**********");
                mensajeFormateado.AppendLine(mensaje);

                nlogger.Warn(mensajeFormateado);
                mensajeFormateado.Clear();
            }
        }

        /// <summary>
        /// Log de debug.
        /// </summary>
        /// <param name="logger">Tipo de logger.</param>
        /// <param name="mensaje">Mensaje.</param>
        public static void LogDebug(Type logger, string mensaje)
        {
            ArgumentNullException.ThrowIfNull(logger);

            var nlogger = LogManager.GetLogger(logger.FullName ?? string.Empty);

            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeFormateado = new StringBuilder();

                mensajeFormateado.AppendLine();
                mensajeFormateado.AppendLine(CultureInfo.InvariantCulture, $"**********{DateTime.Now}:{LogLevel.Debug}**********");
                mensajeFormateado.AppendLine(mensaje);

                nlogger.Debug(mensajeFormateado);
                mensajeFormateado.Clear();
            }
        }

        /// <summary>
        /// Log de error.
        /// </summary>
        /// <param name="logger">Tipo de logger.</param>
        /// <param name="mensaje">Mensaje.</param>
        public static void LogError(Type logger, string mensaje)
        {
            ArgumentNullException.ThrowIfNull(logger);

            var nlogger = LogManager.GetLogger(logger.FullName ?? string.Empty);

            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeFormateado = new StringBuilder();

                mensajeFormateado.AppendLine();
                mensajeFormateado.AppendLine(CultureInfo.InvariantCulture, $"{_redAsciiColor}**********{DateTime.Now}:{LogLevel.Error}**********");
                mensajeFormateado.AppendLine(CultureInfo.InvariantCulture, $"{_redAsciiColor}{mensaje}");

                nlogger.Error(mensajeFormateado);
                mensajeFormateado.Clear();
            }
        }
    }
}