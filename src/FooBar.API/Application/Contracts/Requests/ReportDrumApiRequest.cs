namespace FooBar.API.Application.Contracts.Requests;

public sealed record ReportDrumApiRequest
(
    Guid ProductionOrderReferenceId,
    string ScaleId,
    string Grade,
    string SequenceNumber,
    string DrumNumber,
    double Weight,
    string Marking,
    bool SampleTaken,
    double PowderDensity,
    double HallFlow
);
