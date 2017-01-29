using Reporter.DAL.Models.Identity;
using Reporter.Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Repository.Identity.Contracts
{
    public interface IAccountRepository
    {
        Task RegisterAsync(User user);

        Task<ApplicationUser> FindAsync(string userName, string password);

        Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUser user, string authenticationType);
    }
}