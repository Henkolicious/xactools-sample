using FluentValidation;
using FooBar.API.Application.Contracts.Requests;

namespace FooBar.API.Application.Validators;

internal sealed class ReportDrumRequestValidator : AbstractValidator<ReportDrumApiRequest>
{
	public ReportDrumRequestValidator()
	{
		RuleFor(c => c.ScaleId)
			.NotEmpty();
		RuleFor(c => c.Grade)
            .NotEmpty();
        RuleFor(c => c.SequenceNumber)
            .NotEmpty();
        RuleFor(c => c.DrumNumber)
            .NotEmpty();
        RuleFor(c => c.Weight)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(c => c.Marking)
            .NotEmpty();
        RuleFor(c => c.SampleTaken)
            .NotEmpty();
        RuleFor(c => c.PowderDensity)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(c => c.HallFlow)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(c => c.LaserD10)
            .NotEmpty();
        RuleFor(c => c.LaserD50)
            .NotEmpty();
        RuleFor(c => c.LaserD90)
            .NotEmpty();
    }
}
