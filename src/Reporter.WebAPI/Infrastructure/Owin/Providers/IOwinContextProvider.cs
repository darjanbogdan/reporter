using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.WebAPI.Infrastructure.Owin.Providers
{
    public interface IOwinContextProvider
    {
        IOwinContext CurrentContext { get; }
    }
}