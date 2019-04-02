using Autofac;
using Autofac.Extensions.DependencyInjection;
using Cortlex.Rescope.Autofac;
using Cortlex.Rescope.Autofac.Configuration;
using Cortlex.Rescope.CustomScope.Example;
using Cortlex.Rescope.NETCore;
using Cortlex.Rescope.NETCore.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cortlex.Rescope.Tests.Setup.Fixtures
{
    public class AutofacFixture : IScopeFactoryFixture
    {
        private readonly ILifetimeScope _scope;
        
        public AutofacFixture()
        {
            var services = new ServiceCollection();
            var builder = new ContainerBuilder();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<Repository>().As<IRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DbScopeFactory>().As<IDbScopeFactory>().SingleInstance();

            services.AddRescope((provider, options) => { options.UseAutofac(provider.GetService<ILifetimeScope>()); });

            builder.Populate(services);
            var container = builder.Build();

            _scope = container.BeginLifetimeScope();
        }

        public IDbScopeFactory ScopeFactory => _scope.Resolve<IDbScopeFactory>();

        public void Dispose()
        {
            _scope?.Dispose();
        }
    }
}
