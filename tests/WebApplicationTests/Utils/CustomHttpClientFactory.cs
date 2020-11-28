using System;
using System.Collections.Generic;
using System.Net.Http;

namespace WebApplicationTests.Utils
{
    // Implements IHttpClientFactory by providing named HTTP clients directly from specified dictionary
    internal class CustomHttpClientFactory : IHttpClientFactory
    {
        // Takes dictionary storing named HTTP clients in constructor
        public CustomHttpClientFactory(
            IReadOnlyDictionary<string, HttpClient> httpClients)
        {
            HttpClients = httpClients;
        }

        private IReadOnlyDictionary<string, HttpClient> HttpClients { get; }

        // Provides named HTTP client from dictionary
        public HttpClient CreateClient(string name) =>
            HttpClients.GetValueOrDefault(name)
            ?? throw new InvalidOperationException(
                $"HTTP client is not found for client with name {name}");
    }
}