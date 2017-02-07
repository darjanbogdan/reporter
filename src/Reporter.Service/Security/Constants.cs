using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Security
{
    public static class PermissionMap
    {
        public const string CreateAbrv = "create";

        public const string ReadAbrv = "read";

        public const string UpdateAbrv = "update";

        public const string DeleteAbrv = "delete";

        public const string FullAbrv = "full";
    }

    public static class PermissionSectionMap
    {
        public const string Membership = "Membership"; //TODO: Maybe split into Role-User

        public const string Client = "Client";

        public const string Project = "Project";

        public const string Report = "Report";
    }
}
