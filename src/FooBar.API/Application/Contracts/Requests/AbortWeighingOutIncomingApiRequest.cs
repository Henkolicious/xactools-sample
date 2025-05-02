namespace FooBar.API.Application.Contracts.Requests;

public sealed class AbortWeighingOutIncomingApiRequest : RedirectBaseRequest
{
    public required string DryerId { get; init; }
    public required string Grade { get; init; }
    public required string SequenceNumber { get; init; }
    public required string MillBatch { get; init; }
}
