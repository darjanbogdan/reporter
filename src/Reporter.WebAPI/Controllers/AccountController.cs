﻿using AutoMapper;
using Reporter.Core;
using Reporter.Service.Membership.Registration;
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
        public async Task<HttpResponseMessage> RegisterAsync(RegisterUser registerUser)
        {
            var command = this.mapper.Map<RegisterUserCommand>(registerUser);

            await this.registerUserCommandHandler.HandleAsync(command);

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        public class RegisterUser
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