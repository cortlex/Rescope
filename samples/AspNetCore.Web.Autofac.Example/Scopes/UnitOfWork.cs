using System;

namespace AspNetCore.Web.Autofac.Example.Scopes
{
    public class UnitOfWork
    {
        public Guid Now { get; }

        public UnitOfWork()
        {
            Now = Guid.NewGuid();
        }
    }
}
