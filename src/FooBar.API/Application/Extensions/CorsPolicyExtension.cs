namespace FooBar.API.Application.Extensions;

public static class CorsPolicyExtensions
{
    public static IServiceCollection AddCustomCorsPolicy(this IServiceCollection services)
        => services.AddCors(c
                => c.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }));
}