using Reporter.Model;
using Reporter.Service.Membership.Contracts;
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

        private readonly IAccountService accountService;

        public TestController(IOwinContextProvider provider, IAccountService accountService)
        {
            this.provider = provider;
            this.accountService = accountService;
        }

        [Route("")]
        [HttpGet]
        public Task<HttpResponseMessage> GetAsync()
        {
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK));
        }

        [Route("")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync()
        {
            var accountRegistration = new AccountRegistration()
            {
                FirstName = "Darjan",
                LastName = "Bogdan",
                UserName = "darjan",
                Email = "test@gmail.com",
                Password = "123456",
                ConfirmPassword = "123456"
            };

            await this.accountService.RegisterAccountAsync(accountRegistration);

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
