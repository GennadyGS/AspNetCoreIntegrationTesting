using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IWeatherForecastClient WeatherForecastClient { get; }

        public WeatherForecastController(IWeatherForecastClient weatherForecastClient)
        {
            WeatherForecastClient = weatherForecastClient;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get() => 
            await WeatherForecastClient.GetForecastAsync();
    }
}
