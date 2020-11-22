using System.Collections.Generic;
using WebService.Api.Services;
using WebService.Api.Models;

namespace WebApplicationTests.Mocks
{
    internal sealed class WeatherServiceMock : IWeatherService
    {
        public WeatherServiceMock(IReadOnlyCollection<WeatherForecast> forecast)
        {
            Forecast = forecast;
        }

        public IEnumerable<WeatherForecast> GetForecast() => Forecast;

        private IReadOnlyCollection<WeatherForecast> Forecast { get; }
    }
}