﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Context
{
    public interface IApplicationContext
    {
        IUserInfo UserInfo { get; }
    }
}
