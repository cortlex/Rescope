using Cortlex.Rescope.Tests.Setup.Fixtures;
using Xunit;

namespace Cortlex.Rescope.Tests
{
    [Collection("Scope Tests")]
    public class AutofacTests: ScopeTestsBase<AutofacFixture>
    {
        public AutofacTests(AutofacFixture fixture) : base(fixture)
        {

        }
    }
}