using FluentResults;
using Football.Management.Domain.Identities;

namespace Football.Management.Domain.Repositories.Players.Errors;

public class PlayerNotFound(PlayerId PlayerId) : Error
{
    public PlayerId PlayerId { get; } = PlayerId;
}