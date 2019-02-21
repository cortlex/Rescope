using System;
using Cortlex.Rescope.CustomScope.Example;
using Microsoft.Extensions.DependencyInjection;

namespace Cortlex.Rescope.NETCore.Tests.Setup
{
    // ReSharper disable once InconsistentNaming
    public class NETCoreDIScopeFixture: IDisposable
    {
        public IServiceScope Scope;

        public NETCoreDIScopeFixture()
        {
            var services = new ServiceCollection();

            services.AddRescope((provider, options) => { options.UseCoreDI(provider.GetService<IServiceScopeFactory>()); });
            services.AddSingleton<IDbScopeFactory, DbScopeFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var serviceProvider = services.BuildServiceProvider();
            Scope = serviceProvider.CreateScope();
        }

        public void Dispose()
        {
            Scope?.Dispose();
        }
    }
}
