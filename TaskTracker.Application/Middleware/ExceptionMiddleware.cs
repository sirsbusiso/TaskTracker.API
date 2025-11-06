
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using TaskTracker.API.Exceptions;

namespace TaskTracker.Application.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleApiExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                await HandleApiExceptionAsync(context, new ApiException(
                    500,
                    "Task Tracker API",
                    $"An unexpected error occurred: {ex.Message}"
                ));
            }
        }

        private static Task HandleApiExceptionAsync(HttpContext context, ApiException exception)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = exception.StatusCode;

            var problem = new ProblemDetails
            {
                Title = exception.Message,
                Status = exception.StatusCode,
                Detail = exception.Errors?.ToString() // optional
            };
            var jsonProblem = JsonSerializer.Serialize(problem);

            return context.Response.WriteAsync(jsonProblem);
        }
    }

}
