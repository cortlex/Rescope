﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using NETCore.GenericHost.Autofac.Example.Scopes;

namespace NETCore.GenericHost.Autofac.Example.Services
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
            using (var scope = _dbScopeFactory.BeginDbTransactionalScope())
            {
                var uow = scope.UnitOfWork;

                using (var scope1 = _dbScopeFactory.BeginDbTransactionalScope())
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
