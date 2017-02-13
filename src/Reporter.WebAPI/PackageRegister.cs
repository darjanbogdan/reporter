using Reporter.Core.Context;
using Reporter.WebAPI.Infrastructure.Context;
using SimpleInjector;
using SimpleInjector.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reporter.WebAPI
{
    public class PackageRegister : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IApplicationContext, ApplicationContext>(Lifestyle.Scoped);
            container.Register<Func<IApplicationContext>>(() => container.GetInstance<IApplicationContext>, Lifestyle.Singleton);
        }
    }
}