using System;

namespace Cortlex.Rescope.Abstractions
{
    public abstract class Scope: IScope
    {
        internal static readonly ScopeContext Context = new ScopeContext();

        protected Guid Id { get; }
        protected IInjectionScope InjectionScope { get; }
        protected bool IsRoot => InjectionScope.ContextId == Id;

        public string Tag { get; }

        protected Scope(Guid id, string tag, IInjectionScope injectionScope)
        {
            Id = id;
            Tag = tag;
            
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
