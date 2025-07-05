using CoreService.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CoreService.Infrastructure
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken ct)
        {
            httpContext.Response.ContentType = "application/json";

            switch (exception)
            {
                case ValidationAppException valEx:
                    httpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;

                    await httpContext.Response.WriteAsJsonAsync(new
                    {
                        title = "One or more validation errors occurred.",
                        errors = valEx.Errors
                    }, ct);

                    return true;

                default:
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    await httpContext.Response.WriteAsJsonAsync(new
                    {
                        title = "An unexpected error occurred.",
                        detail = exception.Message
                    }, ct);

                    return true;
            }
        }
    }
}