using AutoMapper;
using Reporter.DAL.Models.Identity;
using Reporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Repository.Infrastructure.Mapper
{
    public class RepositoryProfile : Profile
    {
        public RepositoryProfile()
            : base(nameof(RepositoryProfile))
        {
            var mapUserToApplicationUser = this.CreateMap<User, ApplicationUser>();
            var mapApplicationUserToUser = this.CreateMap<ApplicationUser, User>();

            var mapRoleToApplicationRole = this.CreateMap<Role, ApplicationRole>();
            var mapApplicationRoleToRole = this.CreateMap<ApplicationRole, Role>();

            var maApplicationUserRoleToRole = this.CreateMap<ApplicationUserRole, Role>();
            maApplicationUserRoleToRole.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RoleId));

            var mapApplicationUserToAccount = this.CreateMap<ApplicationUser, Account>();
            mapApplicationUserToAccount.ForMember(dest => dest.User, opt => opt.MapFrom(src => src));
            mapApplicationUserToAccount.ForSourceMember(src => src.Roles, opt => opt.Ignore());

            var mapAccountToApplicationUser = this.CreateMap<Account, ApplicationUser>();
            mapAccountToApplicationUser.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.User.Id));
            mapAccountToApplicationUser.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName));
            mapAccountToApplicationUser.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName));
            mapAccountToApplicationUser.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
            mapAccountToApplicationUser.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));
            mapAccountToApplicationUser.ForMember(dest => dest.Roles, opt => opt.Ignore());
        }
    }
}