using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using WebService.Api;
using WebService.Infrastructure;

namespace WebService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup(context => 
                        new Startup(
                            context.Configuration,
                            new InfrastructureModule()));
                });
    }
}
