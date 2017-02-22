using Reporter.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Maps
{
    public partial class PermissionPolicyEntityMap : EntityTypeConfiguration<PermissionPolicyEntity>
    {
        public PermissionPolicyEntityMap()
        {
            ToTable("PermissionPolicy");

            HasKey(e => e.Id);
        }
    }
}
