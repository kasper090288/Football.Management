using FluentResults;
using Football.Management.Application.Abstractions;
using Football.Management.Domain.Entities;
using Football.Management.Domain.Repositories.Players;

namespace Football.Management.Application.Players.Queries.GetPlayerById;

public class GetPlayerByIdQueryHandler : IQueryHandler<GetPlayerByIdQuery, Player>
{
    private readonly IPlayerRepository _playerRepository;

    public GetPlayerByIdQueryHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }
    
    public Task<Result<Player>> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        return _playerRepository.GetAsync(request.PlayerId, cancellationToken);
    }
}
