using System;
using Cortlex.Rescope.Abstractions;

namespace Cortlex.Rescope.CustomScope.Example
{
    internal class DbTransactionalScope : Scope, IDbTransactionalScope
    {
        public DbTransactionalScope(Guid id, string tag, IInjectionScope injectionScope) : base(id, tag, injectionScope)
        {
            
        }

        public IUnitOfWork UnitOfWork => Resolve<IUnitOfWork>();
        
    }
}
