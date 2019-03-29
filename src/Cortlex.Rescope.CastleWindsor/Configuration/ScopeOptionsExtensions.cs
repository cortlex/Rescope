using Castle.MicroKernel;
using Cortlex.Rescope.Abstractions;

namespace Cortlex.Rescope.CastleWindsor.Configuration
{
    public static class ScopeOptionsExtensions
    {
        public static IScopeOptions UseCastleWindsor(this IScopeOptions options, IKernel kernel)
        {
            options.UseInjectionScopeFactory(new CastleWindsorInjectionScopeFactory(kernel));
            return options;
        }
    }
}
