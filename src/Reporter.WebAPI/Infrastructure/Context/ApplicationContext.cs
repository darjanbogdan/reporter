using Microsoft.Owin;
using Reporter.Core.Context;
using Reporter.WebAPI.Infrastructure.Owin.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Reporter.WebAPI.Infrastructure.Context
{
    public class ApplicationContext : IApplicationContext
    {
        private Lazy<IUserInfo> userInfo;

        public ApplicationContext(IOwinContextProvider owinContextProvider)
        {
            this.userInfo = new Lazy<IUserInfo>(() => InitializeUserInfo(owinContextProvider.CurrentContext));
        }

        public IUserInfo UserInfo { get { return this.userInfo.Value; } }

        private IUserInfo InitializeUserInfo(IOwinContext currentContext)
        {
            var userInfo = new ContextUserInfo();
            userInfo.IsAuthenticated = currentContext.Authentication.User.Identity.IsAuthenticated;
            if (userInfo.IsAuthenticated)
            {
                userInfo.UserName = currentContext.Authentication.User.Identity.Name;
                userInfo.UserId = new Guid(currentContext.Authentication.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                userInfo.Roles = currentContext.Authentication.User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            }
            
            return userInfo;
        }

        private class ContextUserInfo : IUserInfo
        {
            public bool IsAuthenticated { get; set; }

            public IEnumerable<string> Roles { get; set; }

            public Guid UserId { get; set; }

            public string UserName { get; set; }
        }
    }
}