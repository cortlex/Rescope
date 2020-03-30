using System.Threading;
using System.Threading.Tasks;
using Cortlex.Rescope.Abstractions;
using Cortlex.Rescope.CustomScope.Example;
using Cortlex.Rescope.Tests.Setup;
using Xunit;
using Xunit.Priority;

namespace Cortlex.Rescope.Tests
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public abstract class ScopeTestsBase<T>: IClassFixture<T> where T: class, IScopeFactoryFixture
    {
        private readonly T _fixture;
        
        protected ScopeTestsBase(T fixture)
        {
            _fixture = fixture;
        }

        [Fact, Priority(0)]
        public void RequireScopeShouldAttachToParentAsBeginScope()
        {
            using (var scope1 = _fixture.ScopeFactory.RequireDbTransactionalScope())
            {
                using (var scope2 = _fixture.ScopeFactory.RequireDbTransactionalScope())
                {
                    Assert.Equal(scope1.UnitOfWork, scope2.UnitOfWork);
                }
            }
        }

        [Fact, Priority(0)]
        public void RequireScopeShouldAttachToParentAsRequireScope()
        {
            using (var scope1 = _fixture.ScopeFactory.RequireDbTransactionalScope())
            {
                using (var scope2 = _fixture.ScopeFactory.RequireDbTransactionalScope())
                {
                    Assert.Equal(scope1.UnitOfWork, scope2.UnitOfWork);
                }
            }
        }

        [Fact, Priority(0)]
        public void DifferetnTagNamesShouldHaveDifferentScopes()
        {
            using (var scope1 = _fixture.ScopeFactory.RequireDbTransactionalScope("T1"))
            {
                using (var scope2 = _fixture.ScopeFactory.RequireDbTransactionalScope("T2"))
                {
                    Assert.NotEqual(scope1.UnitOfWork, scope2.UnitOfWork);
                }
            }
        }

        [Fact, Priority(0)]
        public void BeginScopeShouldNotAttachToParentAsRequireScope()
        {
            using (var scope1 = _fixture.ScopeFactory.RequireDbTransactionalScope())
            {
                using (var scope2 = _fixture.ScopeFactory.RequireDbTransactionalScope("T1"))
                {
                    Assert.NotEqual(scope1.UnitOfWork, scope2.UnitOfWork);
                }
            }
        }

        [Fact, Priority(0)]
        public void MultipleRequireScopeShouldNotBeSameOnSameLevel()
        {
            IUnitOfWork uow1;
            IUnitOfWork uow2;

            using (var scope1 = _fixture.ScopeFactory.RequireDbTransactionalScope())
            {
                uow1 = scope1.UnitOfWork;
            }

            using (var scope2 = _fixture.ScopeFactory.RequireDbTransactionalScope())
            {
                uow2 = scope2.UnitOfWork;
            }

            Assert.NotEqual(uow1, uow2);
        }

        [Fact, Priority(0)]
        public void MultipleBeginScopeShouldNotBeSameOnSameLevel()
        {
            IUnitOfWork uow1;
            IUnitOfWork uow2;

            using (var scope1 = _fixture.ScopeFactory.RequireDbTransactionalScope())
            {
                uow1 = scope1.UnitOfWork;
            }

            using (var scope2 = _fixture.ScopeFactory.RequireDbTransactionalScope())
            {
                uow2 = scope2.UnitOfWork;
            }

            Assert.NotEqual(uow1, uow2);
        }

        [Fact, Priority(0)]
        public async void RequireScopeShouldAttachInsideAwaitedTask()
        {
            using (var scope1 = _fixture.ScopeFactory.RequireDbTransactionalScope())
            {
                await Task.Run(() =>
                {
                    using (var scope2 = _fixture.ScopeFactory.RequireDbTransactionalScope())
                    {
                        Assert.Equal(scope1.UnitOfWork, scope2.UnitOfWork);
                    }
                });
            }
        }

        [Fact, Priority(0)]
        public void BeginScopeInsideUnWaitedTaskShouldNotBringAffect()
        {
            var testCaseResetEvent = new ManualResetEvent(false);
            var beginScopeInTaskResetEvent = new ManualResetEvent(false);

            using (var scope1 = _fixture.ScopeFactory.RequireDbTransactionalScope())
            {
                Task.Run(() =>
                {
                    using (var scope2 = _fixture.ScopeFactory.RequireDbTransactionalScope("T1"))
                    {
                        beginScopeInTaskResetEvent.Set();
                        var uow2 = scope2.UnitOfWork;
                    }

                    testCaseResetEvent.Set();
                });

                beginScopeInTaskResetEvent.WaitOne();
                using (var scope3 = _fixture.ScopeFactory.RequireDbTransactionalScope())
                {
                    Assert.Equal(scope1.UnitOfWork, scope3.UnitOfWork);
                }
            }

            testCaseResetEvent.WaitOne();
        }

        [Fact, Priority(0)]
        public void BeginScopeInsideBackgroundThreadShouldNotBringAffect()
        {
            var testCaseResetEvent = new ManualResetEvent(false);
            var beginScopeInTaskResetEvent = new ManualResetEvent(false);

            using (var scope1 = _fixture.ScopeFactory.RequireDbTransactionalScope())
            {
                new Thread(new ThreadStart(() =>
                {
                    using (var scope2 = _fixture.ScopeFactory.RequireDbTransactionalScope("T1"))
                    {
                        beginScopeInTaskResetEvent.Set();
                        var uow2 = scope2.UnitOfWork;
                    }

                    testCaseResetEvent.Set();
                })).Start();

                beginScopeInTaskResetEvent.WaitOne();
                using (var scope3 = _fixture.ScopeFactory.RequireDbTransactionalScope())
                {
                    Assert.Equal(scope1.UnitOfWork, scope3.UnitOfWork);
                }
            }

            testCaseResetEvent.WaitOne();
        }

        [Fact, Priority(1000)]
        public void AllScopesShouldBeClearedAfterAllScopeDisposals()
        {
            Assert.True(InjectionScopeBase.Scopes.Count == 0);
        }
    }
}
