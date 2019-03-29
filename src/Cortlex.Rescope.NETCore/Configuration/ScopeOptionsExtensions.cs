using Cortlex.Rescope.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cortlex.Rescope.NETCore.Configuration
{
    public static class ScopeOptionsExtensions
    {
        public static IScopeOptions UseCoreDI(this IScopeOptions options, IServiceScopeFactory serviceScopeFactory)
        {
            options.UseInjectionScopeFactory(new CoreInjectionScopeFactory(serviceScopeFactory));
            return options;
        }
    }
}
