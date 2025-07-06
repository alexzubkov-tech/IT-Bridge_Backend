using CoreService.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreService.WebApi.Filters
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationAppException validationException)
            {
                context.Result = new UnprocessableEntityObjectResult(new
                {
                    title = "One or more validation errors occurred.",
                    errors = validationException.Errors
                });

                context.ExceptionHandled = true;
            }
        }
    }
}