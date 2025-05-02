namespace FooBar.API.Application.Contracts.Requests;

public sealed record ReportDrumApiRequest
(
    string ScaleId,
    string Grade,
    string SequenceNumber,
    string DrumNumber,
    double Weight,
    string Marking,
    bool SampleTaken,
    double PowderDensity,
    double HallFlow,
    string LaserD10,
    string LaserD50,
    string LaserD90
);
