using Cortlex.Rescope.Tests.Setup.Fixtures;
using Xunit;

namespace Cortlex.Rescope.Tests
{
    [Collection("Scope Tests")]
    public class CastleWindsorTests: ScopeTestsBase<CastleWindsorFixture>
    {
        public CastleWindsorTests(CastleWindsorFixture fixture) : base(fixture)
        {
        }
    }
}
