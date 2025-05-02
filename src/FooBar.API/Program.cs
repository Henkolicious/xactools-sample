using System.Reflection;
using Serilog;
using Microsoft.AspNetCore.HttpLogging;
using FooBar.API.Application.Extensions;
using FooBar.API.Application.Middlewares;
using Scalar.AspNetCore;
using FooBar.API.Endpoints;

var applicationName = Assembly.GetEntryAssembly()?.GetName().Name
    ?? "Unknown application name from assembly.";

var configuration = CreateConfiguration();

try
{
    CreateLogger(applicationName, configuration);
    Log.Information($"Bootstrapping application: {applicationName}");

    var builder = WebApplication.CreateBuilder(args);
    ConfigureHost(builder);
    ConfigureServices(configuration, builder);

    var app = builder?.Build() ?? throw new Exception("Builder is null.");
    ConfigureApplication(app, applicationName);

    Log.Information($"Environment: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.");
    Log.Information($"Now running on: {Environment.GetEnvironmentVariable("ASPNETCORE_URLS")}.");

    await app.RunAsync();

    Log.Information($"Gracefully closing application: {applicationName}");

    return 0;
}
catch (Exception e)
{
    Log.Fatal(e, $"Host {applicationName} - terminated unexpectedly.", e.Message);
    return -1;
}
finally
{
    Log.CloseAndFlush();
}

static void ConfigureHost(WebApplicationBuilder builder)
{
    builder
        .Host
        .UseSerilog();
}

static void CreateLogger(string applicationName, IConfiguration configuration)
=> Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithProperty(applicationName, Guid.CreateVersion7())
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

static IConfiguration CreateConfiguration()
=> new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .AddEnvironmentVariables()
    .Build();

static void ConfigureServices(IConfiguration configuration, WebApplicationBuilder builder)
{
    builder
        .Services
        .AddCustomValidation()
        .AddCustomCorsPolicy()
        .AddCustomProblemDetails()
        .AddExceptionHandler<GlobalExceptionHandler>()
        .AddOpenApi()
        .AddSerilog()
        .AddHttpLogging(logging =>
        {
            logging.LoggingFields =
                HttpLoggingFields.RequestMethod |
                HttpLoggingFields.RequestPath |
                HttpLoggingFields.RequestQuery |
                HttpLoggingFields.RequestBody;
        });

    builder.Services.AddHealthChecks();
}

static void ConfigureApplication(WebApplication app, string applicationName)
{
    var scalarEndpointRoute = "/openapi/scalar";

    app
        .UseExceptionHandler()
        .UseHttpLogging();

    if (app.Environment.IsDevelopment())
        app.UseCors("AllowAll");

    app.MapGet("/", () => Results.Redirect(scalarEndpointRoute));
    app.MapGet("/swagger", () => Results.Redirect(scalarEndpointRoute));

    app.MapOpenApi();
    app.MapScalarApiReference(scalarEndpointRoute, options =>
    {
        options
            .WithTitle(applicationName)
            .WithTheme(ScalarTheme.Moon)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });

    app
        .UseRouting()
        .UseEndpoints(endpoints =>
        {
            endpoints.MapFooEndpoints();
            endpoints.MapHealthChecks("/health");
        });
}
