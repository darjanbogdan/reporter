﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.DAL.Models.Identity
{
    public class ApplicationUserClaim : IdentityUserClaim<Guid>
    {
    }
}