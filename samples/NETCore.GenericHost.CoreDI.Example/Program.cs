using Cortlex.Rescope.CustomScope.Example;
using Cortlex.Rescope.NETCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NETCore.GenericHost.CoreDI.Example.Services;

namespace NETCore.GenericHost.CoreDI.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<HostOptions>(option =>
                    {
                        option.ShutdownTimeout = System.TimeSpan.FromSeconds(20);
                    });

                    services.AddScoped<UnitOfWork>();
                    services.AddHostedService<HostedService>();

                    services.AddRescope((provider, options) => { options.UseCoreDI(provider.GetService<IServiceScopeFactory>()); });
                    
                    services.AddSingleton<IDbScopeFactory, DbScopeFactory>();
                })
                .Build();

            host.Run();
        }
    }
}
