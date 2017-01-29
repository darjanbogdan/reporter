using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
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
        public ReporterOAuthProvider()
        {

        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //var allowedOrigin = "*";

            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            //var userManager = context.OwinContext.GetUserManager<UserManager<ApplicationUser, Guid>>();

            //ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

            //if (user == null)
            //{
            //    context.SetError("invalid_grant", "The user name or password is incorrect.");
            //    return;
            //}

            //if (!user.EmailConfirmed)
            //{
            //    context.SetError("invalid_grant", "User did not confirm email.");
            //    return;
            //}

            //ClaimsIdentity oAuthIdentity = await userManager.CreateIdentityAsync(user, "JWT");
            //oAuthIdentity.AddClaims(new[] { new Claim(ClaimTypes.Role, "User") });

            //var ticket = new AuthenticationTicket(oAuthIdentity, null);

            //context.Validated(ticket);

            return Task.FromResult(true);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }
    }
}