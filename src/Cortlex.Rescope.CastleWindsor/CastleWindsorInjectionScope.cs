using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle.Scoped;
using Cortlex.Rescope.Abstractions;

namespace Cortlex.Rescope.CastleWindsor
{
    public class CastleWindsorInjectionScope: InjectionScopeBase
    {
        private readonly IKernel _kernel;
        private readonly ILifetimeScope _scope;

        public CastleWindsorInjectionScope(IKernel kernel)
        {
            _kernel = kernel;
            _scope = new DefaultLifetimeScope();
        }

        public override T Resolve<T>()
        {
            return _kernel.Resolve<T>(new Arguments
            {
                {"scope", _scope }
            });
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
