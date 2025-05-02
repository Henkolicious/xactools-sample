namespace FooBar.API.Application.Contracts.Requests;

public sealed record WeighingOutDoneApiRequest
(
    int DryerId,
    string Grade,
    string SequenceNumber
);