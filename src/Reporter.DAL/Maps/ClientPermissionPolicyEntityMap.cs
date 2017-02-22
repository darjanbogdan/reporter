using Reporter.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Maps
{
    public partial class ClientPermissionPolicyEntityMap : EntityTypeConfiguration<ClientPermissionPolicyEntity>
    {
        public ClientPermissionPolicyEntityMap()
        {
            ToTable("ClientPermissionPolicy");

            HasKey(e => e.Id);
        }
    }
}
