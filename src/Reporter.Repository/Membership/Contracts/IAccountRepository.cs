using Reporter.DAL.Models.Identity;
using Reporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Repository.Membership.Contracts
{
    public interface IAccountRepository
    {
        Task<Account> CreateAsync();

        Task RegisterAsync(Account user, string password);

        Task<Account> GetAsync(string userName, string password);

        Task<IEnumerable<Claim>> GetIdentityClaimsAsync(Guid userId);

        Task<ClaimsIdentity> CreateIdentityAsync(Account account, string authenticationType);
    }
}