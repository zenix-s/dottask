namespace Domain.Abstractions;

public static class ErrorCodes
{
    public const string NotFound = "NotFound";
    public const string BadRequest = "BadRequest";
    public const string Conflict = "Conflict";
    public const string Unauthorized = "Unauthorized";
    public const string Error = "Error";
}

public record Error(string Code, string? Description = null)
{
    public static readonly Error None = new Error(string.Empty);
    public static readonly Error NotFound = new Error(ErrorCodes.NotFound, "The resource was not found.");
    public static readonly Error BadRequest = new Error(ErrorCodes.BadRequest, "The request is invalid.");
    public static readonly Error Unauthorized = new Error(ErrorCodes.Unauthorized, "The request is invalid.");
    public static readonly Error InternalError = new Error(ErrorCodes.Error, "An error has occurred.");
}