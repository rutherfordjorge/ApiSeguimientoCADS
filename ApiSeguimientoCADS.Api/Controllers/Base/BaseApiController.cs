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

    public abstract class BaseApiController<TController> : ControllerBase
    {
        protected BaseApiController(IAppLogger<TController> logger)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected IAppLogger<TController> Logger { get; }

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
                    var validationResponse = this.CreateValidationErrorResponse<TData>(this.ModelState);
                    return this.BadRequest(validationResponse);
                }

                var response = await operation(request).ConfigureAwait(false);

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

        protected (string CorrelationId, string ProcessId, Stopwatch Stopwatch) StartLoggingScope(
            string requestReceivedMessage,
            object logInput)
        {
            var correlationId = this.EnsureCorrelationId();
            this.Logger.Info(requestReceivedMessage);
            var (processId, stopwatch) = this.Logger.StartProcess(logInput);
            return (correlationId, processId, stopwatch);
        }

        protected void EndLoggingScope(string processId, Stopwatch stopwatch, object? metrics = null)
        {
            this.Logger.EndProcess(processId, stopwatch, metrics);
        }

        protected string EnsureCorrelationId()
        {
            var correlationId = this.HttpContext.Items["X-Request-ID"]?.ToString() ?? Guid.NewGuid().ToString();
            this.HttpContext.Items["CorrelationId"] = correlationId;
            return correlationId;
        }

        private DefaultResponse<TData> CreateValidationErrorResponse<TData>(ModelStateDictionary modelState)
        {
            var errors = string.Join(", ", modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            return new DefaultResponse<TData>(false, $"Errores de validación: {errors}", errorCode: "VALIDATION_ERROR");
        }
    }
}
