csharp
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelBookingSystem.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger; // Placeholder for logger

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger; // Placeholder for logger
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception (placeholder)
                _logger.LogError(ex, "An unhandled exception occurred.");

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var statusCode = HttpStatusCode.InternalServerError; // Default to 500 Internal Server Error
            var message = "An internal server error occurred.";
            var details = exception.Message;

            switch (exception)
            {
                case InvalidOperationException invalidOperationException:
                    statusCode = HttpStatusCode.BadRequest; // 400 Bad Request
                    message = "Bad request.";
                    details = invalidOperationException.Message;
                    break;
                // Add more specific exception handling here, e.g., for NotFoundException, ValidationException
                // case NotFoundException notFoundException:
                //     statusCode = HttpStatusCode.NotFound; // 404 Not Found
                //     message = "Resource not found.";
                //     details = notFoundException.Message;
                //     break;
                // case FluentValidation.ValidationException validationException:
                //     statusCode = HttpStatusCode.BadRequest; // 400 Bad Request
                //     message = "Validation failed.";
                //     details = JsonSerializer.Serialize(validationException.Errors); // Serialize validation errors
                //     break;
                default:
                    // For other exceptions, keep the default 500 status and message
                    break;
            }

            context.Response.StatusCode = (int)statusCode;

            var errorResponse = new
            {
                StatusCode = (int)statusCode,
                Message = message,
                Details = details
            };

            var jsonErrorResponse = JsonSerializer.Serialize(errorResponse);
            return context.Response.WriteAsync(jsonErrorResponse);
        }
    }
}