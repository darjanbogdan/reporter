using Reporter.Service.Membership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporter.Model.Identity;
using System.Security.Claims;
using Reporter.Repository.Membership.Contracts;
using AutoMapper;
using Reporter.DAL.Models.Identity;

namespace Reporter.Service.Membership
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        private readonly IMapper mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.mapper = mapper;
        }

        public Task<ClaimsIdentity> CreateIdentityAsync(Account account)
        {
            var applicationUser = this.mapper.Map<ApplicationUser>(account);

            return this.accountRepository.CreateIdentityAsync(applicationUser, "JWT");
        }

        public async Task<Account> GetAccountAsync(string userName, string password)
        {
            var applicationUser = await this.accountRepository.GetAsync(userName, password);

            return this.mapper.Map<Account>(applicationUser);
        }

        public Task RegisterAccountAsync(AccountRegistration accountRegistration)
        {
            var user = this.mapper.Map<User>(accountRegistration);
            user.Id = Guid.NewGuid();

            return this.accountRepository.RegisterAsync(user, accountRegistration.Password);
        }
    }
}
