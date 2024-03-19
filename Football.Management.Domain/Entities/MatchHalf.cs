using FluentResults;

namespace Football.Management.Domain.Entities;

public class MatchHalf
{
    public LineUp LineUpTeamA { get; }
    public LineUp LineUpTeamB { get; }

    private MatchHalf(LineUp lineUpTeamA, LineUp lineUpTeamB)
    {
        LineUpTeamA = lineUpTeamA;
        LineUpTeamB = lineUpTeamB;
    }

    public static Result<MatchHalf> Create(LineUp lineUpTeamA, LineUp lineUpTeamB)
    {
        if (lineUpTeamA is null)
        {
            throw new ArgumentNullException(nameof(lineUpTeamA));
        }

        if (lineUpTeamB is null)
        {
            throw new ArgumentNullException(nameof(lineUpTeamB));
        }

        return new MatchHalf(lineUpTeamA, lineUpTeamB);
    }
}
