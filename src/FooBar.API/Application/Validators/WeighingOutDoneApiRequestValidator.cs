using FluentValidation;
using FooBar.API.Application.Contracts.Requests;

namespace FooBar.API.Application.Validators;

public class WeighingOutDoneApiRequestValidator : AbstractValidator<WeighingOutDoneApiRequest>
{
    public WeighingOutDoneApiRequestValidator()
    {
        RuleFor(c => c.DryerId)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(c => c.Grade)
            .NotEmpty();
        RuleFor(c => c.SequenceNumber)
            .NotEmpty();
    }
}
