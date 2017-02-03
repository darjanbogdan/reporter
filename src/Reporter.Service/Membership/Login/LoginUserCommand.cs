using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Membership.Login
{
    public class LoginUserCommand
    {
        string UserName { get; set; }

        string Password { get; set; }
    }
}
