using FluentValidation;
using FluentValidation.Results;
using MediatR.Pipeline;
using Aizen.Core.Validation.Abstraction.Exception;

namespace Aizen.Core.CQRS.Pipeline;

internal sealed class AizenValidationRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public AizenValidationRequestPreProcessor(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var errors = _validators
            .Select(validator =>
            {
                try
                {
                    return validator.Validate(request);
                }
                catch (System.Exception e)
                {

                    return new ValidationResult() { Errors = new List<ValidationFailure> { new ValidationFailure("", e.Message) } };

                }
            })
            .SelectMany(validationResult => validationResult.Errors)
            .Where(error => error != null)
            .ToList();

        errors.AddRange(_validators
            .Select(async validator =>
            {
                try
                {
                    return await validator.ValidateAsync(request, cancellationToken);
                }
                catch (System.Exception e)
                {
                    return new ValidationResult() { Errors = new List<ValidationFailure> { new ValidationFailure("", e.Message) } };
                }
            })
            .SelectMany(validationResult => validationResult.Result.Errors)
            .Where(error => error != null)
            .ToList());

        if (errors.Any())
        {
            string result = string.Empty;
            if (errors.Count > 1)
            {
                result = String.Join(",", errors.Select(x => x.ErrorMessage).Distinct().ToArray());
            }
            else
            {
                result = errors.First().ErrorMessage;
            }

            throw new AizenValidationException(result);
        }

        return Task.CompletedTask;
    }
}