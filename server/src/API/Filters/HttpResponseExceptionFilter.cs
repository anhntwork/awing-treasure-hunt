using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Microsoft.AspNetCore.Http.Extensions;
using System.Net;

namespace API.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                var responseModel = new GlobalResponseModel
                (context.HttpContext.Request.GetDisplayUrl(),
                 null,
                 context?.Exception?.Message,
                 false,
                 HttpStatusCode.InternalServerError.GetHashCode(),
                 "");

                context.Result = new ObjectResult(responseModel)
                {
                    StatusCode = responseModel.HttpStatusCode,
                };

                context.ExceptionHandled = true;
            }

        }
    }
}
