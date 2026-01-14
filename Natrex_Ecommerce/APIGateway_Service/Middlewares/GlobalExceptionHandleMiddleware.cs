using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIGateway_Service.Middlewares
{
    public class GlobalExceptionHandleMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
               await _next(context);
            }
            catch (Exception ex)
            {
               await HandleException(context, ex);
            }
        }
        private async Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ProblemDetails problemDetails = new()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                //A brief, human-readable title for the error.
                Title = "Internal Server Error",
                // A detailed description of the error to help the client understand the issue.
                Detail = "An internal server error has occurred. Please try again later.",
                // A URI that provides further details about the error type (e.g., HTTP status code).
                Type = "https://httpstatus.com/500",
                // The URI of the request path that caused the error, helpig with debugging.
                Instance = context.Request.Path,
            };

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
