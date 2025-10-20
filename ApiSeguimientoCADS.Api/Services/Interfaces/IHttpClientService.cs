// <copyright file="IHttpClientService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Services.Interfaces
{
    using ApiSeguimientoCADS.Api.Services.Models;
    using System.Threading;

    /// <summary>
    /// Define un contrato para el servicio responsable de realizar solicitudes HTTP genéricas
    /// (GET, POST, PUT, DELETE, etc.) hacia servicios externos.
    /// Esta interfaz abstrae el uso de <see cref="HttpClient"/> y permite una fácil reutilización,
    /// prueba e inyección de dependencias en toda la aplicación.
    /// </summary>
    public interface IHttpClientService
    {
        /// <summary>
        /// Envía una solicitud HTTP asíncrona a un servicio externo y obtiene la respuesta tipada.
        /// </summary>
        /// <typeparam name="T">
        /// Tipo de dato esperado en la respuesta.
        /// Debe coincidir con la estructura del contenido JSON devuelto por el servicio remoto.
        /// </typeparam>
        /// <param name="request">
        /// Objeto <see cref="ApiRequest"/> que contiene toda la información necesaria para ejecutar la solicitud,
        /// como la URL, el método HTTP, los encabezados, el cuerpo y el token de autenticación.
        /// </param>
        /// <returns>
        /// Retorna un objeto <see cref="ApiResponse{T}"/> que contiene la información resultante de la operación,
        /// incluyendo el contenido deserializado, el código de estado HTTP y la respuesta en formato bruto (raw).
        /// </returns>
        Task<ApiResponse<T>> SendAsync<T>(ApiRequest request, CancellationToken cancellationToken = default);
    }
}