using System.Threading;
using System.Threading.Tasks;
using Cortlex.Rescope.Abstractions;
using Cortlex.Rescope.CustomScope.Example;
using Cortlex.Rescope.NETCore.Tests.Setup;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cortlex.Rescope.NETCore.Tests
{
    public class ScopeTests: IClassFixture<NETCoreDIScopeFixture>
    {
        private readonly NETCoreDIScopeFixture _fixture;

        public ScopeTests(NETCoreDIScopeFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void RequireScopeShouldAttachToParentAsBeginScope()
        {
            var scopeFactory = _fixture.Scope.ServiceProvider.GetService<IDbScopeFactory>();

            using (var scope1 = scopeFactory.BeginDbTransactionalScope())
            {
                using (var scope2 = scopeFactory.RequireDbTransactionalScope())
                {
                    Assert.Equal(scope1.UnitOfWork, scope2.UnitOfWork);
                }
            }
        }

        [Fact]
        public void RequireScopeShouldAttachToParentAsRequireScope()
        {
            var scopeFactory = _fixture.Scope.ServiceProvider.GetService<IDbScopeFactory>();

            using (var scope1 = scopeFactory.RequireDbTransactionalScope())
            {
                using (var scope2 = scopeFactory.RequireDbTransactionalScope())
                {
                    Assert.Equal(scope1.UnitOfWork, scope2.UnitOfWork);
                }
            }
        }

        [Fact]
        public void BeginScopeShouldNotAttachToParentAsBeginScope()
        {
            var scopeFactory = _fixture.Scope.ServiceProvider.GetService<IDbScopeFactory>();

            using (var scope1 = scopeFactory.BeginDbTransactionalScope())
            {
                using (var scope2 = scopeFactory.BeginDbTransactionalScope())
                {
                    Assert.NotEqual(scope1.UnitOfWork, scope2.UnitOfWork);
                }
            }
        }

        [Fact]
        public void BeginScopeShouldNotAttachToParentAsRequireScope()
        {
            var scopeFactory = _fixture.Scope.ServiceProvider.GetService<IDbScopeFactory>();

            using (var scope1 = scopeFactory.RequireDbTransactionalScope())
            {
                using (var scope2 = scopeFactory.BeginDbTransactionalScope())
                {
                    Assert.NotEqual(scope1.UnitOfWork, scope2.UnitOfWork);
                }
            }
        }

        [Fact]
        public void MultipleRequireScopeShouldNotBeSameOnSameLevel()
        {
            var scopeFactory = _fixture.Scope.ServiceProvider.GetService<IDbScopeFactory>();

            IUnitOfWork uow1;
            IUnitOfWork uow2;

            using (var scope1 = scopeFactory.RequireDbTransactionalScope())
            {
                uow1 = scope1.UnitOfWork;
            }

            using (var scope2 = scopeFactory.RequireDbTransactionalScope())
            {
                uow2 = scope2.UnitOfWork;
            }

            Assert.NotEqual(uow1, uow2);
        }

        [Fact]
        public void MultipleBeginScopeShouldNotBeSameOnSameLevel()
        {
            var scopeFactory = _fixture.Scope.ServiceProvider.GetService<IDbScopeFactory>();

            IUnitOfWork uow1;
            IUnitOfWork uow2;

            using (var scope1 = scopeFactory.RequireDbTransactionalScope())
            {
                uow1 = scope1.UnitOfWork;
            }

            using (var scope2 = scopeFactory.RequireDbTransactionalScope())
            {
                uow2 = scope2.UnitOfWork;
            }

            Assert.NotEqual(uow1, uow2);
        }

        [Fact]
        public async void RequireScopeShouldAttachInsideTask()
        {
            var scopeFactory = _fixture.Scope.ServiceProvider.GetService<IDbScopeFactory>();

            using (var scope1 = scopeFactory.RequireDbTransactionalScope())
            {
                await Task.Run(() =>
                {
                    using (var scope2 = scopeFactory.RequireDbTransactionalScope())
                    {
                        Assert.Equal(scope1.UnitOfWork, scope2.UnitOfWork);
                    }
                });
            }
        }

        [Fact]
        public void BeginScopeInsideUnWaitedTaskShouldNotBringAffect()
        {
            var scopeFactory = _fixture.Scope.ServiceProvider.GetService<IDbScopeFactory>();

            using (var scope1 = scopeFactory.RequireDbTransactionalScope())
            {
                Task.Run(() =>
                {
                    using (var scope2 = scopeFactory.BeginDbTransactionalScope())
                    {
                        var uow2 = scope2.UnitOfWork;
                    }
                });

                using (var scope3 = scopeFactory.RequireDbTransactionalScope())
                {
                    Assert.Equal(scope1.UnitOfWork, scope3.UnitOfWork);
                }
            }
        }

        [Fact]
        public void BeginScopeInsideBackgroundThreadShouldNotBringAffect()
        {
            var scopeFactory = _fixture.Scope.ServiceProvider.GetService<IDbScopeFactory>();

            using (var scope1 = scopeFactory.RequireDbTransactionalScope())
            {
                new Thread(new ThreadStart(() =>
                {
                    using (var scope2 = scopeFactory.BeginDbTransactionalScope())
                    {
                        var uow2 = scope2.UnitOfWork;
                    }
                })).Start();

                using (var scope3 = scopeFactory.RequireDbTransactionalScope())
                {
                    Assert.Equal(scope1.UnitOfWork, scope3.UnitOfWork);
                }
            }
        }
    }
}
