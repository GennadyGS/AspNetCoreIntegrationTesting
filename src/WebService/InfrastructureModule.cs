using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebService.Services;

namespace WebService
{
    internal class InfrastructureModule : IModule
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IWeatherService, WeatherService>();
        }
    }
}