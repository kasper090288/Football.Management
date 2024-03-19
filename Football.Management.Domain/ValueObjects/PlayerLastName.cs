using FluentResults;

namespace Football.Management.Domain.ValueObjects;

public sealed class PlayerLastName
{
    public string Value { get; init; }

    private PlayerLastName(string value)
    {
        Value = value;
    }

    public static Result<PlayerLastName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Fail($"Player last name cannot be null or whitespace.");
        }
        
        if (value.Length > 50)
        {
            return Result.Fail("Player last name must not be greater than 50.");
        }

        return new PlayerLastName(value);
    }
}
