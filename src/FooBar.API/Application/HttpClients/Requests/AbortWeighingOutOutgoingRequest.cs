namespace FooBar.API.Application.HttpClients.Requests;

public sealed record AbortWeighingOutOutgoingRequest
(
    string DryerId,
    string Grade,
    string SequenceNumber,
    string MillBatch
);
