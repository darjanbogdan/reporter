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
        Task RegisterAsync(User user, string password);

        Task<ApplicationUser> GetAsync(string userName, string password);

        Task<ClaimsIdentity> CreateIdentityAsync(Account account, string authenticationType);
    }
}