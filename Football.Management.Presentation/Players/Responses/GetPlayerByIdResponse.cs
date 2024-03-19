namespace Football.Management.Presentation.Players.Responses;

public sealed record GetPlayerByIdResponse(Guid Id, string FirstName, string LastName, int AttackSkill, int MidfieldSkill, int DefenseSkill);
