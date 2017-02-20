using AutoMapper;
using Reporter.Model;
using Reporter.Service.ClientManagement.CreateClient;
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

            var mapFromClientRest = CreateMap<ClientController.ClientRest, CreateClientCommand>();
            var mapFromClient = CreateMap<Client, ClientController.ClientRest>();
            mapFromClient.ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.ClientManagerId));
        }
    }
}