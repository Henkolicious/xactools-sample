using FluentValidation;
using FooBar.API.Application.Contracts.Requests;

namespace FooBar.API.Application.Validators;

internal sealed class StartWeighingOutIncomingApiRequestValidator : AbstractValidator<StartWeighingOutIncomingApiRequest>
{
    public StartWeighingOutIncomingApiRequestValidator()
    {
        RuleFor(c => c.DryerId)
            .NotEmpty();
        RuleFor(c => c.Grade)
            .NotEmpty();
        RuleFor(c => c.SequenceNumber)
            .NotEmpty();
        RuleFor(c => c.HallFlowMax)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(c => c.PowderDensityNormal)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(c => c.PowderDensityMinimum)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(c => c.PowderDensistyMaximum)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(c => c.MaximumFillTime)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(c => c.MinimumFillTime)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(c => c.GranuleSizeMaximum)
            .NotEmpty();
        RuleFor(c => c.GranuleSizeMinimum)
            .NotEmpty();
        RuleFor(c => c.SamplingInterval)
            .NotEmpty();
        RuleFor(c => c.Weight)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(c => c.Comment)
            .NotEmpty();
        RuleFor(c => c.AlternativeArticleName)
            .NotEmpty();
        RuleFor(c => c.UfiCode)
            .NotEmpty();       
    }
}
