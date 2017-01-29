using AutoMapper;
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
        public override string ProfileName
        {
            get
            {
                return nameof(RepositoryProfile);
            }
        }

        protected override void Configure()
        {
            this.CreateMap<User, ApplicationUser>();
        }
    }
}