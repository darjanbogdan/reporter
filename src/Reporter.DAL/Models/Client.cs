using Reporter.DAL.Models.Contracts;
using Reporter.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Models
{
    public partial class Client : IDbModel
    {
        public Client()
        {
            ClientPermissionPolicies = new HashSet<ClientPermissionPolicy>();
            ClientProjects = new HashSet<ClientProject>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ClientManagerId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public ApplicationUser ClientManager { get; set; }

        public virtual ICollection<ClientPermissionPolicy> ClientPermissionPolicies { get; set; }

        public virtual ICollection<ClientProject> ClientProjects { get; set; }
    }
}
