// <copyright file="ApiRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Services.Models
{
    /// <summary>
    /// Representa una solicitud HTTP genérica que puede ser enviada a un servicio externo.
    /// Esta clase abstrae los datos necesarios para realizar una petición con <see cref="HttpClient"/>.
    /// </summary>
    public class ApiRequest
    {
        /// <summary>
        /// Obtiene o establece la dirección completa (URI) del recurso al cual se enviará la solicitud.
        /// Se recomienda que esta propiedad siempre contenga una dirección válida y absoluta.
        /// </summary>
        /// <example>
        /// Ejemplo: <c>https://servicio.qa.bciseguros.cl:7577/apiseguimiento/service/usuarios</c>
        /// </example>
        public Uri Url { get; set; } = null!;

        /// <summary>
        /// Obtiene o establece el método HTTP que se utilizará para la solicitud.
        /// Por defecto, se inicializa con <see cref="HttpMethod.Get"/>.
        /// </summary>
        /// <remarks>
        /// Algunos métodos comunes son:
        /// <list type="bullet">
        /// <item><description><see cref="HttpMethod.Get"/> - Para obtener recursos.</description></item>
        /// <item><description><see cref="HttpMethod.Post"/> - Para crear recursos o enviar datos.</description></item>
        /// <item><description><see cref="HttpMethod.Put"/> - Para reemplazar un recurso existente.</description></item>
        /// <item><description><see cref="HttpMethod.Delete"/> - Para eliminar un recurso.</description></item>
        /// </list>
        /// </remarks>
        public HttpMethod Method { get; set; } = HttpMethod.Get;

        /// <summary>
        /// Obtiene o establece el contenido o cuerpo (payload) que se enviará con la solicitud.
        /// Este valor puede ser cualquier tipo de objeto, generalmente serializado a JSON antes del envío.
        /// </summary>
        /// <example>
        /// Ejemplo de cuerpo:
        /// <code>
        /// new { Nombre = "Pepito", Activo = true }
        /// </code>
        /// </example>
        public object? Body { get; set; }

        /// <summary>
        /// Obtiene la colección de encabezados (headers) personalizados que se enviarán junto con la solicitud HTTP.
        /// </summary>
        /// <remarks>
        /// - La colección es de solo lectura; sin embargo, se pueden agregar o modificar elementos internamente.<br/>
        /// - Cada elemento representa un par clave-valor del encabezado HTTP.
        /// </remarks>
        /// <example>
        /// <code>
        /// request.Headers["X-Custom-Header"] = "MiValor";
        /// </code>
        /// </example>
        public Dictionary<string, string> Headers { get; } = new();

        /// <summary>
        /// Obtiene o establece el token Bearer utilizado para la autenticación en la solicitud.
        /// Si se establece, este valor se incluirá en el encabezado "Authorization" de la forma:
        /// <c>Authorization: Bearer {token}</c>
        /// </summary>
        /// <example>
        /// <code>
        /// request.BearerToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...";
        /// </code>
        /// </example>
        public string? BearerToken { get; set; }
    }
}