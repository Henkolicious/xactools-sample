namespace FooBar.API.Application.Contracts.Requests;

public sealed class StartWeighingOutIncomingApiRequest : RedirectBaseRequest
{
    public required string DryerId { get; init; }
    public required string Grade { get; init; }
    public required string SequenceNumber { get; init; }
    public decimal HallFlowMax { get; init; }
    public decimal PowderDensityNormal { get; init; }
    public decimal PowderDensityMinimum { get; init; }
    public decimal PowderDensityMaximum { get; init; }
    public decimal MaximumFillTime { get; init; }
    public decimal MinimumFillTime { get; init; }
    public required string GranuleSizeMaximum { get; init; }
    public required string GranuleSizeMinimum { get; init; }
    public required string SamplingInterval { get; init; }
    public decimal Weight { get; init; }
    public required string Comment { get; init; }
    public required string AlternativeArticleName { get; init; }
    public required string UfiCode { get; init; }
};