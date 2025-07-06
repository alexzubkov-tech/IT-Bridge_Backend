using System;
using System.Collections.Generic;

namespace CoreService.Application.Exceptions
{
    public class ValidationAppException : Exception
    {
        public IReadOnlyDictionary<string, string[]> Errors { get; }

        public ValidationAppException(IReadOnlyDictionary<string, string[]> errors)
            : base("One or more validation errors occurred.")
        {
            Errors = errors ?? throw new ArgumentNullException(nameof(errors));
        }
    }
}