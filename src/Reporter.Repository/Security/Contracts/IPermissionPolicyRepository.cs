﻿using Reporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Repository.Security.Contracts
{
    public interface IPermissionPolicyRepository
    {
        Task<IEnumerable<PermissionPolicy>> FindAsync();
    }
}
