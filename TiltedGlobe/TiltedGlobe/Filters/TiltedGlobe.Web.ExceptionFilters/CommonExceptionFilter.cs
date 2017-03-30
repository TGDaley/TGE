using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace TiltedGlobe.Web.ExceptionFilters
{
    public class CommonExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NotImplementedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
                return;
            }

            if (context.Exception is InvalidOperationException)
            {
                context.ActionContext.ModelState.AddModelError("Error", context.Exception.Message);
                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, context.ActionContext.ModelState);
                return;
            }

            var argumentException = context.Exception as ArgumentException;
            if (argumentException != null)
            {
                context.ActionContext.ModelState.AddModelError(argumentException.ParamName, context.Exception.Message);
                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, context.ActionContext.ModelState);
                return;
            }

            if (context.Exception is ValidationException)
            {
                context.ActionContext.ModelState.AddModelError("Error", context.Exception.Message);
                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, context.ActionContext.ModelState);
                return;
            }

            // Catch all -- an internal server error occurred!
            context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, context.Exception);
        }
    }
}
