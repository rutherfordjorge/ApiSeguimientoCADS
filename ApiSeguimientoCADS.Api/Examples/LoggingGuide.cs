// <copyright file="LoggingGuide.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Examples
{
    using ApiSeguimientoCADS.Api.Helpers;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// GUÍA COMPLETA DE LOGGING PARA EL EQUIPO
    /// =========================================
    /// Esta clase contiene TODOS los ejemplos de cómo usar el sistema de logging
    /// en la aplicación ApiSeguimientoCADS.
    /// IMPORTANTE: Esta clase es SOLO de referencia/documentación.
    /// NO debe ser instanciada en producción.
    /// NIVELES DE LOG POR AMBIENTE:
    /// ----------------------------
    /// Development: Trace, Debug, Info, Warn, Error, Fatal
    /// QA:          Debug, Info, Warn, Error, Fatal
    /// Production:  Error, Fatal (ocasionalmente Warn)
    /// CUÁNDO USAR CADA NIVEL:
    /// -----------------------
    /// Trace:   Detalle exhaustivo para debugging profundo (solo Development)
    /// Debug:   Información útil para depuración (Development y QA)
    /// Info:    Flujo normal de la aplicación, eventos importantes
    /// Warn:    Situaciones anómalas que NO detienen el flujo
    /// Error:   Errores que requieren atención pero la app continúa
    /// Fatal:   Fallos críticos que pueden terminar la aplicación
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)] // Ocultar de Swagger
    public class LoggingGuide : ControllerBase
    {
        // ============================================================================
        // SECCIÓN 1: INYECCIÓN DEL LOGGER
        // ============================================================================

        /// <summary>
        /// El logger se inyecta a través del constructor usando IAppLogger genérico.
        /// El tipo genérico debe ser la clase donde se usa el logger.
        /// Esto permite identificar fácilmente QUÉ clase generó el log.
        /// </summary>
        private readonly IAppLogger<LoggingGuide> _logger;

        /// <summary>
        /// Constructor que recibe el logger por inyección de dependencias.
        /// SIEMPRE usar IAppLogger en lugar de ILogger de Microsoft.
        /// </summary>
        /// <param name="logger">Logger inyectado por el contenedor DI</param>
        public LoggingGuide(IAppLogger<LoggingGuide> logger)
        {
            // Validar que el logger no sea nulo (buena práctica)
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // ============================================================================
        // SECCIÓN 2: LOGS SIMPLES POR NIVEL
        // ============================================================================

        /// <summary>
        /// Ejemplo 1: LOG DE NIVEL INFO
        /// ---------------------------
        /// Usar para registrar el flujo normal de la aplicación.
        /// Ejemplo: "Usuario inició sesión", "Orden creada", "Proceso completado"
        /// CUÁNDO USAR:
        /// - Eventos importantes del negocio
        /// - Inicio/fin de procesos principales
        /// - Confirmación de operaciones exitosas
        /// </summary>
        public void EjemploLogInfo()
        {
            // Forma 1: Mensaje simple
            this._logger.Info("Usuario accedió al sistema correctamente");

            // Forma 2: Mensaje con interpolación (recomendado para incluir datos)
            var usuarioId = 12345;
            this._logger.Info($"Usuario {usuarioId} inició sesión exitosamente");

            // Forma 3: Mensaje con múltiples líneas (para mejor legibilidad)
            this._logger.Info(
                $"Orden de servicio creada exitosamente{Environment.NewLine}" +
                $"  - ID Orden: 9876{Environment.NewLine}" +
                $"  - Cliente: Juan Pérez{Environment.NewLine}" +
                $"  - Monto: $150.000");
        }

        /// <summary>
        /// Ejemplo 2: LOG DE NIVEL DEBUG
        /// ----------------------------
        /// Usar para información que ayuda a depurar problemas.
        /// NO debe usarse en producción (solo Development/QA).
        /// CUÁNDO USAR:
        /// - Variables intermedias durante desarrollo
        /// - Valores antes/después de transformaciones
        /// - Pasos detallados de algoritmos complejos
        /// </summary>
        public void EjemploLogDebug()
        {
            // Ejemplo: Registrar valores de variables durante procesamiento
            var entrada = "12345678-9";
            var resultado = entrada.Replace("-", string.Empty, StringComparison.Ordinal);
            this._logger.Debug($"Limpieza de RUT - Entrada: '{entrada}' -> Salida: '{resultado}'");

            // Ejemplo: Registrar estado de objetos complejos
            var cliente = new { Id = 100, Nombre = "Ana", Activo = true };
            this._logger.Debug($"Estado del objeto cliente: {System.Text.Json.JsonSerializer.Serialize(cliente)}");
        }

        /// <summary>
        /// Ejemplo 3: LOG DE NIVEL WARN (WARNING)
        /// -------------------------------------
        /// Usar para situaciones anómalas que NO impiden continuar.
        /// CUÁNDO USAR:
        /// - Validaciones que fallan pero tienen fallback
        /// - Datos faltantes con valores por defecto
        /// - Llamadas a servicios externos que fallan pero tienen retry
        /// - Configuraciones incorrectas que no son críticas
        /// </summary>
        public void EjemploLogWarn()
        {
            // Ejemplo 1: Configuración faltante con valor por defecto
            this._logger.LogError(
                "Configuración 'TimeoutSegundos' no encontrada. Usando valor por defecto: 30 segundos");

            // Ejemplo 2: Validación fallida con fallback
            var email = "correo_invalido";
            this._logger.LogError(
                $"Email '{email}' tiene formato inválido. Se omitirá el envío de notificación");

            // Ejemplo 3: Servicio externo no disponible con manejo de error
            this._logger.LogError(
                "Servicio de notificaciones no respondió. El proceso continuará sin notificar al cliente");
        }

        /// <summary>
        /// Ejemplo 4: LOG DE NIVEL ERROR
        /// ----------------------------
        /// Usar cuando ocurre un error que requiere atención.
        /// El sistema continúa funcionando pero algo falló.
        /// CUÁNDO USAR:
        /// - Excepciones capturadas en try-catch
        /// - Validaciones críticas que fallan
        /// - Errores de BD, API externa, filesystem, etc.
        /// </summary>
        public void EjemploLogError()
        {
            try
            {
                // Simular operación que falla
                throw new InvalidOperationException("No se puede procesar la orden sin cliente");
            }
            catch (InvalidOperationException ex)
            {
                // IMPORTANTE: Siempre pasar la excepción al logger
                this._logger.LogError(ex);

                // También puedes agregar contexto adicional
                var ordenId = 456;
                this._logger.LogError($"Error al procesar orden {ordenId}: {ex.Message}");
            }
        }

        /// <summary>
        /// Ejemplo 5: LOG DE NIVEL FATAL
        /// ----------------------------
        /// Usar SOLO para errores críticos que pueden terminar la aplicación.
        /// CUÁNDO USAR:
        /// - Fallas en conexión a BD principal
        /// - Configuración crítica faltante
        /// - OutOfMemoryException
        /// - Recursos críticos no disponibles
        /// NOTA: Los logs FATAL deben ser monitoreados 24/7 en producción.
        /// </summary>
        public void EjemploLogFatal()
        {
            try
            {
                // Simular error crítico
                throw new InvalidOperationException("Configuración crítica 'ConnectionString' no encontrada. La aplicación no puede continuar.");
            }
            catch (InvalidOperationException ex)
            {
                // Registrar como FATAL
                this._logger.LogError(ex);
                this._logger.LogError("LA APLICACIÓN NO PUEDE CONTINUAR - Memoria agotada");

                // En este punto, normalmente la aplicación debería cerrarse
                // Environment.Exit(1);
            }
        }

        // ============================================================================
        // SECCIÓN 3: MEDICIÓN DE RENDIMIENTO (StartProcess / EndProcess)
        // ============================================================================

        /// <summary>
        /// Ejemplo 6: MEDIR TIEMPO DE EJECUCIÓN DE UN MÉTODO
        /// ------------------------------------------------
        /// Usar StartProcess/EndProcess para medir cuánto tarda un método.
        /// El logger automáticamente registra el tiempo transcurrido.
        /// CUÁNDO USAR:
        /// - Métodos críticos de negocio
        /// - Operaciones de BD
        /// - Llamadas a APIs externas
        /// - Procesos batch o largos
        /// </summary>
        public void EjemploMedicionTiempo()
        {
            // Iniciar medición de tiempo
            // El método automáticamente captura el nombre del método actual
            var (processId, stopwatch) = this._logger.StartProcess();

            try
            {
                // Simular operación que toma tiempo
                System.Threading.Thread.Sleep(500); // 500ms

                // Hacer operaciones...
                var resultado = "Operación completada";

                // Finalizar medición de tiempo
                // El logger automáticamente calcula y registra el tiempo transcurrido
                this._logger.Info($"{resultado}");

                this._logger.EndProcess(processId, stopwatch);

                // Resultado: "End Process. Method: EjemploMedicionTiempo. Took: 500ms"
            }
            catch (Exception ex)
            {
                // Siempre finalizar la medición incluso si hay error
                this._logger.EndProcess(processId, stopwatch);
                this._logger.LogError(ex);
                throw;
            }
        }

        /// <summary>
        /// Ejemplo 7: MEDIR TIEMPO CON INPUT
        /// --------------------------------
        /// Similar al anterior pero registra también los parámetros de entrada.
        /// CUÁNDO USAR:
        /// - Cuando necesitas ver QUÉ datos recibió el método
        /// - Para depurar problemas con parámetros específicos
        /// - En métodos públicos de APIs
        /// </summary>
        public void EjemploMedicionConInput(int ordenId, string clienteRut)
        {
            // Crear objeto con los parámetros de entrada
            var input = new
            {
                OrdenId = ordenId,
                ClienteRut = LogHelper.MaskRut(clienteRut), // SIEMPRE enmascarar datos sensibles
            };

            // Iniciar medición registrando el input
            var (processId, stopwatch) = this._logger.StartProcess(input);

            try
            {
                // Hacer operaciones...
                System.Threading.Thread.Sleep(300);

                // Finalizar medición
                this._logger.EndProcess(processId, stopwatch);
            }
            catch (Exception ex)
            {
                this._logger.EndProcess(processId, stopwatch);
                this._logger.LogError(ex);
                throw;
            }
        }

        /// <summary>
        /// Ejemplo 8: MEDIR TIEMPO CON INPUT Y OUTPUT
        /// -----------------------------------------
        /// Registra parámetros de entrada Y resultado de salida.
        /// CUÁNDO USAR:
        /// - Métodos críticos donde necesitas auditar entrada/salida
        /// - Para debugging de transformaciones de datos
        /// - En integraciones con sistemas externos
        /// </summary>
        /// /// <param name="dato">Dato a procesar</param>
        /// <returns>El dato procesado en mayúsculas</returns>
        public string EjemploMedicionConInputOutput(string dato)
        {
            ArgumentNullException.ThrowIfNull(dato);

            // Input
            var input = new { Dato = dato };
            var (processId, stopwatch) = this._logger.StartProcess(input);

            try
            {
                // Procesar...
                var resultado = dato.ToUpperInvariant();

                // Output
                var output = new { Resultado = resultado };

                // Finalizar registrando el output
                this._logger.EndProcess(processId, stopwatch, output);

                return resultado;
            }
            catch (Exception ex)
            {
                this._logger.EndProcess(processId, stopwatch);
                this._logger.LogError(ex);
                throw;
            }
        }

        // ============================================================================
        // SECCIÓN 4: ENMASCARAMIENTO DE DATOS SENSIBLES
        // ============================================================================

        /// <summary>
        /// Ejemplo 9: ENMASCARAR RUT
        /// ------------------------
        /// NUNCA registrar RUTs completos en logs.
        /// Usar LogHelper.MaskRut() para enmascarar.
        /// IMPORTANTE: Esto cumple con GDPR y protección de datos personales.
        /// </summary>
        public void EjemploEnmascararRut()
        {
            var rutCompleto = "12345678-9";

            // ❌ INCORRECTO - NO hacer esto
            // this._logger.Info($"Procesando RUT: {rutCompleto}");

            // ✅ CORRECTO - Enmascarar el RUT
            var rutEnmascarado = LogHelper.MaskRut(rutCompleto);
            this._logger.Info($"Procesando RUT: {rutEnmascarado}");

            // Resultado en log: "Procesando RUT: ****8-9"
        }

        /// <summary>
        /// Ejemplo 10: ENMASCARAR EMAIL
        /// --------------------------
        /// NUNCA registrar emails completos en logs.
        /// Usar LogHelper.MaskEmail() para enmascarar.
        /// </summary>
        public void EjemploEnmascararEmail()
        {
            var emailCompleto = "juan.perez@empresa.cl";

            // ❌ INCORRECTO
            // this._logger.Info($"Enviando correo a: {emailCompleto}");

            // ✅ CORRECTO - Enmascarar el email
            var emailEnmascarado = LogHelper.MaskEmail(emailCompleto);
            this._logger.Info($"Enviando correo a: {emailEnmascarado}");

            // Resultado en log: "Enviando correo a: ju***@empresa.cl"
        }

        /// <summary>
        /// Ejemplo 11: NUNCA REGISTRAR CONTRASEÑAS O TOKENS
        /// -----------------------------------------------
        /// JAMÁS debe aparecer una contraseña, token, API key en los logs.
        /// </summary>
        public void EjemploNoRegistrarCredenciales()
        {
            var password = "MiPassword123!";
            var token = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...";

            // ❌ NUNCA HACER ESTO
            this._logger.Info($"Usuario autenticado con password: {password}");
            this._logger.Info($"Token recibido: {token}");

            // ✅ CORRECTO - Solo registrar que la operación ocurrió
            this._logger.Info("Usuario autenticado exitosamente");
            this._logger.Info("Token JWT validado correctamente");
        }

        // ============================================================================
        // SECCIÓN 5: LOGS EN DIFERENTES CAPAS DE LA APLICACIÓN
        // ============================================================================

        /// <summary>
        /// Ejemplo 12: LOGS EN CONTROLLERS
        /// ------------------------------
        /// En controllers se debe registrar:
        /// - Entrada al endpoint (Request)
        /// - Salida del endpoint (Response)
        /// - Errores capturados
        /// </summary>
        /// /// <param name="id">Identificador del recurso a consultar</param>
        /// <returns>Resultado de la operación con código HTTP 200 o 500</returns>
        [HttpGet("ejemplo-controller")]
        public IActionResult EjemploLogEnController([FromQuery] int id)
        {
            // Registrar entrada al endpoint
            this._logger.Info($"[GET] /ejemplo-controller - ID: {id}");

            var (processId, stopwatch) = this._logger.StartProcess(new { Id = id });

            try
            {
                // Lógica del controller...
                var resultado = new { Mensaje = "OK", Data = id };

                // Registrar salida exitosa
                this._logger.EndProcess(processId, stopwatch, resultado);
                this._logger.Info("[GET] /ejemplo-controller - Respuesta 200 OK");

                return this.Ok(resultado);
            }
            catch (InvalidOperationException ex)
            {
                // Registrar error
                this._logger.EndProcess(processId, stopwatch);
                this._logger.LogError(ex);
                this._logger.LogError($"[GET] /ejemplo-controller - Respuesta 500 Error");

                return this.StatusCode(500, new { Error = "Error interno del servidor" });
            }
        }

        /// <summary>
        /// Ejemplo 13: LOGS EN HANDLERS/SERVICES
        /// ------------------------------------
        /// En handlers/services se debe registrar:
        /// - Inicio/fin de operaciones de negocio
        /// - Validaciones importantes
        /// - Transformaciones de datos
        /// </summary>
        public void EjemploLogEnHandler(string dato)
        {
            this._logger.Info("Handler: Iniciando procesamiento de orden");

            var (processId, stopwatch) = this._logger.StartProcess();

            try
            {
                // Validación
                if (string.IsNullOrEmpty(dato))
                {
                    this._logger.LogError("Validación fallida: dato es nulo o vacío");
                    throw new ArgumentException("El dato es requerido");
                }

                this._logger.Info("Validaciones completadas exitosamente");

                // Procesamiento
                this._logger.Debug($"Procesando dato: {dato}");
                var resultado = dato.ToUpperInvariant();
                this._logger.Debug($"Dato procesado: {resultado}");

                this._logger.EndProcess(processId, stopwatch);
                this._logger.Info("Handler: Procesamiento completado exitosamente");
            }
            catch (Exception ex)
            {
                this._logger.EndProcess(processId, stopwatch);
                this._logger.LogError(ex);
                throw;
            }
        }

        /// <summary>
        /// Ejemplo 14: LOGS EN REPOSITORIOS
        /// -------------------------------
        /// En repositorios se debe registrar:
        /// - Operaciones de BD (SELECT, INSERT, UPDATE, DELETE)
        /// - Tiempos de ejecución de queries
        /// - Errores de BD
        /// </summary>
        public void EjemploLogEnRepositorio(int clienteId)
        {
            this._logger.Info($"Repository: Consultando cliente ID {clienteId}");

            var (processId, stopwatch) = this._logger.StartProcess(new { ClienteId = clienteId });

            try
            {
                // Simular consulta a BD
                this._logger.Debug($"Ejecutando query: SELECT * FROM Clientes WHERE Id = {clienteId}");

                System.Threading.Thread.Sleep(100); // Simular tiempo de BD

                // Registrar resultado
                var encontrado = true;
                if (encontrado)
                {
                    this._logger.Info($"Cliente {clienteId} encontrado en BD");
                }
                else
                {
                    this._logger.LogError($"Cliente {clienteId} NO encontrado en BD");
                }

                this._logger.EndProcess(processId, stopwatch);
                this._logger.Info($"Repository: Consulta completada en {stopwatch.ElapsedMilliseconds}ms");
            }
            catch (Exception ex)
            {
                this._logger.EndProcess(processId, stopwatch);
                this._logger.LogError(ex);
                this._logger.LogError($"Repository: Error al consultar cliente {clienteId}");
                throw;
            }
        }

        // ============================================================================
        // SECCIÓN 6: LOGS ASÍNCRONOS
        // ============================================================================

        /// <summary>
        /// Ejemplo 15: LOGS EN MÉTODOS ASÍNCRONOS
        /// -------------------------------------
        /// Los métodos async/await funcionan igual con el logger.
        /// </summary>
        /// <returns>Tarea asíncrona que representa la operación de logging</returns>
        public async Task EjemploLogAsync()
        {
            this._logger.Info("Iniciando operación asíncrona");

            var (processId, stopwatch) = this._logger.StartProcess();

            try
            {
                // Operación asíncrona
                await Task.Delay(500).ConfigureAwait(false);

                this._logger.Info("Operación asíncrona completada");
                this._logger.EndProcess(processId, stopwatch);
            }
            catch (Exception ex)
            {
                this._logger.EndProcess(processId, stopwatch);
                this._logger.LogError(ex);
                throw;
            }
        }

        // ============================================================================
        // SECCIÓN 7: LOGS CON CONTEXTO (X-Request-ID)
        // ============================================================================

        /// <summary>
        /// Ejemplo 16: USO DE X-Request-ID
        /// ------------------------------
        /// El middleware RequestIdMiddleware automáticamente agrega X-Request-ID
        /// a todos los logs. NO necesitas hacer nada especial.
        /// Cada request HTTP tendrá un ID único para rastrear todos sus logs.
        /// Ejemplo de log con X-Request-ID:
        /// "X-Request-ID: 123e4567-e89b-12d3-a456-426614174000 | Usuario accedió al sistema"
        /// </summary>
        public void EjemploUsoRequestId()
        {
            // El RequestIdMiddleware ya se encargó de agregar el X-Request-ID
            // Solo debes usar el logger normalmente
            this._logger.Info("Este log automáticamente incluye X-Request-ID");

            // El X-Request-ID se puede obtener desde HttpContext si lo necesitas
            // var requestId = HttpContext.Items["X-Request-ID"];
        }

        // ============================================================================
        // SECCIÓN 8: BUENAS PRÁCTICAS Y RECOMENDACIONES
        // ============================================================================

        /// <summary>
        /// Ejemplo 17: FORMATO DE MENSAJES DE LOG
        /// -------------------------------------
        /// Recomendaciones para escribir buenos mensajes de log:
        /// </summary>
        public void EjemploBuenasPracticas()
        {
            // ✅ BUENO: Mensaje claro y con contexto
            var ordenId = 123;
            var clienteId = 456;
            this._logger.Info($"Orden {ordenId} creada para cliente {clienteId} exitosamente");

            // ✅ BUENO: Incluir valores relevantes
            var monto = 150000;
            this._logger.Info($"Pago procesado - Monto: ${monto:N0} CLP");

            // ✅ BUENO: Usar verbo en tiempo pasado para eventos completados
            this._logger.Info("Email enviado correctamente");

            // ✅ BUENO: Usar presente para estado actual
            this._logger.Info("Procesando solicitud...");

            // ❌ MALO: Mensaje genérico sin contexto
            // this._logger.Info("Operación exitosa");

            // ❌ MALO: Demasiado verboso
            // this._logger.Info("Se está iniciando el proceso de validación de la orden número 123 para el cliente número 456 en el sistema de gestión de órdenes");

            // ❌ MALO: Sin información útil
            // this._logger.Info("OK");
        }

        /// <summary>
        /// Ejemplo 18: NIVELES POR AMBIENTE
        /// -------------------------------
        /// Guía de qué registrar en cada ambiente:
        /// </summary>
        public void EjemploNivelesPorAmbiente()
        {
            // ===== DEVELOPMENT =====
            // Registrar TODO para debugging
            this._logger.Info("Info: Flujo de negocio");
            this._logger.Debug("Debug: Variables intermedias");

            // ===== QA =====
            // Registrar flujo de negocio y errores
            this._logger.Info("Info: Eventos importantes");
            this._logger.LogError("Error: Validación fallida");

            // ===== PRODUCTION =====
            // Registrar SOLO errores y eventos críticos de negocio
            this._logger.Info("Info: Orden creada");
            this._logger.LogError("Error: Falla en integración");

            // NO registrar Debug en Production
            // this._logger.Debug("Esto NO aparecerá en Production");
        }

        // ============================================================================
        // SECCIÓN 9: CHECKLIST ANTES DE HACER COMMIT
        // ============================================================================

        /// <summary>
        /// CHECKLIST DE LOGGING ANTES DE HACER COMMIT:
        /// ==========================================
        /// □ Verificar que NO hay contraseñas, tokens o API keys en logs
        /// □ Verificar que RUTs están enmascarados con LogHelper.MaskRut()
        /// □ Verificar que emails están enmascarados con LogHelper.MaskEmail()
        /// □ Verificar que métodos importantes tienen StartProcess/EndProcess
        /// □ Verificar que todos los try-catch tienen _logger.LogError(ex)
        /// □ Verificar que los mensajes son claros y con contexto
        /// □ Verificar que NO hay logs Debug en código que va a Production
        /// □ Verificar que los niveles de log son apropiados
        /// □ Verificar que NO hay información confidencial del cliente
        /// □ Verificar que NO hay datos médicos o financieros sensibles
        /// RECUERDA:
        /// --------
        /// - Los logs son para DEBUGGING y AUDITORÍA
        /// - NUNCA pongas información que no quieres que vean otros
        /// - Los logs pueden ser requeridos en auditorías legales
        /// - SIEMPRE enmascara datos personales
        /// </summary>
        public void ChecklistDeLogging()
        {
            // Esta función es solo documentación
            // No implementa lógica
        }
    }
}