using Reporter.Service.Infrastructure.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace Reporter.WebAPI.Infrastructure.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            if (context.Exception is ValidatorException)
            {
                statusCode = HttpStatusCode.BadRequest;

#if DEBUG
                var httpError = new HttpError(context.Exception, true);
#else
                var httpError = new HttpError(context.Exception, false);
                if (!httpError.ContainsKey("ExceptionType"))
                    httpError.Add("ExceptionType", context.Exception.GetType().FullName);
                if (!httpError.ContainsKey("ExceptionMessage"))
                    httpError.Add("ExceptionMessage", context.Exception.Message);
#endif
                foreach (var argumentName in context.Exception.Data.Keys)
                {
                    httpError.Add(argumentName.ToString(), context.Exception.Data[argumentName]);
                }
                context.Response = context.Request.CreateErrorResponse(statusCode, httpError);
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                statusCode = HttpStatusCode.Unauthorized;

#if DEBUG
                var httpError = new HttpError(context.Exception, true);
#else
                var httpError = new HttpError(context.Exception, false);
                if (!httpError.ContainsKey("ExceptionType"))
                    httpError.Add("ExceptionType", context.Exception.GetType().FullName);
                if (!httpError.ContainsKey("ExceptionMessage"))
                    httpError.Add("ExceptionMessage", context.Exception.Message);
#endif
                context.Response = context.Request.CreateErrorResponse(statusCode, httpError);
            }
        }
    }
}