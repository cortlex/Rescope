using Cortlex.Rescope.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cortlex.Rescope.NETCore
{
    public class CoreInjectionScopeFactory: IInjectionScopeFactory
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CoreInjectionScopeFactory(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public IInjectionScope Create()
        {
            return new CoreInjectionScope(_serviceScopeFactory);
        }
    }
}
