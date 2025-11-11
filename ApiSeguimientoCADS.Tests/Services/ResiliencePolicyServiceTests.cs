// <copyright file="ResiliencePolicyServiceTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Tests.Services
{
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Services;
    using Moq;
    using NUnit.Framework;
    using Polly.Bulkhead;
    using Polly.CircuitBreaker;
    using Polly.Timeout;
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Pruebas unitarias para <see cref="ResiliencePolicyService"/>.
    /// </summary>
    [TestFixture]
    public sealed class ResiliencePolicyServiceTests
    {
        private Mock<IAppLogger<ResiliencePolicyService>> _loggerMock = null!;
        private ResiliencePolicyService _service = null!;

        [SetUp]
        public void SetUp()
        {
            this._loggerMock = new Mock<IAppLogger<ResiliencePolicyService>>();
            this._service = new ResiliencePolicyService(this._loggerMock.Object);
        }

        [Test]
        public void Constructor_WhenLoggerIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ResiliencePolicyService(null!));
        }

        [Test]
        public void Constructor_InitializesAllPipelines()
        {
            // Assert
            Assert.That(this._service.RetryPipeline, Is.Not.Null);
            Assert.That(this._service.CircuitBreakerPipeline, Is.Not.Null);
            Assert.That(this._service.TimeoutPipeline, Is.Not.Null);
            Assert.That(this._service.BulkheadPipeline, Is.Not.Null);
        }

        #region RetryPipeline Tests

        [Test]
        public async Task RetryPipeline_OnSuccess_ExecutesOnce()
        {
            // Arrange
            var executionCount = 0;

            // Act
            await this._service.RetryPipeline.ExecuteAsync(async _ =>
            {
                executionCount++;
                await Task.CompletedTask;
            }, CancellationToken.None);

            // Assert
            Assert.That(executionCount, Is.EqualTo(1));
        }

        [Test]
        public async Task RetryPipeline_OnHttpRequestException_RetriesUpToMaxAttempts()
        {
            // Arrange
            var executionCount = 0;

            // Act & Assert
            Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                await this._service.RetryPipeline.ExecuteAsync(async _ =>
                {
                    executionCount++;
                    await Task.CompletedTask;
                    throw new HttpRequestException("Test error");
                }, CancellationToken.None);
            });

            // Should execute initial attempt + 2 retries = 3 total
            Assert.That(executionCount, Is.EqualTo(3));
        }

        [Test]
        public async Task RetryPipeline_OnTaskCanceledException_RetriesUpToMaxAttempts()
        {
            // Arrange
            var executionCount = 0;

            // Act & Assert
            Assert.ThrowsAsync<TaskCanceledException>(async () =>
            {
                await this._service.RetryPipeline.ExecuteAsync(async _ =>
                {
                    executionCount++;
                    await Task.CompletedTask;
                    throw new TaskCanceledException("Test timeout");
                }, CancellationToken.None);
            });

            // Should execute initial attempt + 2 retries = 3 total
            Assert.That(executionCount, Is.EqualTo(3));
        }

        [Test]
        public async Task RetryPipeline_OnSuccessAfterRetry_ReturnsResult()
        {
            // Arrange
            var executionCount = 0;

            // Act
            var result = await this._service.RetryPipeline.ExecuteAsync(async _ =>
            {
                executionCount++;
                if (executionCount < 2)
                {
                    throw new HttpRequestException("Temporary error");
                }

                return await Task.FromResult("Success");
            }, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo("Success"));
            Assert.That(executionCount, Is.EqualTo(2));
        }

        #endregion

        #region CircuitBreakerPipeline Tests

        [Test]
        public async Task CircuitBreakerPipeline_OnSuccess_ExecutesNormally()
        {
            // Arrange
            var executionCount = 0;

            // Act
            await this._service.CircuitBreakerPipeline.ExecuteAsync(async _ =>
            {
                executionCount++;
                await Task.CompletedTask;
            }, CancellationToken.None);

            // Assert
            Assert.That(executionCount, Is.EqualTo(1));
        }

        [Test]
        public async Task CircuitBreakerPipeline_IncludesRetryBeforeCircuitBreaker()
        {
            // Arrange
            var executionCount = 0;

            // Act & Assert - Should retry before breaking circuit
            Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                await this._service.CircuitBreakerPipeline.ExecuteAsync(async _ =>
                {
                    executionCount++;
                    await Task.CompletedTask;
                    throw new HttpRequestException("Test error");
                }, CancellationToken.None);
            });

            // Should have retried (initial + 2 retries = 3)
            Assert.That(executionCount, Is.EqualTo(3));
        }

        #endregion

        #region TimeoutPipeline Tests

        [Test]
        public async Task TimeoutPipeline_WhenOperationCompletesQuickly_Succeeds()
        {
            // Arrange & Act
            var result = await this._service.TimeoutPipeline.ExecuteAsync(async _ =>
            {
                await Task.Delay(10); // Quick operation
                return "Success";
            }, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo("Success"));
        }

        [Test]
        public void TimeoutPipeline_WhenOperationExceedsTimeout_ThrowsTimeoutException()
        {
            // Act & Assert
            Assert.ThrowsAsync<TimeoutRejectedException>(async () =>
            {
                await this._service.TimeoutPipeline.ExecuteAsync(async _ =>
                {
                    await Task.Delay(15000); // Exceeds 10s timeout
                    return "Should not reach here";
                }, CancellationToken.None);
            });
        }

        [Test]
        public async Task TimeoutPipeline_IncludesRetryOnFailure()
        {
            // Arrange
            var executionCount = 0;

            // Act
            var result = await this._service.TimeoutPipeline.ExecuteAsync(async _ =>
            {
                executionCount++;
                if (executionCount < 2)
                {
                    throw new HttpRequestException("Temporary error");
                }

                return await Task.FromResult("Success");
            }, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo("Success"));
            Assert.That(executionCount, Is.GreaterThanOrEqualTo(2));
        }

        #endregion

        #region BulkheadPipeline Tests

        [Test]
        public async Task BulkheadPipeline_AllowsUpToConcurrencyLimit()
        {
            // Arrange
            var tasks = new ValueTask[5]; // Max concurrency is 5

            // Act
            for (int i = 0; i < 5; i++)
            {
                tasks[i] = this._service.BulkheadPipeline.ExecuteAsync(async _ =>
                {
                    await Task.Delay(50);
                }, CancellationToken.None);
            }

            // Assert - All 5 should complete without throwing BulkheadRejectedException
            foreach (var task in tasks)
            {
                Assert.DoesNotThrowAsync(async () => await task);
            }
        }

        [Test]
        public async Task BulkheadPipeline_RejectsWhenConcurrencyAndQueueAreFull()
        {
            // Arrange
            var longRunningTasks = new List<ValueTask>(); // Fill concurrency limit

            // Start 5 long-running tasks to fill concurrency
            for (int i = 0; i < 5; i++)
            {
                longRunningTasks.Add(this._service.BulkheadPipeline.ExecuteAsync(async _ =>
                {
                    await Task.Delay(1000); // Long operation
                }, CancellationToken.None));
            }

            // Give tasks time to start
            await Task.Delay(50);

            // Queue up to the limit (10 items)
            var queuedTasks = new List<ValueTask>();
            for (int i = 0; i < 10; i++)
            {
                queuedTasks.Add(this._service.BulkheadPipeline.ExecuteAsync(async _ =>
                {
                    await Task.Delay(100);
                }, CancellationToken.None));
            }

            // Give queued tasks time to queue
            await Task.Delay(50);

            // Act & Assert - 16th concurrent request should be rejected
            Assert.ThrowsAsync<BulkheadRejectedException>(async () =>
            {
                await this._service.BulkheadPipeline.ExecuteAsync(async _ =>
                {
                    await Task.Delay(100);
                }, CancellationToken.None);
            });

            // Cleanup - wait for all tasks to complete or timeout
            await Task.Delay(2000);
        }

        [Test]
        public async Task BulkheadPipeline_OnSuccess_ReturnsResult()
        {
            // Act
            var result = await this._service.BulkheadPipeline.ExecuteAsync(async _ =>
            {
                await Task.Delay(10);
                return "Success";
            }, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo("Success"));
        }

        #endregion

        #region Integration Tests

        [Test]
        public async Task AllPipelines_CanBeUsedIndependently()
        {
            // Arrange
            var expectedValue = "test-value";

            // Act
            var retryResult = await this._service.RetryPipeline.ExecuteAsync(
                async _ => await Task.FromResult(expectedValue),
                CancellationToken.None);

            var circuitBreakerResult = await this._service.CircuitBreakerPipeline.ExecuteAsync(
                async _ => await Task.FromResult(expectedValue),
                CancellationToken.None);

            var timeoutResult = await this._service.TimeoutPipeline.ExecuteAsync(
                async _ => await Task.FromResult(expectedValue),
                CancellationToken.None);

            var bulkheadResult = await this._service.BulkheadPipeline.ExecuteAsync(
                async _ => await Task.FromResult(expectedValue),
                CancellationToken.None);

            // Assert
            Assert.That(retryResult, Is.EqualTo(expectedValue));
            Assert.That(circuitBreakerResult, Is.EqualTo(expectedValue));
            Assert.That(timeoutResult, Is.EqualTo(expectedValue));
            Assert.That(bulkheadResult, Is.EqualTo(expectedValue));
        }

        [Test]
        public async Task RetryPipeline_HandlesMultipleExceptionTypes()
        {
            // Arrange
            var executionCount = 0;

            // Act
            var result = await this._service.RetryPipeline.ExecuteAsync(async _ =>
            {
                executionCount++;

                if (executionCount == 1)
                {
                    throw new HttpRequestException("First error");
                }

                if (executionCount == 2)
                {
                    throw new TaskCanceledException("Second error");
                }

                return await Task.FromResult("Success");
            }, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo("Success"));
            Assert.That(executionCount, Is.EqualTo(3));
        }

        #endregion
    }
}
