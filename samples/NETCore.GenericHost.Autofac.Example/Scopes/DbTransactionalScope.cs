﻿using Cortlex.Rescope.Abstractions;

namespace NETCore.GenericHost.Autofac.Example.Scopes
{
    public class DbTransactionalScope: Scope
    {
        public DbTransactionalScope(string tag, bool isRoot, IInjectionScope injectionScope) : base(tag, isRoot, injectionScope)
        {
        }

        public UnitOfWork UnitOfWork => Resolve<UnitOfWork>();
    }
}
