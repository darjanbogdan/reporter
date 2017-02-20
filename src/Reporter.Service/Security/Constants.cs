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
        public const string GeneralSection = "general-section";

        public const string ClientSection = "client-section";

        public const string ProjectSection = "project-section";

        public const string ReportSection = "report-section";
    }
}
