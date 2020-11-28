using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using WebApplicationTests.Utils;
using WebService;
using WebService.Models;
using Xunit;

namespace WebApplicationTests
{
    public class WebApplicationTests
    {
        [Fact]
        public async Task GetWeatherForecast_ShouldReturnSuccessResult()
        {
            // Create application factories of master and utility service and 
            // create corresponding HTTP clients from them
            var webApplicationFactory = new CustomWebApplicationFactory();
            var webApplicationClient = webApplicationFactory.CreateClient();
            var webServiceFactory = new WebApplicationFactory<Startup>();
            var webServiceClient = webServiceFactory.CreateClient();
            // Mock dependency to utility service by replacing named HTTP client with 
            // HTTP client of utility service
            webApplicationFactory.AddHttpClient(clientName: "WebService", webServiceClient);

            var response = await webApplicationClient.GetAsync("weatherForecast");

            response.EnsureSuccessStatusCode();
            var forecast = await response.Content.ReadAsAsync<IEnumerable<WeatherForecast>>();
            Assert.Equal(10, forecast.Count());
        }
    }
}
