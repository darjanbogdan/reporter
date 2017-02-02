using FluentValidation.Results;
using Newtonsoft.Json.Linq;
using Reporter.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidation.Results
{
    public static class ValidationResultExtensions
    {
        public static void RaiseFormattedException(this ValidationResult validationResult)
        {
            var data = new Dictionary<string, List<string>>();
            foreach (var error in validationResult.Errors)
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
            throw ValidationExceptionFactory.Create<ArgumentException>(data);
        }
    }
}
