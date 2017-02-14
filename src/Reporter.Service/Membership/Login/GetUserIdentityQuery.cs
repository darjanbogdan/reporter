using Reporter.Core.Query;
using Reporter.Core.Validation;
using Reporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporter.Core.Query.Arguments;

namespace Reporter.Service.Membership.Login
{
    public class GetUserIdentityQuery : IQuery<GetUserIdentityResult>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
