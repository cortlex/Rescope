using System;

namespace Cortlex.Rescope.CustomScope.Example
{
    public interface IDbTransactionalScope: IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}