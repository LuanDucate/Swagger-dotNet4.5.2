using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Swagger_Configuration.Controllers
{
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get(string name)
        {
            return Ok($"Hello {name}, nice to meet you");
        }
    }
}
