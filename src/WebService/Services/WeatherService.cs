using System;
using System.Collections.Generic;
using System.Linq;
using WebService.Models;

namespace WebService.Services
{
    internal sealed class WeatherService
    {
        private static readonly string[] Summaries = 
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering",
        };

        public IEnumerable<WeatherForecast> GetForecast()
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