using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Model
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual string Email { get; set; }

        public virtual Guid Id { get; set; }

        public virtual IEnumerable<Role> Roles { get; set; }

        public virtual string UserName { get; set; }
    }
}