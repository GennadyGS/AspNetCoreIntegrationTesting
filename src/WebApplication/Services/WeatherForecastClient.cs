using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Utils;

namespace WebApplication.Services;

internal sealed class WeatherForecastClient : IWeatherForecastClient
{
    public WeatherForecastClient(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<IEnumerable<WeatherForecast>> GetForecastAsync()
    {
        var forecast1 = await GetForecastsAsync();
        var forecast2 = await GetForecastsAsync();
        return forecast1.Concat(forecast2);
    }

    private async Task<IEnumerable<WeatherForecast>> GetForecastsAsync()
    {
        var responseMessage = await HttpClient.GetAsync("weatherForecast");
        return await responseMessage
            .CheckSuccess("Get weatherForecast")
            .Content
            .ReadAsAsync<IEnumerable<WeatherForecast>>();
    }
}