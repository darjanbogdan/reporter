using Microsoft.AspNet.Identity;
using Reporter.DAL.Context;
using Reporter.DAL.Identity.Manager;
using Reporter.DAL.Identity.Stores;
using Reporter.DAL.Entities;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Packaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.DAL
{
    public class PackageRegister : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<DbContext>(() => new ApplicationDbContext(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString), Lifestyle.Scoped);

            container.Register<IUserStore<UserEntity, Guid>, ApplicationUserStore>(Lifestyle.Scoped);

            container.Register<IRoleStore<RoleEntity, Guid>, ApplicationRoleStore>(Lifestyle.Scoped);

            container.Register<UserManager<UserEntity, Guid>, ApplicationUserManager>(Lifestyle.Scoped);

            container.Register(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}