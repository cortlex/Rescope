using System;
using Cortlex.Rescope.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cortlex.Rescope.NETCore.Configuration
{
    public static class ServicesExtensions
    {
        public static RescopeBuilder AddRescope(this IServiceCollection services, Action<IServiceProvider, IScopeOptions> configure)
        {
            services.AddSingleton<IScopeOptions>(serviceProvider =>
            {
                configure(serviceProvider, ScopeOptions.Options);
                return ScopeOptions.Options;
            });

            return new RescopeBuilder(services);
        }
    }
}
