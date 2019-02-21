using Cortlex.Rescope.Abstractions;

namespace Cortlex.Rescope.CustomScope.Example
{
    internal class DbTransactionalScope : Scope, IDbTransactionalScope
    {
        public DbTransactionalScope(string tag, bool isRoot, IInjectionScope injectionScope) : base(tag, isRoot, injectionScope)
        {
        }

        public IUnitOfWork UnitOfWork => Resolve<IUnitOfWork>();
    }
}
