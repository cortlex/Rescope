using System;
using AspNetCore.Web.Autofac.Example.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Cortlex.Rescope;
using Cortlex.Rescope.Abstractions;
using Cortlex.Rescope.Autofac;
using Cortlex.Rescope.CustomScope.Example;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.Web.Autofac.Example
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddControllersAsServices();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterType<UnitOfWork>().As<UnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ServiceA>().AsSelf().InstancePerDependency();
            
            builder.RegisterType<DbScopeFactory>().As<IDbScopeFactory>().SingleInstance();
            
            builder.RegisterInstance<IScopeOptions>(ScopeOptions.Options).SingleInstance();
            var container = builder.Build();
            
            ScopeOptions.Options.UseAutofac(container);
            
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
