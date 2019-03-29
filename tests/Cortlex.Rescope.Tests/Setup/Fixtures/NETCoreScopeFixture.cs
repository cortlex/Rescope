using Cortlex.Rescope.CustomScope.Example;
using Cortlex.Rescope.NETCore;
using Cortlex.Rescope.NETCore.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cortlex.Rescope.Tests.Setup.Fixtures
{
    public class NETCoreScopeFixture : IScopeFactoryFixture
    {
        private readonly IServiceScope _scope;

        public NETCoreScopeFixture()
        {
            var services = new ServiceCollection();

            services.AddRescope((provider, options) => { options.UseCoreDI(provider.GetService<IServiceScopeFactory>()); });
            services.AddSingleton<IDbScopeFactory, DbScopeFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var serviceProvider = services.BuildServiceProvider();
            _scope = serviceProvider.CreateScope();
        }

        public IDbScopeFactory ScopeFactory => _scope.ServiceProvider.GetService<IDbScopeFactory>();

        public void Dispose()
        {
            _scope?.Dispose();
        }
    }
}
