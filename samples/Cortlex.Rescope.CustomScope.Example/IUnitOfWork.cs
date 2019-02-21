using System;

namespace Cortlex.Rescope.CustomScope.Example
{
    public interface IUnitOfWork
    {
        Guid Now { get; }
    }
}