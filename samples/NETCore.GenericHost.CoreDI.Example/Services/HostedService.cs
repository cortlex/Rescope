using System.Threading;
using System.Threading.Tasks;
using Cortlex.Rescope.CustomScope.Example;
using Microsoft.Extensions.Hosting;

namespace NETCore.GenericHost.CoreDI.Example.Services
{
    public class HostedService: IHostedService
    {
        private readonly IDbScopeFactory _dbScopeFactory;

        public HostedService(IDbScopeFactory dbScopeFactory)
        {
            _dbScopeFactory = dbScopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _dbScopeFactory.RequireDbTransactionalScope("T1"))
            {
                var uow = scope.UnitOfWork;

                using (var scope1 = _dbScopeFactory.RequireDbTransactionalScope())
                {
                    var uow1 = scope1.UnitOfWork;

                    using (var scope2 = _dbScopeFactory.RequireDbTransactionalScope())
                    {
                        var uow2 = scope2.UnitOfWork;

                        var isSuccess = uow2 == uow1 && uow2 != uow;
                    }
                }
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
