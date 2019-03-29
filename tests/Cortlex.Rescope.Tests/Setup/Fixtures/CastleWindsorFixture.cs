using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Cortlex.Rescope.Abstractions;
using Cortlex.Rescope.CastleWindsor;
using Cortlex.Rescope.CastleWindsor.Configuration;
using Cortlex.Rescope.CustomScope.Example;

namespace Cortlex.Rescope.Tests.Setup.Fixtures
{
    public class CastleWindsorFixture: IScopeFactoryFixture
    {
        private readonly IWindsorContainer _container;

        public CastleWindsorFixture()
        {
            _container = new WindsorContainer();

            _container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifestyleScoped<ScopeAccessor>());

            _container.Register(Component.For<IScopeOptions>().UsingFactoryMethod(c => ScopeOptions.Options).LifestyleSingleton());
            ScopeOptions.Options.UseCastleWindsor(_container.Kernel);

            _container.Register(Component.For<IDbScopeFactory>().ImplementedBy<DbScopeFactory>().LifestyleSingleton());
        }

        public IDbScopeFactory ScopeFactory => _container.Resolve<IDbScopeFactory>();

        public void Dispose()
        {
            _container?.Dispose();
        }
    }
}
