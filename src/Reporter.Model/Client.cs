using System;
using System.Collections.Generic;

namespace Reporter.Model
{
    public class Client
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ClientManagerId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public User ClientManager { get; set; }

        public IEnumerable<ClientPermissionPolicy> ClientPermissionPolicies { get; set; }

        public IEnumerable<ClientProject> ClientProjects { get; set; }
    }
}
