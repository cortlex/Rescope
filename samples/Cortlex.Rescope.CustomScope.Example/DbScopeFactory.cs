using Cortlex.Rescope.Abstractions;

namespace Cortlex.Rescope.CustomScope.Example
{
    public class DbScopeFactory: ScopeFactoryBase, IDbScopeFactory
    {
        public DbScopeFactory(IScopeOptions options) : base(options)
        {
            
        }

        public IDbTransactionalScope RequireDbTransactionalScope()
        {
            return RequireScope("UnitOfWork", (id, tag, scope) => new DbTransactionalScope(id, tag, scope));
        }

        public IDbTransactionalScope BeginDbTransactionalScope()
        {
            return BeginScope("UnitOfWork", (id, tag, scope) => new DbTransactionalScope(id, tag, scope));
        }
    }
}
