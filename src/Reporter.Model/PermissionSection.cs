using System;

namespace Reporter.Model
{
    public partial class PermissionSection
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public int Order { get; set; }
    }
}
