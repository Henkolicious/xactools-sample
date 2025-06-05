using FooBar.API.Application.Contracts.Requests;
using FooBar.API.Application.Contracts.Responses;
using FooBar.API.Application.HttpClients.Requests;
using FooBar.API.Endpoints.Filters;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace FooBar.API.Endpoints;

public static class Endpoints
{
    public static IEndpointRouteBuilder MapFooEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("api/v1");

        group
            .MapPut("/start-weighing-out", StartWeighingOutAsync)
            .Produces<MessageResponse>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
            .WithRequestValidation<RedirectBaseRequest>()
            .WithRequestValidation<StartWeighingOutIncomingApiRequest>();

        group
            .MapPut("/abort-weighing-out", AbortWeighingOutAsync)
            .Produces<MessageResponse>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
            .WithRequestValidation<RedirectBaseRequest>()
            .WithRequestValidation<AbortWeighingOutIncomingApiRequest>();

        group
            .MapPut("/weighing-out-done", WeighingOutDoneAysnc)
            .Produces<MessageResponse>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
            .WithRequestValidation<WeighingOutDoneApiRequest>();

        group
            .MapPost("/report-new-drum", ReportNewDrumAsync)
            .Produces<MessageResponse>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
            .WithRequestValidation<ReportDrumApiRequest>();

        group
            .MapGet("/error", SampleErrorAsync);

        return builder;
    }


    public static async Task<IResult> StartWeighingOutAsync(
        StartWeighingOutIncomingApiRequest request,
        CancellationToken cancellationToken)
    {
        using var client = RedirectClient(request);

        var redirectRequest = new StartWeighingOutOutgoingRequest
        (
            request.DryerReferenceId,
            request.Grade,
            request.SequenceNumber,
            request.HallFlowMax,
            request.PowderDensityNormal,
            request.PowderDensityMinimum,
            request.PowderDensityMaximum,
            request.MaximumFillTime,
            request.MinimumFillTime,
            request.GranuleSizeMaximum,
            request.GranuleSizeMinimum,
            request.SamplingInterval,
            request.Weight,
            request.Comment,
            request.AlternativeArticleName,
            request.UfiCode
        );

        Log.Information
        (
            $"Calling endpoint {request.RedirectUrl} with verb PUT and values: {{@redirectRequest}}", 
            redirectRequest
        );

        var response = await client.PutAsJsonAsync
        (
            request.RedirectUrl,
            redirectRequest,
            cancellationToken
        );

        if (response.IsSuccessStatusCode)
            Log.Information("Response: {response}", await response.Content.ReadAsStringAsync(cancellationToken));
        else
            Log.Warning(response?.ReasonPhrase ?? string.Empty);

        return Results.Ok(response);
    }

    public static async Task<IResult> AbortWeighingOutAsync(
        AbortWeighingOutIncomingApiRequest request,
        CancellationToken cancellationToken)
    {
        using var client = RedirectClient(request);

        var redirectRequest = new AbortWeighingOutOutgoingRequest
        (
            request.DryerReferenceId
        );

        Log.Information
        (
            $"Calling endpoint {request.RedirectUrl} with verb PUT and values: {{@redirectRequest}}", 
            redirectRequest
        );

        var response = await client.PutAsJsonAsync
        (
            request.RedirectUrl,
            redirectRequest,
            cancellationToken
        );

        if (response.IsSuccessStatusCode)
            Log.Information("Response: {response}", await response.Content.ReadAsStringAsync(cancellationToken));
        else
            Log.Warning(response?.ReasonPhrase ?? string.Empty);

        return Results.Ok(response);
    }

    public static async Task<IResult> WeighingOutDoneAysnc(
        WeighingOutDoneApiRequest request,
        CancellationToken cancellationToken)
        => await Task.FromResult(Results.Ok(new MessageResponse()));

    public static async Task<IResult> ReportNewDrumAsync(
        ReportDrumApiRequest request,
        CancellationToken cancellationToken)
        => await Task.FromResult(Results.Ok
        (
            new MessageResponse
            (
                $"New drum created {request.Grade}-{request.SequenceNumber}-{request.DrumNumber} " +
                $"with sample taken: {request.SampleTaken}."
            )
        ));

    private static async Task<IResult> SampleErrorAsync(HttpContext _, CancellationToken cancellationToken)
        => await Task.FromResult(MockError());

    private static IResult MockError()
        => throw new NotImplementedException("Oh noes, a mock error occured 💩");

    /// <remarks>
    /// Should be a typed client, but to keep it simple in scope it's just an inline function.
    /// </remarks>
    private static HttpClient RedirectClient(RedirectBaseRequest request)
    {
        var client = new HttpClient()
        {
            BaseAddress = new Uri(request.RedirectUrl)
        };

        foreach (var header in request.RedirectHeaders ?? [])
        {
            Log.Information($"Setting outgoing request header: {header.Key}: {header.Value}");
            client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        return client;
    }
}
