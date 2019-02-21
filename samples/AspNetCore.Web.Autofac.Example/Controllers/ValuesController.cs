using System.Collections.Generic;
using AspNetCore.Web.Autofac.Example.Scopes;
using AspNetCore.Web.Autofac.Example.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Web.Autofac.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDbScopeFactory _dbScopeFactory;
        private readonly ServiceA _serviceA;

        public ValuesController(IDbScopeFactory dbScopeFactory, ServiceA serviceA)
        {
            _dbScopeFactory = dbScopeFactory;
            _serviceA = serviceA;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            using (var scope = _dbScopeFactory.RequireDbTransactionalScope())
            {
                var uow = scope.UnitOfWork;

                _serviceA.Run();
            }

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
