using System;

namespace AspNetCore.Web.Autofac.Default.Example.Scopes
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
