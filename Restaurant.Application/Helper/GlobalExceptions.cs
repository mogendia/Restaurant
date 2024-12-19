using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Restaurant.Application.Helper
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, exception.Message);

            var details = new ProblemDetails()
            {
                Detail = $"Api Error{exception.Message}",
                Title = "Api Error",
                Status= (int) HttpStatusCode.InternalServerError,
                Type ="Server Error",
                Instance = "API"
            };
            var response = JsonSerializer.Serialize(details);
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(response,cancellationToken);
            return true;
        }
    }
}
