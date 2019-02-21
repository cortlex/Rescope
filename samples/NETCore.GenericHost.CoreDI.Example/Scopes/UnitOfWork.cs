using System;

namespace NETCore.GenericHost.CoreDI.Example.Scopes
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
