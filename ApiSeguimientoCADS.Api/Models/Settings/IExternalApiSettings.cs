// <copyright file="IExternalApiSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Settings
{
    /// <summary>
    /// Define la estructura de configuraci�n requerida para consumir un servicio externo.
    /// Esta interfaz permite parametrizar la URL y credenciales necesarias para realizar solicitudes HTTP.
    /// </summary>
    public interface IExternalApiSettings
    {
        /// <summary>
        /// Obtiene la URL completa o endpoint base del servicio externo.
        /// </summary>
        string Full { get; }

        /// <summary>
        /// Obtiene el token de autenticaci�n necesario para acceder al servicio externo.
        /// </summary>
        string AuthToken { get; }

        /// <summary>
        /// Obtiene el valor de la cookie que puede ser requerida por algunos servicios externos para autenticaci�n o sesi�n.
        /// </summary>
        string Cookie { get; }
    }
}