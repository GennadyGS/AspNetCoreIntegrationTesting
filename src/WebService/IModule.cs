using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebService
{
    public interface IModule
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}