using System;
using System.Collections.Concurrent;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplicationTests.Utils
{
    internal sealed class CustomWebApplicationFactory
        : WebApplicationFactory<WebApplication.Startup>
    {
        private ConcurrentDictionary<string, HttpClient> HttpClients { get; } =
            new ConcurrentDictionary<string, HttpClient>();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(services =>
                services.AddSingleton<IHttpClientFactory>(
                    new CustomHttpClientFactory(HttpClients)));
        }

        public void AddHttpClient(string clientName, HttpClient client)
        {
            if (!HttpClients.TryAdd(clientName, client))
            {
                throw new InvalidOperationException(
                    $"HttpClient with name {clientName} is already added");
            }
        }
    }
}