using Reporter.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Maps
{
    [Table("Client")]
    public partial class ClientEntityMap : EntityTypeConfiguration<ClientEntity>
    {
        public ClientEntityMap()
        { 
            ToTable("Client");

            HasKey(e => e.Id);

            Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);

            HasRequired(e => e.ClientManager)
                .WithMany()
                .HasForeignKey(e => e.ClientManagerId);

            HasMany(e => e.ClientPermissionPolicies)
                .WithRequired()
                .HasForeignKey(e => e.ParentId)
                .WillCascadeOnDelete(false);

            HasMany(e => e.ClientProjects)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);
                
        }
    }
}
