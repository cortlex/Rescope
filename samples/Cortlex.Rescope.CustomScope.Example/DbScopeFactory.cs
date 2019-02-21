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
            return RequireScope("UnitOfWork", (tag, root, scope) => new DbTransactionalScope(tag, root, scope));
        }

        public IDbTransactionalScope BeginDbTransactionalScope()
        {
            return BeginScope("UnitOfWork", (tag, root, scope) => new DbTransactionalScope(tag, root, scope));
        }
    }
}
