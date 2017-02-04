using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Reporter.Core.Query;
using Reporter.Service.Membership.Contracts;
using Reporter.Service.Membership.Login;
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
        private const string allowedOrigin = "*";

        private readonly Func<IQueryHandler<GetUserIdentityQuery, GetUserIdentityResult>> getUserIdentityQueryFactory;

        public ReporterOAuthProvider(Func<IQueryHandler<GetUserIdentityQuery, GetUserIdentityResult>> getUserIdentityQueryFactory)
        {
            this.getUserIdentityQueryFactory = getUserIdentityQueryFactory;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var query = new GetUserIdentityQuery()
            {
                UserName = context.UserName,
                Password = context.Password
            };

            var result = await this.getUserIdentityQueryFactory.Invoke().RunAsync(query);
            if (result.IsError)
            {
                context.SetError(result.ErrorResponse, result.ErrorDescription);
                return;
            }

            var ticket = new AuthenticationTicket(result.ClaimsIdentity, null);

            context.Validated(ticket);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }
    }
}