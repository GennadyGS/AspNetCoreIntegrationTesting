using System.Net.Http;

namespace WebApplication.Utils
{
    internal static class HttpResponseMessageExtensions
    {
        public static HttpResponseMessage CheckSuccess(this HttpResponseMessage response, string description)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"{description} failed with status code {response.StatusCode}");
            }
            return response;
        }
    }
}