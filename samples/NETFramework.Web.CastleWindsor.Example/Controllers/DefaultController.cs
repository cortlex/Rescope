using System.Web.Http;
using NETFramework.Web.CastleWindsor.Example.Scopes;
using NETFramework.Web.CastleWindsor.Example.Services;

namespace NETFramework.Web.CastleWindsor.Example.Controllers
{
    public class DefaultController : ApiController
    {
        private readonly IDbScopeFactory _dbScopeFactory;
        private readonly ServiceA _serviceA;

        public DefaultController(IDbScopeFactory dbScopeFactory, ServiceA serviceA)
        {
            _dbScopeFactory = dbScopeFactory;
            _serviceA = serviceA;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            using (var scope = _dbScopeFactory.RequireDbTransactionalScope())
            {
                var uow = scope.UnitOfWork;

                _serviceA.Run();
            }

            return Ok();
        }
    }
}
