using System;
using Microsoft.Extensions.DependencyInjection;

namespace Cortlex.Rescope.NETCore.Configuration
{
    public class RescopeBuilder: IRescopeBuilder
    {
        public IServiceCollection Services { get; }

        public RescopeBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }
    }
}
