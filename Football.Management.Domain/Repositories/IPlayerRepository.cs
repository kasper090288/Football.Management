using Football.Management.Domain.Entities;
using Football.Management.Domain.Identities;

namespace Football.Management.Domain.Repositories;

public interface IPlayerRepository
{
    Task AddAsync(Player player, CancellationToken cancellationToken);
    Task<Player?> GetAsync(PlayerId playerId, CancellationToken cancellationToken);
}