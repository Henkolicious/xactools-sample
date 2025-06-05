using FluentValidation;
using FooBar.API.Application.Contracts.Requests;

namespace FooBar.API.Application.Validators;

internal sealed class AbortWeighingOutIncomingApiRequestValidator : AbstractValidator<AbortWeighingOutIncomingApiRequest>
{
    public AbortWeighingOutIncomingApiRequestValidator()
    {
        RuleFor(c => c.DryerReferenceId)
            .NotEmpty();
    }
}
