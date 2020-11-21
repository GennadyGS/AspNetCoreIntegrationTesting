using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebService.Api.Contracts;
using WebService.Api.Services;
using WebService.Infrastructure.Services;

namespace WebService.Infrastructure
{
    public class InfrastructureModule : IModule
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IWeatherService, WeatherService>();
        }

        public void Configure(IApplicationBuilder app)
        {
        }
    }
}