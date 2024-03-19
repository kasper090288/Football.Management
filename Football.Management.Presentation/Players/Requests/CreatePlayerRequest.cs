namespace Football.Management.Presentation.Players.Requests;

public sealed record CreatePlayerRequest(string FirstName, string LastName, int AttackSkill, int MidfieldSkill, int DefenseSkill);