// <copyright file="ResiliencePolicyService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Services
{
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services.Interfaces;
    using Polly;
    using Polly.CircuitBreaker;
    using Polly.Retry;
    using Polly.Timeout;
    using System;
    using System.Security.Cryptography;

    /// <summary>
    /// ResiliencePolicyService - Implementa políticas de resiliencia centralizadas
    /// </summary>
    public class ResiliencePolicyService : IResiliencePolicyService
    {
        private readonly IAppLogger<ResiliencePolicyService> _logger;

        /// <summary>
        /// Crea política de Bulkhead para limitar concurrencia (máx 5 paralelas, 10 en cola)
        /// </summary>
        /// <returns>ResiliencePipeline</returns>
        private static ResiliencePipeline CreateBulkheadPipeline()
        {
            // Limitar concurrencia: máximo 5 llamadas simultáneas, 10 en cola
            return new ResiliencePipelineBuilder()
                .AddConcurrencyLimiter(permitLimit: 5, queueLimit: 10)
                .Build();
        }

        /// <summary>
        /// ResiliencePolicyService - Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        public ResiliencePolicyService(IAppLogger<ResiliencePolicyService> logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));

            this.RetryPipeline = this.CreateRetryPipeline();
            this.CircuitBreakerPipeline = this.CreateCircuitBreakerPipeline();
            this.TimeoutPipeline = this.CreateTimeoutPipeline();
            this.BulkheadPipeline = CreateBulkheadPipeline();
        }

        /// <inheritdoc/>
        public ResiliencePipeline RetryPipeline { get; }

        /// <inheritdoc/>
        public ResiliencePipeline CircuitBreakerPipeline { get; }

        /// <inheritdoc/>
        public ResiliencePipeline TimeoutPipeline { get; }

        /// <inheritdoc/>
        public ResiliencePipeline BulkheadPipeline { get; }

        /// <summary>
        /// Crea política de retry con exponential backoff: 0.5s, 1s
        /// </summary>
        /// <returns>ResiliencePipeline</returns>
        private ResiliencePipeline CreateRetryPipeline()
        {
            return new ResiliencePipelineBuilder()
                .AddRetry(new RetryStrategyOptions
                {
                    MaxRetryAttempts = 2,
                    Delay = TimeSpan.FromMilliseconds(500),
                    BackoffType = DelayBackoffType.Exponential,
                    UseJitter = true,
                    OnRetry = args =>
                    {
                        this._logger.Info($"[Retry] Intento {args.AttemptNumber} después de {args.RetryDelay.TotalSeconds}s - {args.Outcome.Exception?.Message}");
                        return ValueTask.CompletedTask;
                    },
                    ShouldHandle = new PredicateBuilder()
                        .Handle<HttpRequestException>()
                        .Handle<TaskCanceledException>()
                        .Handle<TimeoutRejectedException>(),
                })
                .Build();
        }

        /// <summary>
        /// Crea política de Circuit Breaker + Retry para servicios críticos
        /// Abre tras 5 fallos consecutivos, permanece abierto 30s
        /// </summary>
        /// <returns>ResiliencePipeline</returns>
        private ResiliencePipeline CreateCircuitBreakerPipeline()
        {
            var circuitBreaker = new ResiliencePipelineBuilder()
                .AddCircuitBreaker(new CircuitBreakerStrategyOptions
                {
                    FailureRatio = 0.5, // 50% de fallos
                    MinimumThroughput = 5, // Mínimo 5 llamadas para evaluar
                    SamplingDuration = TimeSpan.FromSeconds(30), // Ventana de 30s
                    BreakDuration = TimeSpan.FromSeconds(30), // Permanece abierto 30s
                    OnOpened = args =>
                    {
                        this._logger.LogError($"[Circuit Breaker] Circuito ABIERTO - Servicio degradado por {args.BreakDuration.TotalSeconds}s");
                        return ValueTask.CompletedTask;
                    },
                    OnClosed = args =>
                    {
                        this._logger.Info("[Circuit Breaker] Circuito CERRADO - Servicio recuperado");
                        return ValueTask.CompletedTask;
                    },
                    OnHalfOpened = args =>
                    {
                        this._logger.Info("[Circuit Breaker] Circuito SEMI-ABIERTO - Probando recuperación");
                        return ValueTask.CompletedTask;
                    },
                    ShouldHandle = new PredicateBuilder()
                        .Handle<HttpRequestException>()
                        .Handle<TaskCanceledException>()
                        .Handle<TimeoutRejectedException>(),
                })
                .Build();

            // Combinar con retry (2 intentos rápidos antes de abrir circuito)
            return new ResiliencePipelineBuilder()
                .AddRetry(new RetryStrategyOptions
                {
                    MaxRetryAttempts = 2,
                    Delay = TimeSpan.FromSeconds(1),
                    BackoffType = DelayBackoffType.Constant,
                    UseJitter = true,
                    OnRetry = args =>
                    {
                        this._logger.Info($"[CB Retry] Intento {args.AttemptNumber} - {args.Outcome.Exception?.Message}");
                        return ValueTask.CompletedTask;
                    },
                    ShouldHandle = new PredicateBuilder()
                        .Handle<HttpRequestException>()
                        .Handle<TaskCanceledException>()
                        .Handle<TimeoutRejectedException>(),
                })
                .AddPipeline(circuitBreaker)
                .Build();
        }

        /// <summary>
        /// Crea política de Timeout optimista (10s por intento) + Retry con jitter
        /// </summary>
        /// <returns>ResiliencePipeline</returns>
        private ResiliencePipeline CreateTimeoutPipeline()
        {
            return new ResiliencePipelineBuilder()
                .AddRetry(new RetryStrategyOptions
                {
                    MaxRetryAttempts = 3,
                    DelayGenerator = args =>
                    {
                        // Exponential backoff con jitter usando generador seguro
                        var baseDelay = TimeSpan.FromSeconds(Math.Pow(2, args.AttemptNumber));
                        var jitter = TimeSpan.FromMilliseconds(RandomNumberGenerator.GetInt32(0, 1001));
                        return ValueTask.FromResult<TimeSpan?>(baseDelay + jitter);
                    },
                    OnRetry = args =>
                    {
                        this._logger.Info($"[Timeout Retry] Intento {args.AttemptNumber} después de timeout - {args.Outcome.Exception?.Message}");
                        return ValueTask.CompletedTask;
                    },
                    ShouldHandle = new PredicateBuilder()
                        .Handle<HttpRequestException>()
                        .Handle<TaskCanceledException>()
                        .Handle<TimeoutRejectedException>(),
                })
                .AddTimeout(new TimeoutStrategyOptions
                {
                    Timeout = TimeSpan.FromSeconds(10),
                    OnTimeout = args =>
                    {
                        this._logger.LogError($"[Timeout] Operación excedió 10s - {args.Context.OperationKey}");
                        return ValueTask.CompletedTask;
                    },
                })
                .Build();
        }
    }
}