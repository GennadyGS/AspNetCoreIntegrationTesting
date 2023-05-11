using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using WebApplicationTests.Utils;
using WebService.Models;
using Xunit;

namespace WebApplicationTests;

public sealed class WebApplicationTests
{
    [Fact]
    public async Task GetWeatherForecast_ShouldReturnSuccessResult()
    {
        // Create application factories for master and utility services and corresponding HTTP clients
        var webApplicationFactory = new CustomWebApplicationFactory();
        var webApplicationClient = webApplicationFactory.CreateClient();
        var webServiceFactory = new WebApplicationFactory<Program>();
        var webServiceClient = webServiceFactory.CreateClient();
            
        // Mock dependency on utility service by replacing named HTTP client
        webApplicationFactory.AddHttpClient(clientName: "WebService", webServiceClient);

        // Perform test request
        var response = await webApplicationClient.GetAsync("weatherForecast");

        // Assert the result
        response.EnsureSuccessStatusCode();
        var forecast = await response.Content.ReadAsAsync<IEnumerable<WeatherForecast>>();
        Assert.Equal(10, forecast.Count());
    }
}