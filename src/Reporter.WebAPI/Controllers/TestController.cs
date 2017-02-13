using Reporter.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Reporter.WebAPI.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        private readonly Func<IApplicationContext> applicationContextFactory;

        public TestController(Func<IApplicationContext> applicationContextFactory)
        {
            this.applicationContextFactory = applicationContextFactory;
        }

        [Route("")]
        [HttpGet]
        public async Task<HttpResponseMessage> TestAsync()
        {
            var ctx = this.applicationContextFactory();
            return Request.CreateResponse(HttpStatusCode.OK, ctx.UserInfo);
        }
    }
}
