using FluentResults;
using Football.Management.Domain.Identities;
using Football.Management.Domain.ValueObjects;

namespace Football.Management.Domain.Entities;

public class Team
{
    public TeamId Id { get; init; }
    public TeamName Name { get; init; }
    private List<Player> _players;
    public List<Player> Players => [.. _players];

    private Team(TeamId id, TeamName name, List<Player> players)
    {
        Id = id;
        Name = name;
        _players = players;
    }

    public static Result<Team> Create(TeamName name, List<Player> players)
    {
        if (name is null)
        {
            return Result.Fail($"Team name cannot be null.");
        }

        if (players.Count() > 22)
        {
            return Result.Fail("A team can have no more than 22 players.");
        }

        return new Team(new TeamId(Guid.NewGuid()), name, players);
    }

    public void AddPlayer(Player player)
    {
        if (player is null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        if (_players.Count() >= 22)
        {
            throw new ArgumentException("A team can have no more than 22 players.");
        }

        _players.Add(player);
    }
}
