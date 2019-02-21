using System;
using Cortlex.Rescope.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cortlex.Rescope.NETCore
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddScopes(this IServiceCollection services, Action<IServiceProvider, IScopeOptions> configure)
        {
            services.AddSingleton<IScopeOptions>(serviceProvider =>
            {
                configure(serviceProvider, ScopeOptions.Options);
                return ScopeOptions.Options;
            });

            return services;
        }
    }
}
