using Cortlex.Rescope.Abstractions;

namespace Cortlex.Rescope.CustomScope.Example
{
    public class DbScopeFactory: ScopeFactoryBase, IDbScopeFactory
    {
        public const string DefaultScopeTag = "UnitOfWork";

        public DbScopeFactory(IScopeOptions options) : base(options)
        {
            
        }

        public IDbTransactionalScope RequireDbTransactionalScope(string tagName)
        {
            return RequireScope(tagName, (id, tag, scope) => new DbTransactionalScope(id, tag, scope));
        }
    }
}
