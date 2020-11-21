using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    public interface IWeatherForecastClient
    {
        Task<IEnumerable<WeatherForecast>> GetForecastAsync();
    }
}