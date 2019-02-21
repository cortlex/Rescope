using System;

namespace Cortlex.Rescope.Abstractions
{
    public interface IScope: IDisposable
    {
        T Resolve<T>();
    }
}
