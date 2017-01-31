using Reporter.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Maps
{
    public partial class ClientProjectMap : EntityTypeConfiguration<ClientProject>
    {
        public ClientProjectMap()
        {
            ToTable("ClientProject");

            HasKey(e => e.Id);

            HasRequired(e => e.Client)
                .WithMany()
                .HasForeignKey(e => e.ClientId);

            HasRequired(e => e.Project)
                .WithMany()
                .HasForeignKey(e => e.ProjectId);
        }
    }
}
