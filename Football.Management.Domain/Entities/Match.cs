using FluentResults;
using Football.Management.Domain.Identities;

namespace Football.Management.Domain.Entities;

public class Match
{
    public MatchId Id { get; init; }
    public MatchHalf FirstHalf { get; init; }
    public MatchHalf SecondHalf { get; init; }
    private Match(MatchId id, MatchHalf firstHalf, MatchHalf secondHalf)
    {
        Id = id;
        FirstHalf = firstHalf;
        SecondHalf = secondHalf;
    }

    public static Result<Match> Create(MatchHalf firstHalf, MatchHalf secondHalf)
    {
        if (firstHalf is null)
        {
            return Result.Fail("First half can not be null.");
        }

        if (secondHalf is null)
        {
            return Result.Fail("Second half can not be null.");
        }

        return new Match(new MatchId(Guid.NewGuid()), firstHalf, secondHalf);
    }
}
