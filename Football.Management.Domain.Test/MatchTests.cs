using Football.Management.Domain.Entities;
using Football.Management.Domain.ValueObjects;

namespace Football.Management.Domain.Test.Entities;

public class MatchTests
{
    [Fact]
    public void Test()
    {
        var teamFckPlayerGk = Player.Create(PlayerFirstName.Create("Kamil").Value, PlayerLastName.Create("Grabara").Value, PlayerAttackSkill.Create(0).Value, PlayerMidfieldSkill.Create(5).Value, PlayerDefenseSkill.Create(10).Value).Value;
        var teamFckPlayerDef1 = Player.Create(PlayerFirstName.Create("Nicolai").Value, PlayerLastName.Create("Boilesen").Value, PlayerAttackSkill.Create(5).Value, PlayerMidfieldSkill.Create(5).Value, PlayerDefenseSkill.Create(10).Value).Value;
        var teamFckPlayerDef2 = Player.Create(PlayerFirstName.Create("Scott").Value, PlayerLastName.Create("McKenna").Value, PlayerAttackSkill.Create(5).Value, PlayerMidfieldSkill.Create(5).Value, PlayerDefenseSkill.Create(10).Value).Value;
        var teamFckPlayerDef3 = Player.Create(PlayerFirstName.Create("Denis").Value, PlayerLastName.Create("Vavro").Value, PlayerAttackSkill.Create(5).Value, PlayerMidfieldSkill.Create(5).Value, PlayerDefenseSkill.Create(10).Value).Value;
        var teamFckPlayerDef4 = Player.Create(PlayerFirstName.Create("Kevin").Value, PlayerLastName.Create("Diks").Value, PlayerAttackSkill.Create(5).Value, PlayerMidfieldSkill.Create(5).Value, PlayerDefenseSkill.Create(10).Value).Value;
        var teamFckPlayerMid1 = Player.Create(PlayerFirstName.Create("Rasmus").Value, PlayerLastName.Create("Falk").Value, PlayerAttackSkill.Create(5).Value, PlayerMidfieldSkill.Create(10).Value, PlayerDefenseSkill.Create(5).Value).Value;
        var teamFckPlayerMid2 = Player.Create(PlayerFirstName.Create("Viktor").Value, PlayerLastName.Create("Claesson").Value, PlayerAttackSkill.Create(5).Value, PlayerMidfieldSkill.Create(10).Value, PlayerDefenseSkill.Create(5).Value).Value;
        var teamFckPlayerMid3 = Player.Create(PlayerFirstName.Create("Diogo").Value, PlayerLastName.Create("Goncalves").Value, PlayerAttackSkill.Create(5).Value, PlayerMidfieldSkill.Create(10).Value, PlayerDefenseSkill.Create(5).Value).Value;
        var teamFckPlayerAtt1 = Player.Create(PlayerFirstName.Create("Andreas").Value, PlayerLastName.Create("Cornelius").Value, PlayerAttackSkill.Create(10).Value, PlayerMidfieldSkill.Create(5).Value, PlayerDefenseSkill.Create(0).Value).Value;
        var teamFckPlayerAtt2 = Player.Create(PlayerFirstName.Create("Mohamed").Value, PlayerLastName.Create("Elyounoussi").Value, PlayerAttackSkill.Create(10).Value, PlayerMidfieldSkill.Create(5).Value, PlayerDefenseSkill.Create(0).Value).Value;
        var teamFckPlayerAtt3 = Player.Create(PlayerFirstName.Create("Roony").Value, PlayerLastName.Create("Bardghji").Value, PlayerAttackSkill.Create(10).Value, PlayerMidfieldSkill.Create(5).Value, PlayerDefenseSkill.Create(0).Value).Value;
        
        var teamBifPlayerGk = Player.Create(PlayerFirstName.Create("Patrick").Value, PlayerLastName.Create("Pentz").Value, PlayerAttackSkill.Create(0).Value, PlayerMidfieldSkill.Create(5).Value, PlayerDefenseSkill.Create(10).Value).Value;
        var teamBifPlayerDef1 = Player.Create(PlayerFirstName.Create("Jacob").Value, PlayerLastName.Create("Rasmussen").Value, PlayerAttackSkill.Create(5).Value, PlayerMidfieldSkill.Create(5).Value, PlayerDefenseSkill.Create(10).Value).Value;
        var teamBifPlayerDef2 = Player.Create(PlayerFirstName.Create("Frederik").Value, PlayerLastName.Create("Alves").Value, PlayerAttackSkill.Create(5).Value, PlayerMidfieldSkill.Create(5).Value, PlayerDefenseSkill.Create(10).Value).Value;
        var teamBifPlayerDef3 = Player.Create(PlayerFirstName.Create("Rasmus").Value, PlayerLastName.Create("Lauritsen").Value, PlayerAttackSkill.Create(5).Value, PlayerMidfieldSkill.Create(5).Value, PlayerDefenseSkill.Create(10).Value).Value;
        var teamBifPlayerDef4 = Player.Create(PlayerFirstName.Create("Kevin").Value, PlayerLastName.Create("Tshiembe").Value, PlayerAttackSkill.Create(5).Value, PlayerMidfieldSkill.Create(5).Value, PlayerDefenseSkill.Create(10).Value).Value;
        var teamBifPlayerMid1 = Player.Create(PlayerFirstName.Create("Daniel").Value, PlayerLastName.Create("Wass").Value, PlayerAttackSkill.Create(5).Value, PlayerMidfieldSkill.Create(10).Value, PlayerDefenseSkill.Create(5).Value).Value;
        var teamBifPlayerMid2 = Player.Create(PlayerFirstName.Create("Josip").Value, PlayerLastName.Create("Radosevic").Value, PlayerAttackSkill.Create(5).Value, PlayerMidfieldSkill.Create(10).Value, PlayerDefenseSkill.Create(5).Value).Value;
        var teamBifPlayerMid3 = Player.Create(PlayerFirstName.Create("Nicolai").Value, PlayerLastName.Create("Vallys").Value, PlayerAttackSkill.Create(5).Value, PlayerMidfieldSkill.Create(10).Value, PlayerDefenseSkill.Create(5).Value).Value;
        var teamBifPlayerAtt1 = Player.Create(PlayerFirstName.Create("Mathias").Value, PlayerLastName.Create("Kvistgaarden").Value, PlayerAttackSkill.Create(10).Value, PlayerMidfieldSkill.Create(5).Value, PlayerDefenseSkill.Create(0).Value).Value;
        var teamBifPlayerAtt2 = Player.Create(PlayerFirstName.Create("Ohi").Value, PlayerLastName.Create("Omoijuanfo").Value, PlayerAttackSkill.Create(10).Value, PlayerMidfieldSkill.Create(5).Value, PlayerDefenseSkill.Create(0).Value).Value;
        var teamBifPlayerAtt3 = Player.Create(PlayerFirstName.Create("Filip").Value, PlayerLastName.Create("Bundgaard").Value, PlayerAttackSkill.Create(10).Value, PlayerMidfieldSkill.Create(5).Value, PlayerDefenseSkill.Create(0).Value).Value;
        
        var teamFck = Team.Create(TeamName.Create("FCK").Value, []).Value;
        var teamBif = Team.Create(TeamName.Create("BIF").Value, []).Value;

        List<Player> fckDefenders = [teamFckPlayerDef1, teamFckPlayerDef2, teamFckPlayerDef3, teamFckPlayerDef4];
        List<Player> fckMidfielders = [teamFckPlayerMid1, teamFckPlayerMid2, teamFckPlayerMid3];
        List<Player> fckAttackers = [teamFckPlayerAtt1, teamFckPlayerAtt2, teamFckPlayerAtt3];

        List<Player> bifDefenders = [teamBifPlayerDef1, teamBifPlayerDef2, teamBifPlayerDef3, teamBifPlayerDef4];
        List<Player> bifMidfielders = [teamBifPlayerMid1, teamBifPlayerMid2, teamBifPlayerMid3];
        List<Player> bifAttackers = [teamBifPlayerAtt1, teamBifPlayerAtt2, teamBifPlayerAtt3];
        
        var fckLineUp = LineUp.Create(teamFckPlayerGk, fckDefenders, fckMidfielders, fckAttackers).Value;
        var bifLineUp = LineUp.Create(teamBifPlayerGk, bifDefenders, bifMidfielders, bifAttackers).Value;

        var firstMatchHalf = MatchHalf.Create(fckLineUp, bifLineUp).Value;
        var secondMatchHalf = MatchHalf.Create(fckLineUp, bifLineUp).Value;

        var match = Match.Create(firstMatchHalf, secondMatchHalf);

        Assert.True(match.IsSuccess);
    }
}