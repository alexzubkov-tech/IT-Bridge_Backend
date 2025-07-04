using System.ComponentModel.DataAnnotations;

using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CoreService.Application.Behaviours
{
    public class DataAnnotationValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class
    {
        private readonly IServiceProvider _serviceProvider;

        public DataAnnotationValidationBehaviour(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            // Проверяем, является ли запрос DTO
            if (request is not null)
            {
                var validator = new DataAnnotationValidator<TRequest>(_serviceProvider);
                if (!validator.TryValidate(request))
                {
                    throw new ValidationException(validator.GetModelState().ToString());
                }
            }

            return await next(cancellationToken);
        }
    }
}