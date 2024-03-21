using FluentResults;
using Football.Management.Domain.Entities;

namespace Football.Management.Domain.Repositories.Players.Errors;

public class PlayerExists(Player player) : Error
{
    public Player Player { get; } = player;
}