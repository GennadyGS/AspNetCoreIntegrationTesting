using System;
using System.Collections.Generic;
using System.Net.Http;

namespace WebApplicationTests.Utils
{
    internal class CustomHttpClientFactory : IHttpClientFactory
    {
        public CustomHttpClientFactory(
            IReadOnlyDictionary<string, HttpClient> httpClients)
        {
            HttpClients = httpClients;
        }

        private IReadOnlyDictionary<string, HttpClient> HttpClients { get; }

        public HttpClient CreateClient(string name) =>
            HttpClients.GetValueOrDefault(name)
            ?? throw new InvalidOperationException(
                $"HTTP client is not found for client with name {name}");
    }
}