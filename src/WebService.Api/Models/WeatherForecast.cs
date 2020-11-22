using System;

namespace WebService.Api.Models
{
    public sealed record WeatherForecast(
        DateTime Date,
        int TemperatureC,
        string Summary);
}
