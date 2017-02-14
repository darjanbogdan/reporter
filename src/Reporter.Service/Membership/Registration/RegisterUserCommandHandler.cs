using AutoMapper;
using Reporter.Core.Command;
using Reporter.Model;
using Reporter.Repository.Membership.Contracts;
using Reporter.Repository.Security.Contracts;
using Reporter.Service.Membership.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Membership.Registration
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IAccountRepository accountRepository;
        private readonly IRoleLookup roleLookup;
        private readonly IMapper mapper;

        public RegisterUserCommandHandler(IAccountRepository accountRepository, IRoleLookup roleLookup, IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.roleLookup = roleLookup;
            this.mapper = mapper;
        }

        public async Task ExecuteAsync(RegisterUserCommand command)
        {
            var account = await this.accountRepository.CreateAsync();

            this.mapper.Map(command, account);

            //TODO: Replace this with activation account logic
            account.EmailConfirmed = true;

            await this.accountRepository.RegisterAsync(account, command.Password);

            var userRole = await this.roleLookup.GetUserRoleAsync();

            await this.accountRepository.InsertUserRolesAsync(account.User.Id, new[] { userRole });
        }
    }
}