using System;

namespace Cortlex.Rescope.Abstractions
{
    public abstract class ScopeFactoryBase
    {
        private readonly IScopeOptions _options;

        public delegate T ScopeFactory<out T>(Guid id, string tag, IInjectionScope injectionScope);

        protected ScopeFactoryBase(IScopeOptions options)
        {
            _options = options;
        }

        protected T BeginScope<T>(string tag, ScopeFactory<T> scopeFactory) where T : Scope
        {
            var injectionScope = _options.InjectionScopeFactory.Create();
            
            return scopeFactory(injectionScope.ContextId, tag, injectionScope);
        }

        protected T RequireScope<T>(string tag, ScopeFactory<T> scopeFactory) where T : Scope
        {
            var contextId = Scope.Context.GetData(tag);
            if (contextId != null)
            {
                return scopeFactory(Guid.NewGuid(), tag, InjectionScopeBase.Scopes[contextId.Value]);
            }

            var scope = _options.InjectionScopeFactory.Create();
            return scopeFactory(scope.ContextId, tag, scope);
        }
    }
}