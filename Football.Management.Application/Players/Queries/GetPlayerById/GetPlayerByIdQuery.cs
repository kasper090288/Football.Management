using Football.Management.Application.Abstractions;
using Football.Management.Domain.Entities;
using Football.Management.Domain.Identities;

namespace Football.Management.Application.Players.Queries.GetPlayerById;

public sealed record GetPlayerByIdQuery(PlayerId PlayerId) : IQuery<Player>;
