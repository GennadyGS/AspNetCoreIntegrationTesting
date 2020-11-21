using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;
using WebService.Services;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController(IWeatherService weatherService)
        {
            WeatherService = weatherService;
        }

        private IWeatherService WeatherService { get; }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get() => 
            WeatherService.GetForecast();
    }
}
