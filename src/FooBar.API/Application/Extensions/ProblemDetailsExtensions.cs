namespace FooBar.API.Application.Extensions;

public static class ProblemDetailsExtensions
{
    public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services)
        => services.AddProblemDetails();
}
