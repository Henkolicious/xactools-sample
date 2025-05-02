namespace FooBar.API.Application.HttpClients.Requests;

public sealed record StartWeighingOutOutgoingRequest
(
    string DryerId,
    string Grade,
    string SequenceNumber,
    decimal HallFlowMax,
    decimal PowderDensityNormal,
    decimal PowderDensityMinimum,
    decimal PowderDensistyMaximum,
    decimal MaximumFillTime,
    decimal MinimumFillTime,
    string GranuleSizeMaximum,
    string GranuleSizeMinimum,
    string SamplingInterval,
    decimal Weight,
    string Comment,
    string AlternativeArticleName,
    string UfiCode
);