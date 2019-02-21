using System.Web.Http;
using System.Web.Http.Dispatcher;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Cortlex.Rescope;
using Cortlex.Rescope.Abstractions;
using Cortlex.Rescope.CastleWindsor;
using Cortlex.Rescope.CustomScope.Example;
using NETFramework.Web.CastleWindsor.Example.Services;

namespace NETFramework.Web.CastleWindsor.Example
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var container = new WindsorContainer();
            container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleTransient());
            container.Register(Component.For<UnitOfWork>().LifestyleScoped<ScopeAccessor>());
            container.Register(Component.For<ServiceA>().LifestyleTransient());

            container.Register(Component.For<IScopeOptions>().UsingFactoryMethod(c => ScopeOptions.Options).LifestyleSingleton());
            ScopeOptions.Options.UseCastleWindsor(container.Kernel);

            container.Register(Component.For<IDbScopeFactory>().ImplementedBy<DbScopeFactory>().LifestyleSingleton());
            
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorCompositionRoot(container));
        }
    }
}
