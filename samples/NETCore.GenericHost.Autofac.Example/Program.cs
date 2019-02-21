﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using Cortlex.Rescope.Autofac;
using Cortlex.Rescope.NETCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NETCore.GenericHost.Autofac.Example.Scopes;
using NETCore.GenericHost.Autofac.Example.Services;

namespace NETCore.GenericHost.Autofac.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new HostBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<HostOptions>(option =>
                    {
                        option.ShutdownTimeout = System.TimeSpan.FromSeconds(20);
                    });

                    services.AddScoped<UnitOfWork>();
                    services.AddHostedService<HostedService>();

                    services.AddScopes((provider, options) => { options.UseAutofac(provider.GetService<ILifetimeScope>()); });

                    services.AddSingleton<IDbScopeFactory, DbScopeFactory>();
                }).ConfigureContainer<ContainerBuilder>((context, builder) =>
                {
                    
                })
                .Build();

            host.Run();
        }
    }
}
