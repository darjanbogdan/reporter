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
            var appUser = this.mapper.Map<ApplicationUser>(account); //TODO: Check this

            var result = await this.userManager.CreateAsync(appUser, password);
            if (!result.Succeeded)
            {
                throw new ArgumentException(String.Join(joinDelimiter, result.Errors));
            }

            if (account.User.Roles != null && account.User.Roles.Any())
            {
                await this.userManager.AddToRolesAsync(appUser.Id, account.User.Roles.Select(r => r.Name).ToArray());
            }
        }

        //TODO: AddToRoles dedicated method

        //TODO: AddClaims dedicated method

        public async Task<Account> GetAsync(string userName, string password)
        {
            return this.mapper.Map<Account>(await this.userManager.FindAsync(userName, password));
        }

        public async Task<IEnumerable<Claim>> GetIdentityClaimsAsync(Guid userId)
        {
            return await this.userManager.GetClaimsAsync(userId);
        }

        public async Task<ClaimsIdentity> CreateIdentityAsync(Account account, string authenticationType)
        {
            var appUser = this.mapper.Map<ApplicationUser>(account);

            var userIdentity = await this.userManager.CreateIdentityAsync(appUser, authenticationType);

            foreach (var role in account.User.Roles)
            {
                userIdentity.AddClaim(new Claim(ClaimTypes.Role, role.Id.ToString()));
            }

            return userIdentity;
        }
    }
}