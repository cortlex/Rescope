using Castle.MicroKernel;
using Cortlex.Rescope.Abstractions;

namespace Cortlex.Rescope.CastleWindsor
{
    public class CastleWindsorInjectionScopeFactory: IInjectionScopeFactory
    {
        private readonly IKernel _kernel;

        public CastleWindsorInjectionScopeFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IInjectionScope Create()
        {
            return new CastleWindsorInjectionScope(_kernel);
        }
    }
}
