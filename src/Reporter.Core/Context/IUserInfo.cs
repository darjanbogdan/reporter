using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Context
{
    public interface IUserInfo
    {
        bool IsAuthenticated { get; }

        string UserName { get; }

        Guid UserId { get; }

        IEnumerable<string> Roles { get; }

        string Email { get; }
    }
}
