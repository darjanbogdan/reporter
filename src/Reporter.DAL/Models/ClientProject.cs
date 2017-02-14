using Reporter.DAL.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Models
{
    public partial class ClientProject : IDbModel
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public Guid ProjectId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public virtual Client Client { get; set; }

        public virtual Project Project { get; set; }
    }
}
