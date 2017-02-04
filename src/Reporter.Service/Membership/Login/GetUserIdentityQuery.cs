using Reporter.Core;
using Reporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Membership.Login
{
    public class GetUserIdentityQuery : IQuery<GetUserIdentityResult>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
