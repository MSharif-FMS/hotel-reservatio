csharp
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using HotelBookingSystem.Application.Features.RoomPricing.Queries.GetAllRoomPricing;
using HotelBookingSystem.Application.Features.RoomPricing.Queries.GetRoomPricingById;
using HotelBookingSystem.Application.Features.RoomPricing.Queries.GetRoomPricingByRoomTypeIdAndDateRange;
using HotelBookingSystem.Application.Features.RoomPricing.Queries.GetRoomPricingByRatePlanIdAndDateRange;
using HotelBookingSystem.Application.Features.RoomPricing.Commands.CreateRoomPricing;
using HotelBookingSystem.Application.Features.RoomPricing.Commands.UpdateRoomPricing;
using HotelBookingSystem.Application.Features.RoomPricing.Commands.DeleteRoomPricing;
using HotelBookingSystem.Application.DTOs.RoomPricing; // Assuming a RoomPricingDto exists

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomPricingController : ControllerBase
    {   
        private readonly IMediator _mediator;

        public RoomPricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomPricingDto>>> GetRoomPricingEntries()
        {
            var roomPricingEntries = await _mediator.Send(new GetAllRoomPricingQuery());
            return Ok(roomPricingEntries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomPricingDto>> GetRoomPricingEntry(long id)
        {
            var roomPricingEntry = await _mediator.Send(new GetRoomPricingByIdQuery { Id = id });

            if (roomPricingEntry == null)
            {
                return NotFound();
            }
            return Ok(roomPricingEntry);
        }

        [HttpGet("roomType/{roomTypeId}/dateRange")]
        public async Task<ActionResult<IEnumerable<RoomPricingDto>>> GetRoomPricingByRoomTypeAndDateRange(long roomTypeId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var roomPricingEntries = await _mediator.Send(new GetRoomPricingByRoomTypeIdAndDateRangeQuery { RoomTypeId = roomTypeId, StartDate = startDate, EndDate = endDate });
            return Ok(roomPricingEntries);
        }

        [HttpGet("ratePlan/{ratePlanId}/dateRange")]
        public async Task<ActionResult<IEnumerable<RoomPricingDto>>> GetRoomPricingByRatePlanAndDateRange(long ratePlanId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var roomPricingEntries = await _mediator.Send(new GetRoomPricingByRatePlanIdAndDateRangeQuery { RatePlanId = ratePlanId, StartDate = startDate, EndDate = endDate });
            return Ok(roomPricingEntries);
        }

        [HttpPost]
        public async Task<ActionResult<RoomPricingDto>> CreateRoomPricing([FromBody] CreateRoomPricingCommand command)
        {
            var roomPricing = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRoomPricingEntry), new { id = roomPricing.Id }, roomPricing);
        }

        [HttpPut(\"{id}\")]
        public async Task<ActionResult> UpdateRoomPricing(long id, [FromBody] UpdateRoomPricingCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(\"Room Pricing ID in the URL and body do not match.\");
            }
            var success = await _mediator.Send(command);
            if (!success)
            {
                return NotFound($\"Room Pricing with ID {id} not found or update failed.\");
            }
            return NoContent();
        }

        [HttpDelete(\"{id}\")]
        public async Task<ActionResult> DeleteRoomPricing(long id)
        {
            var success = await _mediator.Send(new DeleteRoomPricingCommand { Id = id });
            if (!success)
            {
                return NotFound($\"Room Pricing with ID {id} not found or deletion failed.\");
            }
            return NoContent();
        }

        // Add other CRUD endpoints (POST, PUT, DELETE) as needed
    }
}