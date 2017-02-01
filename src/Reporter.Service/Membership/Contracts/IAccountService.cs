using Reporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Membership.Contracts
{
    public interface IAccountService
    {
        Task<Account> GetAccountAsync(string userName, string password);

        Task<ClaimsIdentity> CreateIdentityAsync(Account account);

        Task RegisterAccountAsync(AccountRegistration accountRegistration);
    }
}
