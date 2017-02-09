using Reporter.Core.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Command.Authorization
{
    public interface IAuthorizationEvaluator
    {
        Task EvaluateAsync(IAuthorize commandToAuthorize);
    }
}
