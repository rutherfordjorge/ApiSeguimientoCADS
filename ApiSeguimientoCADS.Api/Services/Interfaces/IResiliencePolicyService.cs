// <copyright file="IResiliencePolicyService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Services.Interfaces
{
    using Polly;

    /// <summary>
    /// IResiliencePolicyService - Servicio para gestionar políticas de resiliencia (Retry, Circuit Breaker, Timeout, Bulkhead)
    /// </summary>
    public interface IResiliencePolicyService
    {
        /// <summary>
        /// Política de retry con exponential backoff para HttpClientService
        /// </summary>
        ResiliencePipeline RetryPipeline { get; }

        /// <summary>
        /// Política de Circuit Breaker + Retry para servicios críticos como CadsService
        /// </summary>
        ResiliencePipeline CircuitBreakerPipeline { get; }

        /// <summary>
        /// Política de Timeout optimista + Retry para SiniestrosService
        /// </summary>
        ResiliencePipeline TimeoutPipeline { get; }

        /// <summary>
        /// Política de Bulkhead para limitar concurrencia en llamadas paralelas
        /// </summary>
        ResiliencePipeline BulkheadPipeline { get; }
    }
}