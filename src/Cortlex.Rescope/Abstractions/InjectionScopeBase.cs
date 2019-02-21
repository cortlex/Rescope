using System;
using System.Collections.Concurrent;

namespace Cortlex.Rescope.Abstractions
{
    public abstract class InjectionScopeBase: IInjectionScope
    {
        public static readonly ConcurrentDictionary<Guid, IInjectionScope> Scopes = new ConcurrentDictionary<Guid, IInjectionScope>();

        public Guid ContextId { get; }

        protected InjectionScopeBase()
        {
            ContextId = Guid.NewGuid();

            var added = Scopes.TryAdd(ContextId, this);

            if (!added)
            {
                throw new InvalidOperationException($"Scope with ContextId = {ContextId} has already been added");
            }
        }

        public abstract T Resolve<T>();

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Scopes.TryRemove(ContextId, out var injectionScope);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
