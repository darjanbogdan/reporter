using AutoMapper;
using Reporter.Model;
using Reporter.Service.Membership.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Infrastructure.Mapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile() 
            : base(nameof(ServiceProfile))
        {
            var mapUserFromRegisterUserCommand = CreateMap<RegisterUserCommand, User>();
            var mapAccountFromRegisterUserCommand = CreateMap<RegisterUserCommand, Account>();
            mapAccountFromRegisterUserCommand.ForMember(dest => dest.User, opt => opt.MapFrom(src => src));
        }
    }
}
