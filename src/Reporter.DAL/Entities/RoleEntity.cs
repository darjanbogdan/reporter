﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.DAL.Entities
{
    public class RoleEntity : IdentityRole<Guid, UserRoleEntity>
    {
    }
}