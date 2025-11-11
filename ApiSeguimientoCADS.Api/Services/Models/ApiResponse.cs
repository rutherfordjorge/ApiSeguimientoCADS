// <copyright file="ApiResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Services.Models
{
    using System.Net;

    /// <summary>
    /// Representa una respuesta genérica obtenida al realizar una solicitud HTTP a un servicio externo.
    /// Esta clase encapsula tanto la información del resultado deserializado como los metadatos de la respuesta.
    /// </summary>
    /// <typeparam name="T">
    /// Tipo de dato esperado en la respuesta del servicio.
    /// Por ejemplo, puede ser un modelo de dominio, una lista de objetos o un tipo primitivo.
    /// </typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Obtiene o establece el contenido deserializado de la respuesta HTTP.
        /// Si la solicitud fue exitosa, este valor contendrá el objeto de tipo <typeparamref name="T"/>
        /// obtenido a partir del cuerpo de la respuesta.
        /// </summary>
        /// <example>
        /// <code>
        /// ApiResponse respuesta = await apiClient.GetAsync("https://servicio.qa.bciseguros.cl:7577/apiseguimiento/service/usuario/1");
        /// var usuario = respuesta.Data;
        /// </code>
        /// </example>
        public T? Data { get; set; }

        /// <summary>
        /// Obtiene o establece el código de estado HTTP devuelto por el servidor.
        /// Este valor indica el resultado de la operación, por ejemplo:
        /// <see cref="HttpStatusCode.OK"/>, <see cref="HttpStatusCode.BadRequest"/>, <see cref="HttpStatusCode.InternalServerError"/>, etc.
        /// </summary>
        /// <example>
        /// <code>
        /// if (respuesta.StatusCode == HttpStatusCode.NotFound)
        /// {
        ///     Console.WriteLine("El recurso no fue encontrado.");
        /// }
        /// </code>
        /// </example>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Obtiene o establece el contenido sin procesar (raw) de la respuesta HTTP en formato texto.
        /// Útil para depuración o para escenarios donde no se desea o no se puede deserializar el cuerpo.
        /// </summary>
        /// <remarks>
        /// Este valor contiene exactamente el cuerpo de la respuesta HTTP devuelto por el servidor,
        /// antes de intentar convertirlo a un objeto de tipo <typeparamref name="T"/>.
        /// </remarks>
        /// <example>
        /// <code>
        /// Console.WriteLine($"Respuesta completa: {respuesta.RawResponse}");
        /// </code>
        /// </example>
        public string RawResponse { get; set; } = string.Empty;

        /// <summary>
        /// Indica si la respuesta se considera exitosa en función del código de estado HTTP.
        /// Retorna <see langword="true"/> cuando el código está en el rango 200–299; de lo contrario, retorna <see langword="false"/>.
        /// </summary>
        /// <example>
        /// <code>
        /// if (respuesta.IsSuccess)
        /// {
        ///     Console.WriteLine("La solicitud fue exitosa.");
        /// }
        /// else
        /// {
        ///     Console.WriteLine($"Error: {respuesta.StatusCode}");
        /// }
        /// </code>
        /// </example>
        public bool IsSuccess => (int)this.StatusCode >= 200 && (int)this.StatusCode < 300;
    }
}