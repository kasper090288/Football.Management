using FluentResults;
using Football.Management.Application.Abstractions;
using Football.Management.Domain.Entities;
using Football.Management.Domain.Identities;
using Football.Management.Domain.Repositories.Players;
using Football.Management.Domain.ValueObjects;

namespace Football.Management.Application.Players.Commands.CreatePlayer;

internal sealed class CreatePlayerCommandHander : ICommandHandler<CreatePlayerCommand, PlayerId>
{
    private readonly IPlayerRepository _playerRepository;

    public CreatePlayerCommandHander(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }
    
    public Task<Result<PlayerId>> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var firstName = PlayerFirstName.Create(request.FirstName);

        if (firstName.IsFailed)
        {
            return Task.FromResult(firstName.ToResult<PlayerId>());
        }
        
        var lastName = PlayerLastName.Create(request.LastName);

        if (lastName.IsFailed)
        {
            return Task.FromResult(lastName.ToResult<PlayerId>());
        }
        
        var attackSkill = PlayerAttackSkill.Create(request.AttackSkill);

        if (attackSkill.IsFailed)
        {
            return Task.FromResult(attackSkill.ToResult<PlayerId>());
        }
        
        var midfieldSkill = PlayerMidfieldSkill.Create(request.MidfieldSkill);

        if (midfieldSkill.IsFailed)
        {
            return Task.FromResult(midfieldSkill.ToResult<PlayerId>());
        }
        
        var defenseSkill = PlayerDefenseSkill.Create(request.DefenseSkill);

        if (defenseSkill.IsFailed)
        {
            return Task.FromResult(defenseSkill.ToResult<PlayerId>());
        }

        var player = Player.Create(
            firstName.ValueOrDefault,
            lastName.ValueOrDefault,
            attackSkill.ValueOrDefault,
            midfieldSkill.ValueOrDefault,
            defenseSkill.ValueOrDefault);

        if (player.IsFailed)
        {
            return Task.FromResult(player.ToResult<PlayerId>());
        }

        return _playerRepository
            .AddAsync(player.Value, cancellationToken)
            .ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    return Result.Fail<PlayerId>("Task has failed.");
                }
                
                if (t.Result.IsFailed)
                {
                    return t.Result.ToResult<PlayerId>();
                }

                return Result.Ok(player.Value.Id);
            });
    }
}
