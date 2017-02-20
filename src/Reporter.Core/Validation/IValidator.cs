using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Validation
{
    public interface IValidator<T> where T : IValidate
    {
        Task ValidateAsync(T parameter);
    }
}
