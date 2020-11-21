using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Utils;

namespace WebApplication.Services
{
    internal sealed class WeatherForecastClient : IWeatherForecastClient
    {
        public WeatherForecastClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        private HttpClient HttpClient { get; }

        public async Task<IEnumerable<WeatherForecast>> GetForecastAsync() =>
            (await GetForecastsAsync(HttpClient))
                .Concat(await GetForecastsAsync(HttpClient));

        private async Task<IEnumerable<WeatherForecast>> GetForecastsAsync(
            HttpClient httpClient)
        {
            var responseMessage = await httpClient.GetAsync("weatherForecast");
            return await responseMessage
                .CheckSuccess("Get weatherForecast")
                .Content
                .ReadAsAsync<IEnumerable<WeatherForecast>>();
        }
    }
}