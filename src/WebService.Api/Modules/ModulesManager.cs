using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebService.Api.Configuration;

namespace WebService.Api.Modules
{
    internal sealed class ModulesManager
    {
        private IReadOnlyCollection<IModule> Modules { get; }

        private IConfiguration Configuration { get; }

        public ModulesManager(IConfiguration configuration)
        {
            Configuration = configuration;
            var modulesOptions = 
                configuration.Get<ModulesOptions>().Modules ?? Array.Empty<ModuleOptions>();
            Modules = modulesOptions
                .Select(CreateModule)
                .ToList();
        }

        private static IModule CreateModule(ModuleOptions options) => 
            (IModule)Activator.CreateInstance(options.Assembly, options.Type)?.Unwrap();

        public void ConfigureServices(IServiceCollection services)
        {
            foreach (var module in Modules)
            {
                module.ConfigureServices(services, Configuration);
            }
        }

        public void Configure(IApplicationBuilder app)
        {
            foreach (var module in Modules)
            {
                module.Configure(app);
            }
        }
    }
}
    