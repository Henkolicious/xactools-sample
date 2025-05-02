using FluentValidation;
using FooBar.API.Application.Contracts.Requests;

namespace FooBar.API.Application.Validators;

internal sealed class AbortWeighingOutIncomingApiRequestValidator : AbstractValidator<AbortWeighingOutIncomingApiRequest>
{
    public AbortWeighingOutIncomingApiRequestValidator()
    {
        RuleFor(c => c.DryerId)
            .NotEmpty();
        RuleFor(c => c.Grade)
            .NotEmpty();
        RuleFor(c => c.SequenceNumber)
            .NotEmpty();
        RuleFor(c => c.MillBatch)
            .NotEmpty();
    }
}
