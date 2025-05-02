using FluentValidation;

namespace FooBar.API.Application.Extensions;

public static class ValidationExtensions
{
    public static IServiceCollection AddCustomValidation(this IServiceCollection services)
        => services.AddValidatorsFromAssemblyContaining<Program>(includeInternalTypes: true);
}