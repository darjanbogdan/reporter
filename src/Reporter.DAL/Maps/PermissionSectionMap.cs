using Reporter.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Maps
{
    public partial class PermissionSectionMap : EntityTypeConfiguration<PermissionSection>
    {
        public PermissionSectionMap()
        {
            ToTable("PermissionSection");

            HasKey(e => e.Id);

            Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(e => e.Abrv)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
