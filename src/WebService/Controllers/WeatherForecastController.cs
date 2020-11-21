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
        private WeatherService Service { get; } = new WeatherService();

        [HttpGet]
        public IEnumerable<WeatherForecast> Get() => 
            Service.GetForecast();
    }
}
