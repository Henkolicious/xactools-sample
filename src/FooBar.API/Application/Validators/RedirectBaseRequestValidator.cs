using FluentValidation;
using FooBar.API.Application.Contracts.Requests;

namespace FooBar.API.Application.Validators;

internal sealed class RedirectBaseRequestValidator : AbstractValidator<RedirectBaseRequest>
{
    public RedirectBaseRequestValidator()
    {
        RuleFor(c => c.RedirectUrl)
            .NotEmpty()
            .WithMessage("Redirect URL cannot be empty.");

        RuleFor(c => c.RedirectUrl)
           .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
           .WithMessage("Redirect URL must be a valid absolute URI.");
    }
}
