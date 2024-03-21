namespace Football.Management.Presentation.Players.Requests;

public sealed record PlayerPostRequest(string FirstName, string LastName, int AttackSkill, int MidfieldSkill, int DefenseSkill);