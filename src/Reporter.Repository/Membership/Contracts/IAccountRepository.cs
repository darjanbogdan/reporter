using Reporter.Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Reporter.Repository.Membership.Contracts
{
    public interface IAccountRepository
    {
        Task<Account> CreateAsync();

        Task InsertUserRolesAsync(Guid userId, IEnumerable<Role> roles);

        Task RegisterAsync(Account user, string password);

        Task<Account> GetAsync(string userName, string password);

        Task<ClaimsIdentity> CreateIdentityAsync(Account account, string authenticationType);
    }
}