namespace ApiSeguimientoCADS.Tests.Services
{
    using ApiSeguimientoCADS.Api.Services;
    using System.Linq;
    using Xunit;

    /// <summary>
    /// Pruebas unitarias para <see cref="WeatherForecastService"/>.
    /// </summary>
    public sealed class WeatherForecastServiceTests
    {
        [Fact]
        public void GetForecasts_WithValidCity_ReturnsFiveRecords()
        {
            var service = new WeatherForecastService();

            var result = service.GetForecasts("Santiago");

            Assert.Equal(5, result.Count);
        }

        [Theory]
        [InlineData("Santiago")]
        [InlineData("Valparaiso")]
        [InlineData("Concepcion")]
        public void GetForecasts_WithDifferentCities_ReturnsDeterministicForecasts(string city)
        {
            var service = new WeatherForecastService();

            var firstCall = service.GetForecasts(city);
            var secondCall = service.GetForecasts(city);

            Assert.Equal(firstCall.Select(forecast => forecast.TemperatureC), secondCall.Select(forecast => forecast.TemperatureC));
        }
    }
}
