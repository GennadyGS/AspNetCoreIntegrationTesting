using System.Collections.Generic;
using WebService.Models;

namespace WebService.Services
{
    internal interface IWeatherService
    {
        IEnumerable<WeatherForecast> GetForecast();
    }
}