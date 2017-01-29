﻿using AutoMapper;
using Reporter.DAL.Models.Identity;
using Reporter.Model.Identity;
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
        {
            var mapUserToApplicationUser = this.CreateMap<User, ApplicationUser>();
            var mapApplicationUserToUser = this.CreateMap<ApplicationUser, User>();

            var mapApplicationUserToAccount = this.CreateMap<ApplicationUser, Account>();
            mapApplicationUserToAccount.ForMember(dest => dest.User, opt => opt.MapFrom(src => src));

            var mapAccountToApplicationUser = this.CreateMap<Account, ApplicationUser>();
            mapAccountToApplicationUser.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.User.Id));
            mapAccountToApplicationUser.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName));
            mapAccountToApplicationUser.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName));
            mapAccountToApplicationUser.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
            mapAccountToApplicationUser.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));
            mapAccountToApplicationUser.ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.User.Roles));

            var mapAccountRegistrationToUser = this.CreateMap<AccountRegistration, User>();
            var mapUserToAccountRegistration = this.CreateMap<User, AccountRegistration>();
        }

        public override string ProfileName
        {
            get
            {
                return nameof(RepositoryProfile);
            }
        }
    }
}