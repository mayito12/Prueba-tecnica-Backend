namespace Backend.Common.Errors;

public sealed record ApiErrorResponse(
    string Message,
    string TraceId,
    IDictionary<string, string[]>? Errors = null);
