using AutoMapper;
using Reporter.Core.Command;
using Reporter.Core.Context;
using Reporter.Service.Membership.Registration;
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
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly ICommandHandler<RegisterUserCommand> registerUserCommandHandler;
        private readonly IMapper mapper;

        public AccountController(ICommandHandler<RegisterUserCommand> registerUserCommandHandler, IMapper mapper)
        {
            this.registerUserCommandHandler = registerUserCommandHandler;
            this.mapper = mapper;
        }

        [Route("register")]
        [HttpPost]
        public async Task<HttpResponseMessage> RegisterAsync(RegisterUserRest registerUser)
        {
            var command = this.mapper.Map<RegisterUserCommand>(registerUser);

            await this.registerUserCommandHandler.ExecuteAsync(command);

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        //TODO: Implement account activation (opt-in)
        //TODO: Implement change password and/or forgot password (opt-in)
        //TODO: Implement change email (opt-in) ?

        public class RegisterUserRest
        {
            public string UserName { get; set; }

            public string Password { get; set; }

            public string ConfirmPassword { get; set; }

            public string Email { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }
        }
    }
}