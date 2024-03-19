using FluentResults;

namespace Football.Management.Domain.ValueObjects;

public sealed class PlayerFirstName
{
    public string Value { get; init; }

    private PlayerFirstName(string value)
    {
        Value = value;
    }

    public static Result<PlayerFirstName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Fail($"Player first name cannot be null or whitespace.");
        }
        
        if (value.Length > 50)
        {
            return Result.Fail("Player first name must not be greater than 50.");
        }
        
        return new PlayerFirstName(value);
    }
}