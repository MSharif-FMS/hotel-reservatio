csharp
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using HotelBookingSystem.Application.Features.RatePlans.Queries.GetAllRatePlans;
using HotelBookingSystem.Application.Features.RatePlans.Queries.GetRatePlanById;
using HotelBookingSystem.Application.Features.RatePlans.Queries.GetRatePlansByHotelId;
using HotelBookingSystem.Application.Features.RatePlans.Commands.CreateRatePlan;
using HotelBookingSystem.Application.Features.RatePlans.Commands.UpdateRatePlan;
using HotelBookingSystem.Application.Features.RatePlans.Commands.DeleteRatePlan;
using HotelBookingSystem.Application.DTOs.RatePlan;


namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatePlansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RatePlansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatePlanDto>>> GetAllRatePlans()
        {
            var query = new GetAllRatePlansQuery();
            var ratePlans = await _mediator.Send(query);
            return Ok(ratePlans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RatePlanDto>> GetRatePlanById(long id)
        {
            var query = new GetRatePlanByIdQuery { Id = id };
            var ratePlan = await _mediator.Send(query);
            if (ratePlan == null)
            {
                return NotFound();
            }
            return Ok(ratePlan);
        }

        [HttpGet("hotel/{hotelId}")]
        public async Task<IActionResult> GetRatePlansByHotelId(long hotelId)
        {   
            var query = new GetRatePlansByHotelIdQuery { HotelId = hotelId };
            var ratePlans = await _mediator.Send(query);
            return Ok(ratePlans);
        }

        [HttpPost]
        public async Task<ActionResult<RatePlanDto>> CreateRatePlan([FromBody] CreateRatePlanCommand command)
        {
            var ratePlan = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRatePlanById), new { id = ratePlan.Id }, ratePlan);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRatePlan(long id, [FromBody] UpdateRatePlanCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Rate Plan ID in the URL and body do not match.");
            }
            var success = await _mediator.Send(command);
            if (!success)
            {
                return NotFound($"Rate Plan with ID {id} not found.");
            }
            return NoContent();
        }
    }
}