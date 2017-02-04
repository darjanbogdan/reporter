using AutoMapper;
using Reporter.Core.Command;
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
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;


        public RegisterUserCommandHandler(IAccountRepository accountRepository, IUserRepository userRepository, IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task ExecuteAsync(RegisterUserCommand command)
        {
            var user = await this.userRepository.CreateAsync();

            this.mapper.Map(command, user);

            await this.accountRepository.RegisterAsync(user, command.Password);
        }
    }
}
