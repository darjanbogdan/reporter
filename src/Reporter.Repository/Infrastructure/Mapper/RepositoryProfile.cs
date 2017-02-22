using AutoMapper;
using Reporter.DAL.Entities;
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
            var mapUserToApplicationUser = this.CreateMap<User, UserEntity>();
            var mapApplicationUserToUser = this.CreateMap<UserEntity, User>();

            var mapRoleToApplicationRole = this.CreateMap<Role, RoleEntity>();
            var mapApplicationRoleToRole = this.CreateMap<RoleEntity, Role>();

            var maApplicationUserRoleToRole = this.CreateMap<UserRoleEntity, Role>();
            maApplicationUserRoleToRole.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RoleId));

            var mapApplicationUserToAccount = this.CreateMap<UserEntity, Account>();
            mapApplicationUserToAccount.ForMember(dest => dest.User, opt => opt.MapFrom(src => src));
            mapApplicationUserToAccount.ForSourceMember(src => src.Roles, opt => opt.Ignore());

            var mapAccountToApplicationUser = this.CreateMap<Account, UserEntity>();
            mapAccountToApplicationUser.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.User.Id));
            mapAccountToApplicationUser.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName));
            mapAccountToApplicationUser.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName));
            mapAccountToApplicationUser.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
            mapAccountToApplicationUser.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));
            mapAccountToApplicationUser.ForMember(dest => dest.Roles, opt => opt.Ignore());

            var mapPermissionToPermissionEntity = this.CreateMap<PermissionEntity, Permission>();
            var mapPermissionEntityToPermission = this.CreateMap<Permission, PermissionEntity>();
            var mapPermissionSectionToPermissionSectionEntity = this.CreateMap<PermissionSectionEntity, PermissionSection>();
            var mapPermissionSectionEntityToPermissionSection = this.CreateMap<PermissionSection, PermissionSectionEntity>();
            var mapPermissionPolicyToPermissionPolicyEntity = this.CreateMap<PermissionPolicyEntity, PermissionPolicy>();
            var mapPermissionPolicyEntityToPermissionPolicy = this.CreateMap<PermissionPolicy, PermissionPolicyEntity>();


            var mapClientToClientEntity = this.CreateMap<ClientEntity, Client>();
            var mapClientEntityToClient = this.CreateMap<Client, ClientEntity>();
        }
    }
}