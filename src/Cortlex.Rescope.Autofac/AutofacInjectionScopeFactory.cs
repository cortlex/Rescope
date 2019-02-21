using Autofac;
using Cortlex.Rescope.Abstractions;

namespace Cortlex.Rescope.Autofac
{
    public class AutofacInjectionScopeFactory: IInjectionScopeFactory
    {
        private readonly ILifetimeScope _lifetimeScope;

        public AutofacInjectionScopeFactory(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public IInjectionScope Create()
        {
            return new AutofacInjectionScope(_lifetimeScope);
        }
    }
}
