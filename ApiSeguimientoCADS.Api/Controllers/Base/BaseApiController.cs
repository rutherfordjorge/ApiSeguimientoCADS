// <copyright file="BaseApiController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Controllers
{
    using ApiSeguimientoCADS.Api.Models.Responses;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Clase base abstracta para controladores de API que proporciona una implementación común para:
    /// <list type="bullet">
    /// <item>🔸 Registro de logs estandarizado.</item>
    /// <item>🔸 Manejo centralizado de errores.</item>
    /// <item>🔸 Validación de solicitudes y construcción de respuestas estándar.</item>
    /// </list>
    /// </summary>
    /// <typeparam name="TController">El tipo del controlador que hereda de esta clase.</typeparam>
    public abstract class BaseApiController<TController> : ControllerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseApiController{TController}"/>.
        /// </summary>
        /// <param name="logger">El registrador de logs para el controlador.</param>
        /// <exception cref="ArgumentNullException">
        /// Se produce si <paramref name="logger"/> es <c>null</c>.
        /// </exception>
        protected BaseApiController(IAppLogger<TController> logger)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Obtiene el registrador de logs asociado al controlador.
        /// </summary>
        protected IAppLogger<TController> Logger { get; }

        /// <summary>
        /// Ejecuta de forma asíncrona una operación estándar de API, incluyendo validación de entrada,
        /// registro de métricas, manejo de errores y retorno de una respuesta uniforme.
        /// </summary>
        /// <typeparam name="TRequest">El tipo de la solicitud recibida.</typeparam>
        /// <typeparam name="TData">El tipo de los datos devueltos en la respuesta.</typeparam>
        /// <param name="request">La solicitud de entrada para la operación.</param>
        /// <param name="logInputFactory">Función que construye un objeto para loguear la entrada.</param>
        /// <param name="requestReceivedMessage">Mensaje que se registra al recibir la solicitud.</param>
        /// <param name="operation">Función asíncrona que ejecuta la lógica principal de la operación.</param>
        /// <param name="successMetricsFactory">Función opcional que genera métricas cuando la operación es exitosa.</param>
        /// <param name="failureResultFactory">Función opcional que genera un resultado personalizado cuando la operación falla.</param>
        /// <param name="onSuccess">Acción opcional a ejecutar cuando la operación es exitosa.</param>
        /// <returns>
        /// Un <see cref="Task{TResult}"/> que representa la operación asíncrona.
        /// El resultado es un <see cref="IActionResult"/> que contiene la respuesta estándar de la API.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Se produce si <paramref name="operation"/> es <c>null</c>.
        /// </exception>
        protected async Task<IActionResult> ExecuteDefaultResponseAsync<TRequest, TData>(
            TRequest request,
            Func<TRequest?, object?> logInputFactory,
            string requestReceivedMessage,
            Func<TRequest, Task<DefaultResponse<TData>>> operation,
            Func<DefaultResponse<TData>, object?>? successMetricsFactory = null,
            Func<DefaultResponse<TData>, IActionResult>? failureResultFactory = null,
            Action<DefaultResponse<TData>>? onSuccess = null)
            where TRequest : class
        {
            var correlationId = this.EnsureCorrelationId();
            var logInput = logInputFactory?.Invoke(request) ?? new { CorrelationId = correlationId };

            this.Logger.Info(requestReceivedMessage);
            var (processId, stopwatch) = this.Logger.StartProcess(logInput);

            try
            {
                if (request == null)
                {
                    this.Logger.LogError("Request es nulo");
                    this.EndLoggingScope(processId, stopwatch);
                    var errorResponse = new DefaultResponse<TData>(false, "La solicitud no puede ser nula.", errorCode: "NULL_REQUEST");
                    return this.BadRequest(errorResponse);
                }

                if (!this.ModelState.IsValid)
                {
                    this.Logger.LogError("Request inválido: ModelState tiene errores");
                    this.EndLoggingScope(processId, stopwatch);
                    var validationResponse = CreateValidationErrorResponse<TData>(this.ModelState);
                    return this.BadRequest(validationResponse);
                }

                var response = await (operation ?? throw new ArgumentNullException(nameof(operation)))(request).ConfigureAwait(false);

                if (response.Success)
                {
                    onSuccess?.Invoke(response);
                    var metrics = successMetricsFactory?.Invoke(response);
                    this.EndLoggingScope(processId, stopwatch, metrics);
                    return this.Ok(response);
                }

                this.EndLoggingScope(processId, stopwatch);
                if (failureResultFactory != null)
                {
                    return failureResultFactory(response);
                }

                return this.BadRequest(response);
            }
            catch (InvalidOperationException ex)
            {
                this.Logger.LogError(ex);
                this.Logger.LogError($"Error de operación al procesar la solicitud: {ex.Message}");
                this.EndLoggingScope(processId, stopwatch);

                var errorResponse = new DefaultResponse<TData>(false, "Error al procesar la solicitud", errorCode: "OPERATION_ERROR");
                return this.BadRequest(errorResponse);
            }
        }

        /// <summary>
        /// Inicia un bloque de registro para una operación, registrando el mensaje de recepción de la solicitud
        /// y devolviendo el identificador de correlación, el identificador de proceso y el cronómetro.
        /// </summary>
        /// <param name="requestReceivedMessage">Mensaje que se registra al recibir la solicitud.</param>
        /// <param name="logInput">Objeto de entrada para el log.</param>
        /// <returns>
        /// Una tupla que contiene:
        /// <list type="bullet">
        /// <item><c>CorrelationId</c>: Identificador único de la solicitud.</item>
        /// <item><c>ProcessId</c>: Identificador único del proceso de log.</item>
        /// <item><c>Stopwatch</c>: Cronómetro que mide la duración de la operación.</item>
        /// </list>
        /// </returns>
        protected (string CorrelationId, Guid ProcessId, Stopwatch Stopwatch) StartLoggingScope(
            string requestReceivedMessage,
            object logInput)
        {
            var correlationId = this.EnsureCorrelationId();
            this.Logger.Info(requestReceivedMessage);
            var (processId, stopwatch) = this.Logger.StartProcess(logInput);
            return (correlationId, processId, stopwatch);
        }

        /// <summary>
        /// Finaliza un bloque de registro para una operación.
        /// </summary>
        /// <param name="processId">Identificador único del proceso de log.</param>
        /// <param name="stopwatch">Cronómetro asociado al proceso.</param>
        /// <param name="metrics">Métricas opcionales a registrar.</param>
        protected void EndLoggingScope(Guid processId, Stopwatch stopwatch, object? metrics = null)
        {
            this.Logger.EndProcess(processId, stopwatch, metrics!);
        }

        /// <summary>
        /// Garantiza que la solicitud tenga un identificador de correlación.
        /// Si no existe, se genera uno nuevo y se asocia al contexto HTTP.
        /// </summary>
        /// <returns>El identificador de correlación de la solicitud.</returns>
        protected string EnsureCorrelationId()
        {
            var correlationId = this.HttpContext.Items["X-Request-ID"]?.ToString() ?? Guid.NewGuid().ToString();
            this.HttpContext.Items["CorrelationId"] = correlationId;
            return correlationId;
        }

        /// <summary>
        /// Crea una respuesta estándar de error de validación a partir de errores del <see cref="ModelStateDictionary"/>.
        /// </summary>
        /// <typeparam name="TData">El tipo de datos esperado en la respuesta.</typeparam>
        /// <param name="modelState">El estado del modelo que contiene los errores de validación.</param>
        /// <returns>
        /// Un <see cref="DefaultResponse{TData}"/> con la información de los errores de validación.
        /// </returns>
        private static DefaultResponse<TData> CreateValidationErrorResponse<TData>(ModelStateDictionary modelState)
        {
            var errors = string.Join(", ", modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            return new DefaultResponse<TData>(false, $"Errores de validación: {errors}", errorCode: "VALIDATION_ERROR");
        }
    }
}