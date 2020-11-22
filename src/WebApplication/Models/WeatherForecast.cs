using System;

namespace WebApplication.Models
{
    public sealed record WeatherForecast(
        DateTime Date,
        int TemperatureC,
        string Summary);
}
