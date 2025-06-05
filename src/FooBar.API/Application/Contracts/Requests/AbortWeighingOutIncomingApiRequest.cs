namespace FooBar.API.Application.Contracts.Requests;

public sealed class AbortWeighingOutIncomingApiRequest : RedirectBaseRequest
{
    public required Guid DryerReferenceId { get; init; }
}
