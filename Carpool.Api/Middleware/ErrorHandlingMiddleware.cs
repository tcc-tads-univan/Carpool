using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Carpool.Api.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                ProblemDetails problemDetails = new ProblemDetails()
                {
                    Type = "Server Error",
                    Title = "Server Error",
                    Detail = "An internal server has occurred",
                    Status = (int)HttpStatusCode.InternalServerError
                };

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync(problemDetails);
                context.Response.ContentType = "application/json";
            }
        }
    }
}
