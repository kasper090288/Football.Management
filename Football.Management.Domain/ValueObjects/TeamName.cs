using FluentResults;

namespace Football.Management.Domain.ValueObjects;

public sealed class TeamName
{
    public string Value { get; init; }

    private TeamName(string value)
    {
        Value = value;
    }

    public static Result<TeamName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Fail("Team name cannot be null or whitespace.");
        }

        if (value.Length > 50)
        {
            return Result.Fail("Team name must not be greater than 50.");
        }

        return new TeamName(value);
    }
}