using Cortlex.Rescope.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cortlex.Rescope.NETCore
{
    internal class CoreInjectionScope: InjectionScopeBase
    {
        private readonly IServiceScope _scope;

        public CoreInjectionScope(IServiceScopeFactory serviceScopeFactory)
        {
            _scope = serviceScopeFactory.CreateScope();
        }

        public override T Resolve<T>()
        {
            return _scope.ServiceProvider.GetService<T>();
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
