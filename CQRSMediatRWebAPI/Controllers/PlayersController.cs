using CQRSMediatRWebAPI.Commands;
using CQRSMediatRWebAPI.Models;
using CQRSMediatRWebAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatRWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> Get()
        {
            var query = new GetAllPlayersQuery();
            var players = await _mediator.Send(query);
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> Get(int id)
        {
            var query = new GetPlayerByIdQuery { Id = id };
            var player = await _mediator.Send(query);
            if (player == null) return NotFound();
            return Ok(player);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreatePlayerCommand command)
        {
            var playerId = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = playerId }, playerId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePlayerCommand command)
        {
            if (id != command.Id) return BadRequest("ID in URL does not match ID in request body.");
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePlayerCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
