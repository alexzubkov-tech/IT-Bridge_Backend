using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CoreService.Application.Behaviours
{
    public class DataAnnotationValidator<TRequest> where TRequest : class
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ModelStateDictionary _modelState;

        public DataAnnotationValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            var options = serviceProvider.GetRequiredService<IOptions<ApiBehaviorOptions>>();
            _modelState = new ModelStateDictionary();
        }

        public bool TryValidate(TRequest request)
        {
            foreach (var prop in request.GetType().GetProperties())
            {
                var attributes = prop.GetCustomAttributes(typeof(ValidationAttribute), true).Cast<ValidationAttribute>();
                foreach (var attribute in attributes)
                {
                    var value = prop.GetValue(request);
                    var isValid = attribute.IsValid(value);
                    if (!isValid)
                    {
                        _modelState.AddModelError(prop.Name, attribute.ErrorMessage ?? "Invalid value");
                    }
                }
            }

            return _modelState.IsValid;
        }

        public ModelStateDictionary GetModelState()
        {
            return _modelState;
        }
    }
}