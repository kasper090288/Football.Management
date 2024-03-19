using FluentResults;

namespace Football.Management.Domain.Entities;

public class LineUp
{
    private readonly List<Player> _defenders;
    private readonly List<Player> _midfielders;
    private readonly List<Player> _attackers;
    private readonly List<Player> _fieldPlayers;

    private LineUp(Player goalkeeper, List<Player> defenders, List<Player> midfielders, List<Player> attackers, List<Player> fieldPlayers)
    {
        Goalkeeper = goalkeeper;
        _defenders = defenders;
        _midfielders = midfielders;
        _attackers = attackers;
        _fieldPlayers = fieldPlayers;
    }

    public Player Goalkeeper { get; }
    public List<Player> Defenders => _defenders.ToList();
    public List<Player> Midfielders => _midfielders.ToList();
    public List<Player> Attackers => _attackers.ToList();
    public List<Player> FieldPlayers => _fieldPlayers.ToList();
    public static Result<LineUp> Create(Player goalkeeper, List<Player> defenders, List<Player> midfielders, List<Player> attackers)
    {
        if (goalkeeper is null)
        {
            return Result.Fail("Goalkeeper can not be null.");
        }

        if (defenders is null)
        {
            return Result.Fail("Defenders can not be null.");
        }

        if (midfielders is null)
        {
            return Result.Fail("Midfielders can not be null.");
        }

        if (attackers is null)
        {
            return Result.Fail("Attackers can not be null.");
        }

        if (!defenders.Any())
        {
            return Result.Fail("A lineup needs at least one defender.");
        }
        
        if (!midfielders.Any())
        {
            return Result.Fail("A lineup needs at least one midfielder.");
        }
        
        if (!attackers.Any())
        {
            return Result.Fail("A lineup needs at least one attacker.");
        }
        
        var fieldPlayers = defenders;
        fieldPlayers.AddRange(midfielders);
        fieldPlayers.AddRange(attackers);
        
        if (fieldPlayers.Count() < 10)
        {
            return Result.Fail("A lineup must not have less than 10 players.");
        }
        
        if (fieldPlayers.Count() > 10)
        {
            return Result.Fail("A lineup must not have more than 10 players.");
        }

        return new LineUp(goalkeeper, defenders, midfielders, attackers, fieldPlayers);
    }
}