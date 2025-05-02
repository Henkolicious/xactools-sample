namespace FooBar.API.Application.Contracts.Requests;

public abstract class RedirectBaseRequest
{
    public required string RedirectUrl { get; init; }
    public Dictionary<string, string> RedirectHeaders { get; init; } = [];
}
