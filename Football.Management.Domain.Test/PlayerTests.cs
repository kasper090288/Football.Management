using Football.Management.Domain.Entities;
using Football.Management.Domain.ValueObjects;

namespace Football.Management.Domain.Test.Entities;

public class PlayerTests
{
    [Fact]
    public void PlayerFirstNameTest()
    {
        Assert.True(PlayerFirstName.Create(" ").IsFailed);
    }

    [Fact]
    public void PlayerLastNameTest()
    {
        Assert.True(PlayerLastName.Create(" ").IsFailed);
    }

    [Fact]
    public void PlayerAttackSkillTest()
    {
        Assert.True(PlayerAttackSkill.Create(-1).IsFailed);
        Assert.True(PlayerAttackSkill.Create(11).IsFailed);
        Assert.True(PlayerAttackSkill.Create(10).IsSuccess);
    }

    [Fact]
    public void PlayerMidfieldSkillTest()
    {
        Assert.True(PlayerMidfieldSkill.Create(-1).IsFailed);
        Assert.True(PlayerMidfieldSkill.Create(11).IsFailed);
        Assert.True(PlayerMidfieldSkill.Create(10).IsSuccess);
    }

    [Fact]
    public void PlayerDefenseSkillTest()
    {
        Assert.True(PlayerDefenseSkill.Create(-1).IsFailed);
        Assert.True(PlayerDefenseSkill.Create(11).IsFailed);
        Assert.True(PlayerDefenseSkill.Create(10).IsSuccess);
    }

    [Fact]
    public void PlayerTest()
    {
        var nullResult = PlayerFirstName.Create(" ").ValueOrDefault;
        
        var player = Player.Create(
            nullResult,
            PlayerLastName.Create("Grabara").ValueOrDefault,
            PlayerAttackSkill.Create(0).ValueOrDefault,
            PlayerMidfieldSkill.Create(5).ValueOrDefault,
            PlayerDefenseSkill.Create(10).ValueOrDefault);

        Assert.True(player.IsFailed);
        
        player = Player.Create(
            PlayerFirstName.Create("Kamil").ValueOrDefault,
            PlayerLastName.Create("Grabara").ValueOrDefault,
            PlayerAttackSkill.Create(0).ValueOrDefault,
            PlayerMidfieldSkill.Create(5).ValueOrDefault,
            PlayerDefenseSkill.Create(10).ValueOrDefault);

        Assert.True(player.ValueOrDefault?.Id.Id != Guid.Empty);
        
        player = Player.Create(
            PlayerFirstName.Create("Kamil").ValueOrDefault,
            PlayerLastName.Create("Grabara").ValueOrDefault,
            PlayerAttackSkill.Create(0).ValueOrDefault,
            PlayerMidfieldSkill.Create(5).ValueOrDefault,
            PlayerDefenseSkill.Create(10).ValueOrDefault);

        Assert.True(player.IsSuccess);
    }
}