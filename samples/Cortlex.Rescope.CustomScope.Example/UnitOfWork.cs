using System;

namespace Cortlex.Rescope.CustomScope.Example
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository Repository { get; }

        public Guid Now { get; }

        public UnitOfWork(IRepository repository)
        {
            Repository = repository;
            Now = Guid.NewGuid();
        }
    }
}
