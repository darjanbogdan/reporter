using Reporter.Service.Membership;
using Reporter.Service.Membership.Contracts;
using SimpleInjector;
using SimpleInjector.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service
{
    public class PackageRegister : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IUserService, UserService>();
            container.RegisterSingleton<Func<IUserService>>(() => container.GetInstance<IUserService>());

            container.Register<IAccountService, AccountService>();
            container.RegisterSingleton<Func<IAccountService>>(() => container.GetInstance<IAccountService>());
        }
    }
}
