using Autofac;
using Cortlex.Rescope.Abstractions;

namespace Cortlex.Rescope.Autofac
{
    public static class ScopeOptionsExtensions
    {
        public static IScopeOptions UseAutofac(this IScopeOptions options, ILifetimeScope lifetimeScope)
        {
            options.UseInjectionScopeFactory(new AutofacInjectionScopeFactory(lifetimeScope));
            return options;
        }
    }
}
