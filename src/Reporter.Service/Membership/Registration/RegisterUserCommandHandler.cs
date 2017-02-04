using AutoMapper;
using Reporter.Core.Command;
using Reporter.Model;
using Reporter.Repository.Membership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Membership.Registration
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IAccountRepository accountRepository;
        private readonly IMapper mapper;

        public RegisterUserCommandHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.mapper = mapper;
        }

        public async Task ExecuteAsync(RegisterUserCommand command)
        {
            var account = await this.accountRepository.CreateAsync();

            this.mapper.Map(command, account);

            //TODO: Replace this with activation account logic
            account.EmailConfirmed = true;

            var roles = new List<Role>();
            account.User.Roles = roles;
            var userRole = new Role()
            {
                Id = new Guid("21079E62-E12C-47D4-A6D6-16352BB8EBAA"),
                Name = "User"
            };
            roles.Add(userRole);

            await this.accountRepository.RegisterAsync(account, command.Password);
        }
    }
}
