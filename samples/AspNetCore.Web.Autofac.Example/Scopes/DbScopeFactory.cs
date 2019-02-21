using Cortlex.Rescope.Abstractions;

namespace AspNetCore.Web.Autofac.Example.Scopes
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
    }
}
