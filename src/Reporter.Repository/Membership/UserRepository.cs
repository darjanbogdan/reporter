using Microsoft.AspNet.Identity;
using Reporter.DAL.Models.Identity;
using Reporter.Model.Identity;
using Reporter.Repository.Membership.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Repository.Membership
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser, Guid> userManager;
        private readonly IUserStore<ApplicationUser, Guid> userStore;

        public UserRepository(UserManager<ApplicationUser, Guid> userManager, IUserStore<ApplicationUser, Guid> userStore)
        {
            this.userManager = userManager;
            this.userStore = userStore;
        }

        public Task<User> CreateAsync()
        {
            var user = new User();
            user.Id = Guid.NewGuid();
            return Task.FromResult(user);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await this.userManager.DeleteAsync(user);
                return result.Succeeded;
            }
            return false;
        }

        public async Task<IEnumerable<User>> FindAsync(string searchTerm, int page, int rpp)
        {
            var query = this.userManager.Users;
            if (!String.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(u => u.FirstName == searchTerm || u.LastName == searchTerm);
            }

            //Embedd
            query = query.Include(u => u.Roles);

            //Sorting
            query = query.OrderBy(u => u.LastName);

            //Paging
            query = query.Skip(page).Take(rpp);
            var users = await query.ToListAsync();

            return users.Select(u => new User()
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Roles = u.Roles.Select(r => new UserRole()
                {
                    RoleId = r.RoleId,
                    UserId = r.UserId
                }),
                UserName = u.UserName
            });
        }

        public Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(User newUser)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}