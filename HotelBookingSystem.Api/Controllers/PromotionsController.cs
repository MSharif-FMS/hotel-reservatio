csharp
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using HotelBookingSystem.Application.Features.Promotions.Queries;
using System.Collections.Generic;
using HotelBookingSystem.Application.Features.Promotions.Commands;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PromotionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromotion([FromBody] CreatePromotionCommand command)
        {
            var promotionId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetPromotionById), new { id = promotionId }, promotionId);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromotionDto>>> GetAllPromotions()
        {
            var promotions = await _mediator.Send(new GetAllPromotionsQuery());
            return Ok(promotions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionDto>> GetPromotionById(long id)
        {
            var promotion = await _mediator.Send(new GetPromotionByIdQuery { Id = id });

            if (promotion == null)
            {
                return NotFound();
            }
            return Ok(promotion);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<PromotionDto>>> GetActivePromotions()
        {
            var activePromotions = await _mediator.Send(new GetActivePromotionsQuery());
            return Ok(activePromotions);
        }

        [HttpGet("code/{code}")]
        public async Task<ActionResult<PromotionDto>> GetPromotionByCode(string code)
        {
            var promotion = await _mediator.Send(new GetPromotionByCodeQuery { Code = code });

            if (promotion == null)
            {
                return NotFound();
            }
            return Ok(promotion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePromotion(long id, [FromBody] UpdatePromotionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Route ID and command ID must match.");
            }

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotion(long id)
        {
            var result = await _mediator.Send(new DeletePromotionCommand { Id = id });

            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}