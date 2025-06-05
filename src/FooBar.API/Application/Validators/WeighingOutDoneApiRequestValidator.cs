using FluentValidation;
using FooBar.API.Application.Contracts.Requests;

namespace FooBar.API.Application.Validators;

public class WeighingOutDoneApiRequestValidator : AbstractValidator<WeighingOutDoneApiRequest>
{
    public WeighingOutDoneApiRequestValidator()
    {
        RuleFor(c => c.ProductionOrderReferenceId)
            .NotEmpty();
    }
}
