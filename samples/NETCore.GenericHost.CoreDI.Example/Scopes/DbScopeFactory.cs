﻿using Cortlex.Rescope.Abstractions;

namespace NETCore.GenericHost.CoreDI.Example.Scopes
{
    public class DbScopeFactory: ScopeFactoryBase, IDbScopeFactory
    {
        public DbScopeFactory(IScopeOptions options) : base(options)
        {
            
        }

        public DbTransactionalScope RequireDbTransactionalScope()
        {
            return RequireScope("UnitOfWork", (tag, root, scope) => new DbTransactionalScope(tag, root, scope));
        }

        public DbTransactionalScope BeginDbTransactionalScope()
        {
            return BeginScope("UnitOfWork", (tag, root, scope) => new DbTransactionalScope(tag, root, scope));
        }
    }
}
