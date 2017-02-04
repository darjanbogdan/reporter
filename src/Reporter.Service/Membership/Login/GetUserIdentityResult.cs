using Reporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Membership.Login
{
    public class GetUserIdentityResult
    {
        public ClaimsIdentity ClaimsIdentity { get; set; }

        public bool IsError { get; set; }

        public string ErrorResponse { get; set; }

        public string ErrorDescription { get; set; }
    }
}
