using Reporter.DAL.Models;
using Reporter.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Maps
{
    public partial class ClientPermissionPolicyMap : EntityTypeConfiguration<ClientPermissionPolicy>
    {
        public ClientPermissionPolicyMap()
        {
            ToTable("ClientPermissionPolicy");

            HasKey(e => e.Id);
        }
    }
}
