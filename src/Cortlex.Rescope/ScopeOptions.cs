using System;
using Cortlex.Rescope.Abstractions;

namespace Cortlex.Rescope
{
    public class ScopeOptions: IScopeOptions
    {
        public static ScopeOptions Options = new ScopeOptions();

        private IInjectionScopeFactory _injectionScopeFactory;
        
        private ScopeOptions(){}
        
        public IInjectionScopeFactory InjectionScopeFactory => _injectionScopeFactory ?? throw new InvalidOperationException("ScopeOptions is not initialized");

        public IScopeOptions UseInjectionScopeFactory(IInjectionScopeFactory factory)
        {
            _injectionScopeFactory = factory ?? throw new ArgumentNullException(nameof(factory));

            return this;
        }
    }
}
