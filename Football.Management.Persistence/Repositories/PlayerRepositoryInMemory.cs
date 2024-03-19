using Football.Management.Domain.Entities;
using Football.Management.Domain.Identities;
using Football.Management.Domain.Repositories;
using Football.Management.Domain.ValueObjects;

namespace Football.Management.Persistence.Repositories;

public sealed class PlayerRepositoryInMemory : IPlayerRepository
{
    private List<Player> _players = new();
    
    public PlayerRepositoryInMemory()
    {
        var player = Player.Create(
            PlayerFirstName.Create("Kamil").ValueOrDefault,
            PlayerLastName.Create("Grabara").ValueOrDefault,
            PlayerAttackSkill.Create(0).ValueOrDefault,
            PlayerMidfieldSkill.Create(5).ValueOrDefault,
            PlayerDefenseSkill.Create(10).ValueOrDefault);

        _players.Add(player.Value);
    }

    public async Task AddAsync(Player player, CancellationToken cancellationToken)
    {
        var result = await GetAsync(player.Id, cancellationToken);

        if (result is not null)
        {
            return;
        }

        _players.Add(player);
    }

    public Task<Player?> GetAsync(PlayerId playerId, CancellationToken cancellationToken)
    {
        return Task.FromResult(_players.FirstOrDefault(i => i.Id.Id == playerId.Id));
    }
}