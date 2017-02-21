using Reporter.Core.Validation;
using Reporter.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Membership.Registration
{
    public partial class RegisterUserCommand : IValidate
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }  

        public string LastName { get; set; }
    }
}
