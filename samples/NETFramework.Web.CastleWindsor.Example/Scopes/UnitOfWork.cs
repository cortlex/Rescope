using System;

namespace NETFramework.Web.CastleWindsor.Example.Scopes
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
