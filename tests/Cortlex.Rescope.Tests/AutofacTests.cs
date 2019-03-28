using System.Collections.Generic;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Cortlex.Rescope.Tests.Setup.Common;
using Cortlex.Rescope.Tests.Setup.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Priority;

namespace Cortlex.Rescope.Tests
{
    [Collection("Scope Tests")]
    public class AutofacTests: ScopeTestsBase<AutofacFixture>
    {
        public AutofacTests(AutofacFixture fixture) : base(fixture)
        {

        }

        [Fact, Priority(0)]
        public void MultipleTypesWithCommonInterfaceShouldBeResolvedAsIEnumerable()
        {
            var services = new ServiceCollection();
            var builder = new ContainerBuilder();

            services.AddTransient<IFoo, FooImpl1>();
            services.AddTransient<IFoo, FooImpl2>();

            builder.Populate(services);
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var items = scope.Resolve<IEnumerable<IFoo>>();
                Assert.Collection(items, item => Assert.Equal(nameof(FooImpl1), item.Name), item => Assert.Equal(nameof(FooImpl2), item.Name));
            }
        }
    }
}