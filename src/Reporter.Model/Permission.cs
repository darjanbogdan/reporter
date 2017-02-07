using System;

namespace Reporter.Model
{
    public partial class Permission
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public int Order { get; set; }
    }
}
