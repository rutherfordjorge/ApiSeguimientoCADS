// <copyright file="IExternalServiceResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Models.Responses
{
    using System.Collections.Generic;

    /// <summary>
    /// Define la estructura est�ndar para las respuestas provenientes de un servicio externo.
    /// Esta interfaz permite uniformar el manejo de resultados de diferentes integraciones.
    /// </summary>
    /// <typeparam name="TItem">El tipo de elemento contenido en la respuesta externa.</typeparam>
    public interface IExternalServiceResponse<out TItem>
    {
        /// <summary>
        /// Obtiene el c�digo de estado devuelto por el servicio externo.
        /// Por ejemplo: <c>"200"</c> para respuestas exitosas.
        /// </summary>
        string Status { get; }

        /// <summary>
        /// Obtiene el mensaje adicional o comentario proporcionado por el servicio externo.
        /// Puede contener informaci�n �til en caso de errores o advertencias.
        /// </summary>
        string Comentario { get; }

        /// <summary>
        /// Obtiene la lista de elementos devueltos por la operaci�n externa.
        /// Si la respuesta no contiene datos, esta propiedad puede ser <c>null</c> o vac�a.
        /// </summary>
        IReadOnlyList<TItem>? Data { get; }
    }
}