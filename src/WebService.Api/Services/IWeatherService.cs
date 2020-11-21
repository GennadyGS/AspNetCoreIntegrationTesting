using System.Collections.Generic;
using WebService.Api.Models;

namespace WebService.Api.Services
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> GetForecast();
    }
}