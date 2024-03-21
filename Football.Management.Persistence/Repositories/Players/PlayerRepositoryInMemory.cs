using FluentResults;
using Football.Management.Domain.Entities;
using Football.Management.Domain.Identities;
using Football.Management.Domain.Repositories.Players;
using Football.Management.Domain.Repositories.Players.Errors;
using Football.Management.Domain.ValueObjects;

namespace Football.Management.Persistence.Repositories.Players;

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

    public async Task<Result> AddAsync(Player player, CancellationToken cancellationToken)
    {
        var playerResult = await GetAsync(player.Id, cancellationToken);

        if (playerResult.IsSuccess)
        {
            return Result.Fail(new PlayerExists(player));
        }

        _players.Add(player);

        return Result.Ok();
    }

    public Task<Result<Player>> GetAsync(PlayerId playerId, CancellationToken cancellationToken)
    {
        var player = _players.FirstOrDefault(i => i.Id.Id == playerId.Id);

        if (player is null)
        {
            return Task.FromResult(Result.Fail<Player>(new PlayerNotFound(playerId)));
        }

        return Task.FromResult(Result.Ok(player));
    }
}
