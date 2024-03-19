using FluentResults;
using Football.Management.Application.Abstractions;
using Football.Management.Domain.Entities;
using Football.Management.Domain.Repositories;

namespace Football.Management.Application.Players.Queries.GetPlayerById;

public class GetPlayerByIdQueryHandler : IQueryHandler<GetPlayerByIdQuery, Player>
{
    private readonly IPlayerRepository _playerRepository;

    public GetPlayerByIdQueryHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }
    
    public async Task<Result<Player>> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        var player = await _playerRepository.GetAsync(request.PlayerId, cancellationToken);

        if (player is null)
        {
            return Result.Fail("Player was not found.");
        }

        return player;
    }
}
