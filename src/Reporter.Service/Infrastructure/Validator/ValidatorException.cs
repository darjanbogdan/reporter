using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Infrastructure.Validator
{
    public class ValidatorException : ArgumentException
    {
        public ValidatorException(string paramName)
            : base("Value cannot be null", paramName)
        {
        }

        public ValidatorException(IList<ValidationFailure> errors)
        {
            var data = new Dictionary<string, List<string>>();
            foreach (var error in errors)
            {
                if (!data.ContainsKey(error.PropertyName))
                {
                    data.Add(error.PropertyName, new List<string>() { error.ErrorMessage });
                }
                else
                {
                    data[error.PropertyName].Add(error.ErrorMessage);
                }
            }
            this.Data["validationMessage"] = data;
        }
    }
}
