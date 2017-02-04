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
        private const string joinDelimiter = "\n";

        private readonly UserManager<ApplicationUser, Guid> userManager;

        private readonly IMapper mapper;

        public AccountRepository(UserManager<ApplicationUser, Guid> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task RegisterAsync(User user, string password)
        {
            var appUser = this.mapper.Map<ApplicationUser>(user);

            IdentityResult result = null;
            try
            {
                result = await this.userManager.CreateAsync(appUser, password);
            }
            catch (DbEntityValidationException ex)
            {
                var validationErrors = ex.EntityValidationErrors.Where(ev => !ev.IsValid).SelectMany(ev => ev.ValidationErrors);

                var validationErrorMessages = validationErrors.Select(ve => String.Format("{0}: {1}", ve.PropertyName, ve.ErrorMessage));

                throw new ArgumentException(String.Join(joinDelimiter, validationErrorMessages));
            }

            if (!result.Succeeded)
            {
                throw new ArgumentException(String.Join(joinDelimiter, result.Errors));
            }
        }

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
                userIdentity.AddClaim(new Claim(ClaimTypes.Role, role.RoleId.ToString()));
            }

            return userIdentity;
        }
    }
}