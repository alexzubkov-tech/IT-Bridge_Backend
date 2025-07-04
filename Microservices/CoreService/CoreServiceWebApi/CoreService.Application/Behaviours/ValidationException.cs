using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreService.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public List<ValidationResult> Errors { get; }

        public ValidationException(List<ValidationResult> errors)
            : base("One or more validation errors occurred.")
        {
            Errors = errors;
        }
    }
}