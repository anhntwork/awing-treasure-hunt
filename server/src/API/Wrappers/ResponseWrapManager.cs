using Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.AspNetCore.Http.Extensions;
using Domain.Constants;

namespace API.Helpers
{
    public static class ResponseWrapManager
    {
        /// <summary>
        /// The Response Wrapper method handles customizations and generate Formatted Response.
        /// </summary>
        /// <param name="result">The Result</param>
        /// <param name="context">The HTTP Context</param>
        /// <param name="exception">The Exception</param>
        /// <returns>Sample Response Object</returns>
        public static GlobalResponseModel ResponseWrapper(object? result, HttpContext context, object? exception = null)
        {
            var requestUrl = context.Request.GetDisplayUrl();
            var data = result;
            var error = exception != null ? ServiceConstants.ExceptionWrapperMessage : null;
            var status = result != null;
            var httpStatusCode = (HttpStatusCode)context.Response.StatusCode;

            // NOTE: Add any further customizations if needed here

            return new GlobalResponseModel(requestUrl, data, error, status, httpStatusCode.GetHashCode(), null);
        }
    }
}
