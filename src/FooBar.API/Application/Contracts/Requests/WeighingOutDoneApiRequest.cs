namespace FooBar.API.Application.Contracts.Requests;

public sealed record WeighingOutDoneApiRequest
(
    Guid ProductionOrderReferenceId
);