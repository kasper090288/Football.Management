using FluentResults;

namespace Football.Management.Domain.ValueObjects;

public record PlayerMidfieldSkill
{
    public int Value { get; init; }

    private PlayerMidfieldSkill(int value)
    {
        Value = value;
    }

    public static Result<PlayerMidfieldSkill> Create(int value)
    {
        if (value > 10) return Result.Fail("Player attack skill must be less than 10.");
        if (value < 0) return Result.Fail("Player attack skill must not be negative.");
        return new PlayerMidfieldSkill(value);
    }
}
