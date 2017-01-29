using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Reporter.Service.Membership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Reporter.WebAPI.Infrastructure.Security.OAuth
{
    public class ReporterOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly Func<IAccountService> accountServiceFactory;

        public ReporterOAuthProvider(Func<IAccountService> accountServiceFactory)
        {
            this.accountServiceFactory = accountServiceFactory;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var accountService = this.accountServiceFactory.Invoke();

            var user = await accountService.GetAccountAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            if (!user.EmailConfirmed)
            {
                context.SetError("invalid_grant", "User did not confirm email.");
                return;
            }

            ClaimsIdentity oAuthIdentity = await accountService.CreateIdentityAsync(user);

            foreach (var role in user.User.Roles)
            {
                oAuthIdentity.AddClaims(new[] { new Claim(ClaimTypes.Role, role.RoleId.ToString()) });
            }

            var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(ticket);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }
    }
}