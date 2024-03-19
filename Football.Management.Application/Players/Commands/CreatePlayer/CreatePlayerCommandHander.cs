using FluentResults;
using Football.Management.Application.Abstractions;
using Football.Management.Domain.Entities;
using Football.Management.Domain.Identities;
using Football.Management.Domain.Repositories;
using Football.Management.Domain.ValueObjects;

namespace Football.Management.Application.Players.Commands.CreatePlayer;

internal sealed class CreatePlayerCommandHander : ICommandHandler<CreatePlayerCommand, PlayerId>
{
    private readonly IPlayerRepository _playerRepository;

    public CreatePlayerCommandHander(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }
    
    public async Task<Result<PlayerId>> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var firstName = PlayerFirstName.Create(request.FirstName);

        if (firstName.IsFailed)
        {
            return firstName.ToResult<PlayerId>();
        }
        
        var lastName = PlayerLastName.Create(request.LastName);

        if (lastName.IsFailed)
        {
            return lastName.ToResult<PlayerId>();
        }
        
        var attackSkill = PlayerAttackSkill.Create(request.AttackSkill);

        if (attackSkill.IsFailed)
        {
            return attackSkill.ToResult<PlayerId>();
        }
        
        var midfieldSkill = PlayerMidfieldSkill.Create(request.MidfieldSkill);

        if (midfieldSkill.IsFailed)
        {
            return midfieldSkill.ToResult<PlayerId>();
        }
        
        var defenseSkill = PlayerDefenseSkill.Create(request.DefenseSkill);

        if (defenseSkill.IsFailed)
        {
            return defenseSkill.ToResult<PlayerId>();
        }

        var player = Player.Create(
            firstName.ValueOrDefault,
            lastName.ValueOrDefault,
            attackSkill.ValueOrDefault,
            midfieldSkill.ValueOrDefault,
            defenseSkill.ValueOrDefault);

        if (player.IsFailed)
        {
            return player.ToResult<PlayerId>();
        }

        await _playerRepository.AddAsync(player.Value, cancellationToken);

        return player.Value.Id;
    }
}
