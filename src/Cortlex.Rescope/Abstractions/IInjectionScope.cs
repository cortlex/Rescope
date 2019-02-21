using System;

namespace Cortlex.Rescope.Abstractions
{
    public interface IInjectionScope: IDisposable
    {
        Guid ContextId { get; }
        T Resolve<T>();
    }
}
