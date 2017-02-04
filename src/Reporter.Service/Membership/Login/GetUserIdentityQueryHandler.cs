using Reporter.Core.Query;
using Reporter.Model;
using Reporter.Repository.Membership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Membership.Login
{
    public class GetUserIdentityQueryHandler : IQueryHandler<GetUserIdentityQuery, GetUserIdentityResult>
    {
        private readonly IAccountRepository accountRepository;
        
        public GetUserIdentityQueryHandler(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task<GetUserIdentityResult> RunAsync(GetUserIdentityQuery query)
        {
            GetUserIdentityResult result = new GetUserIdentityResult();

            if (query == null || String.IsNullOrWhiteSpace(query.UserName) || String.IsNullOrWhiteSpace(query.Password))
            {
                result.IsError = true;
                result.ErrorResponse = "invalid_request";
                result.ErrorDescription = "The request is missing required parameters user name or password.";
                return result;
            }

            var account = await this.accountRepository.GetAsync(query.UserName, query.Password);
            if (account == null)
            {
                result.IsError = true;
                result.ErrorResponse = "invalid_grant";
                result.ErrorDescription = "The user name or password is incorrect.";
            }
            else if (!account.EmailConfirmed)
            {
                result.IsError = true;
                result.ErrorResponse = "invalid_grant";
                result.ErrorDescription = "User did not confirm email.";
            }
            else
            {
                ClaimsIdentity identity = await this.accountRepository.CreateIdentityAsync(account, "JWT");
                identity.AddClaims(await this.accountRepository.GetIdentityClaimsAsync(account.User.Id));
                result.ClaimsIdentity = identity;
            }
            return result;
        }
    }
}
