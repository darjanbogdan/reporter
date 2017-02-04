using Reporter.Core;
using Reporter.Service.Membership.Login;
using Reporter.WebAPI.Infrastructure.Security.OAuth;
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
        }
    }
}