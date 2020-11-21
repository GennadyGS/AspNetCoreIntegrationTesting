using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using WebApplicationTests.Utils;
using WebService;
using WebService.Api;
using WebService.Api.Models;
using Xunit;

namespace WebApplicationTests
{
    public class WebApplicationTests
    {
        [Fact]
        public async Task GetWeatherForecast_ShouldResultSuccessResult()
        {
            var webApplicationFactory = new CustomWebApplicationFactory();
            var webApplicationClient = webApplicationFactory.CreateClient();
            var webServiceFactory = new WebApplicationFactory<Program>();
            var webServiceClient = webServiceFactory.CreateClient();
            webApplicationFactory.AddHttpClient("WebService", webServiceClient);

            var response = await webApplicationClient.GetAsync("weatherForecast");

            response.EnsureSuccessStatusCode();
            var forecast = await response.Content.ReadAsAsync<IEnumerable<WeatherForecast>>();
            Assert.Equal(10, forecast.Count());
        }
    }
}
