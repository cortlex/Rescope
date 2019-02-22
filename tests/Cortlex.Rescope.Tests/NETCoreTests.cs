using Cortlex.Rescope.Tests.Setup.Fixtures;
using Xunit;

namespace Cortlex.Rescope.Tests
{
    [Collection("Scope Tests")]
    public class NETCoreTests: ScopeTestsBase<NETCoreScopeFixture>
    {
        public NETCoreTests(NETCoreScopeFixture fixture) : base(fixture)
        {
        }
    }
}
