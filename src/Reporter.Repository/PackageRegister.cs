using Reporter.Repository.Membership;
using Reporter.Repository.Membership.Contracts;
using SimpleInjector;
using SimpleInjector.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Repository
{
    public class PackageRegister : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IUserRepository, UserRepository>(Lifestyle.Transient);
            container.Register<IAccountRepository, AccountRepository>(Lifestyle.Transient);
        }
    }
}