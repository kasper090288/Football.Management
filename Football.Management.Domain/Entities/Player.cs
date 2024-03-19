using FluentResults;
using Football.Management.Domain.Identities;
using Football.Management.Domain.ValueObjects;

namespace Football.Management.Domain.Entities;

public class Player
{
    public PlayerId Id { get; init; }
    public PlayerFirstName FirstName { get; init; }
    public PlayerLastName LastName { get; init; }
    public PlayerDefenseSkill DefenseSkill { get; init; }
    public PlayerMidfieldSkill MidfieldSkill { get; init; }
    public PlayerAttackSkill AttackSkill { get; init; }

    private Player(PlayerId id, PlayerFirstName firstname, PlayerLastName lastname, PlayerAttackSkill attackSkill, PlayerMidfieldSkill midfieldSkill, PlayerDefenseSkill defenseSkill)
    {
        Id = id;
        FirstName = firstname;
        LastName = lastname;
        AttackSkill = attackSkill;
        MidfieldSkill = midfieldSkill;
        DefenseSkill = defenseSkill;
    }

    public static Result<Player> Create(PlayerFirstName firstname, PlayerLastName lastname, PlayerAttackSkill attackSkill, PlayerMidfieldSkill midfieldSkill, PlayerDefenseSkill defenseSkill)
    {
        if (firstname is null)
        {
            return Result.Fail($"Argument must not be null. {nameof(firstname)}");
        }

        if (lastname is null)
        {
            return Result.Fail($"Argument must not be null. {nameof(lastname)}");
        }

        if (attackSkill is null)
        {
            return Result.Fail($"Argument must not be null. {nameof(attackSkill)}");
        }

        if (midfieldSkill is null)
        {
            return Result.Fail($"Argument must not be null. {nameof(midfieldSkill)}");
        }

        if (defenseSkill is null)
        {
            return Result.Fail($"Argument must not be null. {nameof(defenseSkill)}");
        }

        return new Player(new PlayerId(Guid.NewGuid()), firstname, lastname, attackSkill, midfieldSkill, defenseSkill);
    }
}
