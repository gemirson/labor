using labor.Application.Mediatr.Exceptions;
using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace labor.Application.Mediatr.Validator
{
    public class ValidatorsBehavior<TRequest, TResponse>
         : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;

        public ValidatorsBehavior(IValidator<TRequest>[] validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(validator => validator.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                throw new MediatrPipelineException(
                    $"Command Validation Errors for type {typeof(TRequest).Name}",
                    new FluentValidation.ValidationException("Validation exception", failures)
                );
            }

            return await next();
        }
    }
}
