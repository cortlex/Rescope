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
    public class NETCoreTests: ScopeTestsBase<NETCoreScopeFixture>
    {
        public NETCoreTests(NETCoreScopeFixture fixture) : base(fixture)
        {
        }

        [Fact, Priority(0)]
        public void MultipleTypesWithCommonInterfaceShouldBeResolvedAsIEnumerable()
        {
            var services = new ServiceCollection();
            services.AddTransient<IFoo, FooImpl1>();
            services.AddTransient<IFoo, FooImpl2>();
            services.AddTransient<CollectionWrapper<IFoo>>();
            
            var serviceProvider = services.BuildServiceProvider();
            
            using (var scope = serviceProvider.CreateScope())
            {
                var wrapper = scope.ServiceProvider.GetService<CollectionWrapper<IFoo>>();

                Assert.Collection(wrapper.Items, item => Assert.Equal(nameof(FooImpl1), item.Name), item => Assert.Equal(nameof(FooImpl2), item.Name));
            }
        }
    }
}
