using Reporter.Service.Membership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporter.Model.Identity;
using Reporter.Repository.Membership.Contracts;

namespace Reporter.Service.Membership
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<IEnumerable<User>> FindAsync(string searchTerm, int page, int rpp)
        {
            return this.userRepository.FindAsync(searchTerm, page, rpp);
        }
    }
}
