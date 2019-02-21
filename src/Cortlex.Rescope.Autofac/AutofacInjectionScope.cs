using Autofac;
using Cortlex.Rescope.Abstractions;

namespace Cortlex.Rescope.Autofac
{
    public class AutofacInjectionScope: InjectionScopeBase
    {
        private readonly ILifetimeScope _scope;

        public AutofacInjectionScope(ILifetimeScope lifetimeScope)
        {
            _scope = lifetimeScope.BeginLifetimeScope();
        }
        
        public override T Resolve<T>()
        {
            return _scope.Resolve<T>();
        }

        public override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _scope?.Dispose();
            }
            
            base.Dispose(disposing);
        }
    }
}
