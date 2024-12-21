using Domain.Commands.TreasureHunt;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Public
{
    [Route("api/public/[controller]")]
    [ApiController]
    public class TreasureHuntController : ControllerBase
    {
        private readonly IMediator mediator;

        public TreasureHuntController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("calculate-fuel")]
        public async Task<IActionResult> CalculateFuel([FromBody] CalculateFuelCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
