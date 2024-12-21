using Domain.Commands.TreasureHunt;
using Domain.Queries.TreasureHunt;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Public
{
    [Route("api/public/[controller]")]
    [ApiController]
    public class TreasureHuntController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TreasureHuntController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("calculate-fuel")]
        public async Task<IActionResult> CalculateFuel([FromBody] CalculateFuelCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);
            return Ok(result);

        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var query = new GetTreasureHuntHistoryQuery();
            var results = await _mediator.Send(query);

            return Ok(results);
        }

    }
}
