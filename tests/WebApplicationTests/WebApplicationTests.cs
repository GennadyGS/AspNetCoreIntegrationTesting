using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationTests.Mocks;
using WebApplicationTests.Utils;
using WebService;
using WebService.Api.Models;
using WebService.Api.Services;
using Xunit;

namespace WebApplicationTests
{
    public class WebApplicationTests
    {
        [Fact]
        public async Task GetWeatherForecast_ShouldResultSuccessResult()
        {
            var generatedForecast = GenerateForecast();
            var webApplicationFactory = new CustomWebApplicationFactory();
            var webApplicationClient = webApplicationFactory.CreateClient();
            var webServiceFactory = CreateWebApplicationFactory(generatedForecast);
            var webServiceClient = webServiceFactory.CreateClient();
            webApplicationFactory.AddHttpClient("WebService", webServiceClient);

            var response = await webApplicationClient.GetAsync("weatherForecast");

            response.EnsureSuccessStatusCode();
            var responseForecast = await response.Content.ReadAsAsync<IEnumerable<WeatherForecast>>();
            var expectedForecast = Enumerable.Repeat(generatedForecast, 2)
                .SelectMany(x => x)
                .ToList();
            Assert.Equal(expectedForecast, responseForecast);
        }

        private IReadOnlyCollection<WeatherForecast> GenerateForecast() =>
            new[]
            {
                new WeatherForecast(
                    Date: new DateTime(2020, 11, 22),
                    TemperatureC: -1,
                    Summary: "According to season"),
                new WeatherForecast(
                    Date: new DateTime(2020, 09, 02),
                    TemperatureC: +35,
                    Summary: "Hot"),
            };

        private static WebApplicationFactory<Program> CreateWebApplicationFactory(
            IReadOnlyCollection<WeatherForecast> forecast) =>
            new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                    builder
                        .ConfigureAppConfiguration((context, configurationBuilder) =>
                        {
                            configurationBuilder.Sources.Clear();
                            configurationBuilder
                                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                            configurationBuilder.AddJsonFile("service.appsettings.json");
                        })
                        .ConfigureServices(services =>
                            services.AddSingleton<IWeatherService>(new WeatherServiceMock(forecast))));
    }
}
