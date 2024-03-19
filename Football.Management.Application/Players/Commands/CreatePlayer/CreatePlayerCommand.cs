using Football.Management.Application.Abstractions;
using Football.Management.Domain.Identities;

namespace Football.Management.Application.Players.Commands.CreatePlayer;

public sealed record CreatePlayerCommand(string FirstName, string LastName, int AttackSkill, int MidfieldSkill, int DefenseSkill) : ICommand<PlayerId>;
