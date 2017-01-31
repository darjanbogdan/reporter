using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Models
{
    public partial class ReportType
    {
        public ReportType()
        {
            Report = new HashSet<Report>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public int Order { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public virtual ICollection<Report> Report { get; set; }
    }
}
