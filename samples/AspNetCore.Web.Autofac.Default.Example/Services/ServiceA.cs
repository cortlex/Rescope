using Cortlex.Rescope.CustomScope.Example;

namespace AspNetCore.Web.Autofac.Default.Example.Services
{
    public class ServiceA
    {
        private readonly IDbScopeFactory _dbScopeFactory;

        public ServiceA(IDbScopeFactory dbScopeFactory)
        {
            _dbScopeFactory = dbScopeFactory;
        }

        public void Run()
        {
            using (var scope = _dbScopeFactory.RequireDbTransactionalScope())
            {
                var uow = scope.UnitOfWork;
            }
        }
    }
}
