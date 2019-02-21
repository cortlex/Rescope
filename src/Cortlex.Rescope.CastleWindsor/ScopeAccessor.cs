using Castle.MicroKernel.Context;
using Castle.MicroKernel.Lifestyle.Scoped;

namespace Cortlex.Rescope.CastleWindsor
{
    public class ScopeAccessor: IScopeAccessor
    {
        public ILifetimeScope GetScope(CreationContext context)
        {
            return context.AdditionalArguments["scope"] as ILifetimeScope;
        }

        public void Dispose()
        {
            
        }
    }
}
