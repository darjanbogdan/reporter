using Reporter.DAL.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Entities
{
    public partial class ClientProjectEntity : IEntity
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public Guid ProjectId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public virtual ClientEntity Client { get; set; }

        public virtual ProjectEntity Project { get; set; }
    }
}
