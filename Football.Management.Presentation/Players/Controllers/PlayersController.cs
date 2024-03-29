using Microsoft.AspNetCore.Mvc;
using MediatR;
using Football.Management.Application.Players.Commands.CreatePlayer;
using Football.Management.Presentation.Players.Requests;
using Football.Management.Domain.Identities;
using Football.Management.Application.Players.Queries.GetPlayerById;
using Football.Management.Presentation.Players.Responses;
using Football.Management.Domain.Repositories.Players.Errors;

namespace Football.Management.Presentation.Players.Controllers;

[ApiController]
[Route("api/player")]
public sealed class PlayersController : ControllerBase
{
    private readonly ISender _sender;

    public PlayersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlayer(PlayerPostRequest request, CancellationToken cancellationToken)
    {
        var command = new CreatePlayerCommand(request.FirstName, request.LastName, request.AttackSkill, request.MidfieldSkill, request.DefenseSkill);
        var result = await _sender.Send(command, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(new { result.Errors });
    }

    [HttpGet("{playerId}")]
    public async Task<IActionResult> GetPlayerById(Guid playerId, CancellationToken cancellationToken)
    {
        var query = new GetPlayerByIdQuery(new PlayerId(playerId));
        var result = await _sender.Send(query, cancellationToken);
        if (result.IsSuccess)
        {
            var player = result.Value;
            var response = new GetPlayerByIdResponse(
                player.Id.Id,
                player.FirstName.Value,
                player.LastName.Value,
                player.AttackSkill.Value,
                player.MidfieldSkill.Value,
                player.DefenseSkill.Value);
            return Ok(response);
        }
        if (result.Errors.Select(e => e.GetType()).Contains(typeof(PlayerNotFound)))
        {
            return NoContent();
        }
        return Ok(result.Errors);
    }
}
