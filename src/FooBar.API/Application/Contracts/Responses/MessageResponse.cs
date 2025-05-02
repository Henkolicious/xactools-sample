namespace FooBar.API.Application.Contracts.Responses;

public sealed record MessageResponse
(
    string Message = $"Woho, some successful message response 🍻"
);
