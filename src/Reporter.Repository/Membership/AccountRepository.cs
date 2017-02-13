using AutoMapper;
using Microsoft.AspNet.Identity;
using Reporter.DAL.Models.Identity;
using Reporter.Model;
using Reporter.Repository.Membership.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Repository.Membership
{
    public class AccountRepository : IAccountRepository
    {
        private const string joinDelimiter = "\r\n";

        private readonly UserManager<ApplicationUser, Guid> userManager;

        private readonly IMapper mapper;

        public AccountRepository(UserManager<ApplicationUser, Guid> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public Task<Account> CreateAsync()
        {
            var account = new Account();
            account.User = new User();
            account.User.Id = Guid.NewGuid(); //TODO: Replace with sequential guid
            return Task.FromResult(account);
        }

        public async Task RegisterAsync(Account account, string password)
        {
            var appUser = this.mapper.Map<ApplicationUser>(account);

            var result = await this.userManager.CreateAsync(appUser, password);
            if (!result.Succeeded)
            {
                throw new ArgumentException(String.Join(joinDelimiter, result.Errors));
            }
            //TODO: Add claims to database
        }

        public async Task InsertUserRolesAsync(Guid userId, IEnumerable<Role> roles)
        {
            if (roles == null) throw new ArgumentNullException(nameof(roles));

            var result = await this.userManager.AddToRolesAsync(userId, roles.Select(r => r.Name).ToArray());
            if (!result.Succeeded)
            {
                throw new ArgumentException(String.Join(joinDelimiter, result.Errors));
            }
        }

        public async Task<Account> GetAsync(string userName, string password)
        {
            var appUser = await this.userManager.FindAsync(userName, password);

            return this.mapper.Map<Account>(appUser);
        }

        public Task<ClaimsIdentity> CreateIdentityAsync(Account account, string authenticationType)
        {
            var appUser = this.mapper.Map<ApplicationUser>(account);
            //TODO: Fetch claims from database (?)
            return this.userManager.CreateIdentityAsync(appUser, authenticationType);
        }
    }
}