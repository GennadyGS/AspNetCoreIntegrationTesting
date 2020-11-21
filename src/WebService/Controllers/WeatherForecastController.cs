using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = 
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering",
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var random = new Random(423423);
            return Enumerable
                .Range(1, 5)
                .Select(index => 
                    new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = random.Next(-20, 55),
                        Summary = Summaries[random.Next(Summaries.Length)],
                    })
                .ToArray();
        }
    }
}
