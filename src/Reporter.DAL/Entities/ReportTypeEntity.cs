using Reporter.DAL.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Entities
{
    public partial class ReportTypeEntity : IEntity
    {
        public ReportTypeEntity()
        {
            Report = new HashSet<ReportEntity>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public int Order { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public virtual ICollection<ReportEntity> Report { get; set; }
    }
}
