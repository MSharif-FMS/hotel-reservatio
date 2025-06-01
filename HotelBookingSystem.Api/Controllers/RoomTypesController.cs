csharp
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using HotelBookingSystem.Application.Features.RoomTypes.Queries.GetAllRoomTypes;
using HotelBookingSystem.Application.Features.RoomTypes.Queries.GetRoomTypeById;
using HotelBookingSystem.Application.Features.RoomTypes.Queries.GetRoomTypesByHotelId;
using HotelBookingSystem.Application.Features.RoomTypes.Commands.CreateRoomType;
using HotelBookingSystem.Application.Features.RoomTypes.Commands.UpdateRoomType;
using HotelBookingSystem.Application.Features.RoomTypes.Commands.DeleteRoomType;
using HotelBookingSystem.Application.DTOs.RoomType;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomTypeDto>>> GetRoomTypes()
        {
            var roomTypes = await _mediator.Send(new GetAllRoomTypesQuery());
            return Ok(roomTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomTypeDto>> GetRoomType(long id)
        {
            var roomType = await _mediator.Send(new GetRoomTypeByIdQuery { Id = id });

            if (roomType == null)
            {
                return NotFound();
            }

            return Ok(roomType);
        }

        [HttpGet("hotel/{hotelId}")]
        public async Task<ActionResult<IEnumerable<RoomTypeDto>>> GetRoomTypesByHotel(long hotelId)
        {
            var roomTypes = await _mediator.Send(new GetRoomTypesByHotelIdQuery { HotelId = hotelId });
            return Ok(roomTypes);
        }

        [HttpPost]
        public async Task<ActionResult<RoomTypeDto>> CreateRoomType([FromBody] CreateRoomTypeCommand command)
        {
            var roomType = await _mediator.Send(command);
            // Assuming the command returns the created RoomTypeDto or null if creation failed
            if (roomType == null)
            {
                return BadRequest("Could not create room type."); // Or a more specific error
            }
            return CreatedAtAction(nameof(GetRoomType), new { id = roomType.Id }, roomType);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoomType(long id, [FromBody] UpdateRoomTypeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Room type ID in the URL and body do not match.");
            }
            var success = await _mediator.Send(command);
            if (!success)
            {
                return NotFound($"Room type with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoomType(long id)
        {
            var success = await _mediator.Send(new DeleteRoomTypeCommand { Id = id });
            if (!success)
            {
                return NotFound($"Room type with ID {id} not found.");
            }
            return NoContent();
        }
    }
}