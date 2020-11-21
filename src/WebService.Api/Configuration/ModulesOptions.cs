using System.Collections.Generic;

namespace WebService.Api.Configuration
{
    internal sealed class ModulesOptions
    {
        public IReadOnlyCollection<ModuleOptions> Modules { get; init; }
    }
}