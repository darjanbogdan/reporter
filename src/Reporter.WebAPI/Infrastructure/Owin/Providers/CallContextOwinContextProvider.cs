using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Reporter.WebAPI.Infrastructure.Owin.Providers
{
    public class CallContextOwinContextProvider : IOwinContextProvider
    {
        public IOwinContext CurrentContext
        {
            get
            {
                return (IOwinContext)CallContext.LogicalGetData("IOwinContext");
            }
        }
    }
}