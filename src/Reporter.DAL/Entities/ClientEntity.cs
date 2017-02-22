using Reporter.DAL.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Entities
{
    public partial class ClientEntity : IEntity
    {
        public ClientEntity()
        {
            ClientPermissionPolicies = new HashSet<ClientPermissionPolicyEntity>();
            ClientProjects = new HashSet<ClientProjectEntity>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ClientManagerId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public UserEntity ClientManager { get; set; }

        public virtual ICollection<ClientPermissionPolicyEntity> ClientPermissionPolicies { get; set; }

        public virtual ICollection<ClientProjectEntity> ClientProjects { get; set; }
    }
}
