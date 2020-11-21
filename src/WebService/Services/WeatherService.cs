﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebService.Models;

namespace WebService.Services
{
    internal sealed class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = 
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering",
        };

        private Random Random { get; } = new Random(423423);

        public IEnumerable<WeatherForecast> GetForecast() =>
            Enumerable
                .Range(1, 5)
                .Select(index =>
                    new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = Random.Next(-20, 55),
                        Summary = Summaries[Random.Next(Summaries.Length)],
                    })
                .ToArray();
    }
}