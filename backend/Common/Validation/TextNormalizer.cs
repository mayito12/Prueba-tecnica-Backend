namespace Backend.Common.Validation;

public static class TextNormalizer
{
    public static string Required(string value) => value.Trim();

    public static string? Optional(string? value) =>
        string.IsNullOrWhiteSpace(value) ? null : value.Trim();

    public static string ForComparison(string value) => value.Trim().ToUpperInvariant();
}
