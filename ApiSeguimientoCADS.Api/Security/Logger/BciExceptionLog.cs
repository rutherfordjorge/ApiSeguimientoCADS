// <copyright file="BciExceptionLog.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Security.Logger
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Clase que se utilizará para controlar las excepciones dentro del sistema.
    /// </summary>
    public class BciExceptionLog
    {
        private const string _redAsciiColor = "\x1b[31m";

        /// <summary>
        /// Verifica si la excepción tiene inner exceptions.
        /// </summary>
        /// <param name="ex">Excepción.</param>
        /// <returns>True si tiene inner exception.</returns>
        public static bool ContieneInnerException(Exception ex)
        {
            ArgumentNullException.ThrowIfNull(ex);
            return ex.InnerException?.InnerException != null;
        }

        /// <summary>
        /// Obtiene el mensaje del inner exception.
        /// </summary>
        /// <param name="ex">Excepción.</param>
        /// <returns>Mensaje del inner exception.</returns>
        public static string ObtenerMensajeInnerException(Exception ex)
        {
            ArgumentNullException.ThrowIfNull(ex);

            var mensajeInner = string.Empty;

            if (ex.InnerException != null)
            {
                mensajeInner = ex.InnerException.Message;
                if (ex.InnerException.InnerException != null)
                {
                    mensajeInner += ex.InnerException.InnerException.Message;
                }
            }

            return mensajeInner;
        }

        /// <summary>
        /// Log informativo.
        /// </summary>
        /// <param name="mensaje">Mensaje a loggear.</param>
        /// <param name="tipo">Tipo de clase.</param>
        public static void LogInformativo(string mensaje, Type tipo)
        {
            StaticLogger.LogInfo(tipo, mensaje);
        }

        /// <summary>
        /// Recibe la excepción completa y el registro del log donde se originó la excepción.
        /// </summary>
        /// <param name="ex">Excepción.</param>
        /// <param name="logger">Tipo de logger.</param>
        /// <returns>Excepción procesada.</returns>
        public Exception RecibirExcepcion(Exception ex, Type logger)
        {
            ArgumentNullException.ThrowIfNull(ex);
            ArgumentNullException.ThrowIfNull(logger);

            var nLog = this.GetType();

            string origenExcepcion = ex.Source ?? "Sin origenExcepcion";
            string mensajeException = ex.Message;
            string? stackTraceExcepcion = ex.StackTrace ?? "Sin stackTraceExcepcion ";
            MethodBase? targetSiteExcepcion = ex.TargetSite;
            int excepcionId = ex.HResult;
            string mensajeInnerEx = ex.InnerException?.Message ?? string.Empty;

            if (ContieneInnerException(ex))
            {
                mensajeInnerEx = ObtenerMensajeInnerException(ex);
            }

            var mensajeEx = ConstruirMensaje(
                origenExcepcion,
                mensajeException,
                stackTraceExcepcion,
                targetSiteExcepcion,
                excepcionId,
                mensajeInnerEx);

            LogParaExcepcion(ex, mensajeEx, nLog);

            return ex;
        }

        private static void LogParaExcepcion(Exception ex, string mensajeEx, Type nLog)
        {
            StaticLogger.LogError(nLog, mensajeEx);
        }

        private static string ConstruirMensaje(
            string origenExcepcion,
            string mensajeException,
            string stackTraceExcepcion,
            MethodBase? targetSiteExcepcion,
            int excepcionId,
            string mensajeInnerEx)
        {
            var mensajeFormateado = new StringBuilder();

            mensajeFormateado.AppendLine(CultureInfo.InvariantCulture, $"{_redAsciiColor}-En Capa: {origenExcepcion}");
            mensajeFormateado.AppendLine(CultureInfo.InvariantCulture, $"{_redAsciiColor}-Mensaje exception: {mensajeException}");
            mensajeFormateado.AppendLine(CultureInfo.InvariantCulture, $"{_redAsciiColor}-Detalle: {stackTraceExcepcion?.Replace("at ", $"{_redAsciiColor}at ", StringComparison.Ordinal)}");
            mensajeFormateado.AppendLine(CultureInfo.InvariantCulture, $"{_redAsciiColor}-El Target Site es: {targetSiteExcepcion?.ToString() ?? "N/A"}\x1b;[31m");

            if (!string.IsNullOrEmpty(mensajeInnerEx))
            {
                mensajeFormateado.AppendLine(CultureInfo.InvariantCulture, $"{_redAsciiColor}-Mensaje Inner de la excepcion:{mensajeInnerEx}");
            }

            return mensajeFormateado.ToString();
        }
    }
}