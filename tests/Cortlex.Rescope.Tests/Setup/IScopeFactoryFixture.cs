using System;
using Cortlex.Rescope.CustomScope.Example;

namespace Cortlex.Rescope.Tests.Setup
{
    public interface IScopeFactoryFixture: IDisposable
    {
        IDbScopeFactory ScopeFactory { get; }
    }
}