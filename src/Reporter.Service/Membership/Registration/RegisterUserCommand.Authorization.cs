using Reporter.Core.Command.Authorization;
using Reporter.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Membership.Registration
{
    public partial class RegisterUserCommand : IAuthorizationCommand
    {
        string IAuthorizationCommand.PermissionSection { get { return PermissionSectionMap.Membership; } }

        string IAuthorizationCommand.Permission { get { return PermissionMap.CreateAbrv; } }

        Guid? IAuthorizationCommand.OwnerId { get { return null;  /*Better example this.UserId from command*/ } }
    }
}
