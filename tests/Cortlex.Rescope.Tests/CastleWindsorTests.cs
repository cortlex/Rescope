using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.Windsor.Proxy;
using Cortlex.Rescope.CastleWindsor;
using Cortlex.Rescope.Tests.Setup.Common;
using Cortlex.Rescope.Tests.Setup.Fixtures;
using Xunit;
using Xunit.Priority;

namespace Cortlex.Rescope.Tests
{
    [Collection("Scope Tests")]
    public class CastleWindsorTests: ScopeTestsBase<CastleWindsorFixture>
    {
        public CastleWindsorTests(CastleWindsorFixture fixture) : base(fixture)
        {
        }

        [Fact, Priority(0)]
        public void MultipleTypesWithCommonInterfaceShouldBeResolvedAsIEnumerable()
        {
            var container = new WindsorContainer(new DefaultKernel(new PropagateInlineDependenciesResolver(), new DefaultProxyFactory()), new DefaultComponentInstaller());
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            container.Register(Component.For<IFoo>().ImplementedBy<FooImpl1>().LifestyleTransient());
            container.Register(Component.For<IFoo>().ImplementedBy<FooImpl2>().LifestyleTransient());
            container.Register(Component.For<CollectionWrapper<IFoo>>().ImplementedBy<CollectionWrapper<IFoo>>().LifestyleTransient());

            var wrapper = container.Resolve<CollectionWrapper<IFoo>>();
            
            Assert.Collection(wrapper.Items, item => Assert.Equal(nameof(FooImpl1), item.Name), item => Assert.Equal(nameof(FooImpl2), item.Name));
        }
    }
}
