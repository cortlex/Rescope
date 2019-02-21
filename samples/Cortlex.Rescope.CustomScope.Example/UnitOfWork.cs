using System;

namespace Cortlex.Rescope.CustomScope.Example
{
    public class UnitOfWork : IUnitOfWork
    {
        public Guid Now { get; }

        public UnitOfWork()
        {
            Now = Guid.NewGuid();
        }
    }
}
