using Microsoft.Extensions.DependencyInjection;

namespace Cortlex.Rescope.NETCore.Configuration
{
    public interface IRescopeBuilder
    {
        IServiceCollection Services { get; }
    }
}
