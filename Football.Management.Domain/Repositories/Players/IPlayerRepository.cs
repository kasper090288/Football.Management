using FluentResults;
using Football.Management.Domain.Entities;
using Football.Management.Domain.Identities;

namespace Football.Management.Domain.Repositories.Players;

public interface IPlayerRepository
{
    Task<Result> AddAsync(Player player, CancellationToken cancellationToken);
    Task<Result<Player>> GetAsync(PlayerId playerId, CancellationToken cancellationToken);
}