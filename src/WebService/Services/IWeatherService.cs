using System.Collections.Generic;
using WebService.Models;

namespace WebService.Services
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> GetForecast();
    }
}