using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Validation
{
    public static class ValidationExceptionFactory
    {
        public static T Create<T>(object data = null)
            where T : ArgumentException, new()
        {
            var exception = new T();
            if (data != null)
            {
                exception.Data["validationMessage"] = data;
            }
            return exception;
        }
    }
}
