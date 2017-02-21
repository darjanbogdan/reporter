using AutoMapper;
using Reporter.Model;
using Reporter.Service.ClientManagement.CreateClient;
using Reporter.Service.ClientManagement.UpdateClient;
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
            var mapFromRegisterUserToRegisterUser = CreateMap<AccountController.RegisterUserRest, RegisterUserCommand>();

            var mapFromClientRestCreateClient = CreateMap<ClientController.ClientRest, CreateClientCommand>();
            var mapFromClientRestToUpdateClient = CreateMap<ClientController.ClientRest, UpdateClientCommand>();
            mapFromClientRestToUpdateClient.ForMember(dest => dest.Id, opt => opt.Ignore());

            var mapFromClientToClientRest = CreateMap<Client, ClientController.ClientRest>();
            mapFromClientToClientRest.ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.ClientManagerId));
        }
    }
}