using System;
using Cortlex.Rescope.Internal;

namespace Cortlex.Rescope.Abstractions
{
    public abstract class Scope: IScope
    {
        internal static readonly ScopeContext Context = new ScopeContext();
        
        protected bool IsRoot { get; }

        protected IInjectionScope InjectionScope { get; }

        public string Tag { get; }

        protected Scope(string tag, bool isRoot, IInjectionScope injectionScope)
        {
            Tag = tag;
            IsRoot = isRoot;
            InjectionScope = injectionScope;

            if (IsRoot)
            {
                Context.SetData(tag, injectionScope.ContextId);
            }
        }

        public T Resolve<T>()
        {
            return InjectionScope.Resolve<T>();
        }
        
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (IsRoot)
                {
                    InjectionScope?.Dispose();
                    Context.SetData(Tag, (Guid?)null);
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
