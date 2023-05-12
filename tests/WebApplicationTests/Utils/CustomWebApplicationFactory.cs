using System;
using System.Collections.Concurrent;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplicationTests.Utils;

// Extends WebApplicationFactory allowing to replace named HTTP clients
internal sealed class CustomWebApplicationFactory 
    : WebApplicationFactory<WebApplication.Controllers.WeatherForecastController>
{
    // Contains replaced named HTTP clients
    private ConcurrentDictionary<string, HttpClient> HttpClients { get; } = new();

    // Add replaced named HTTP client
    public void AddHttpClient(string clientName, HttpClient client)
    {
        if (!HttpClients.TryAdd(clientName, client))
        {
            throw new InvalidOperationException(
                $"HttpClient with name {clientName} is already added");
        }
    }

    // Replaces implementation of standard IHttpClientFactory interface with
    // custom one providing replaced HTTP clients from HttpClients dictionary 
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        builder.ConfigureServices(services =>
            services.AddSingleton<IHttpClientFactory>(
                new CustomHttpClientFactory(HttpClients)));
    }
}