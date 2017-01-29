using Reporter.WebAPI.Infrastructure.Owin.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Reporter.WebAPI.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        private readonly IOwinContextProvider provider;

        public TestController(IOwinContextProvider provider)
        {
            this.provider = provider;
        }

        [Route("")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAsync()
        {
            var owinContext = HttpContext.Current.GetOwinContext();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
