using AutoMapper;
using Reporter.Service.Membership.Registration;
using Reporter.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reporter.WebAPI.Infrastructure.Mapper
{
    public class WebAPIProfile : Profile
    {
        public WebAPIProfile()
            : base(nameof(WebAPIProfile))
        {
            var mapFromRegisterUser = CreateMap<AccountController.RegisterUser, RegisterUserCommand>();
        }
    }
}