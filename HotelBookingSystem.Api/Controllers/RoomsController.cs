csharp
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using HotelBookingSystem.Application.Features.Rooms.Queries.GetAllRooms;
using HotelBookingSystem.Application.Features.Rooms.Queries.GetRoomById;
using HotelBookingSystem.Application.Features.Rooms.Queries.GetRoomsByHotelId;
using HotelBookingSystem.Application.Features.Rooms.Queries.GetRoomsByHotelIdAndRoomTypeId;
using HotelBookingSystem.Application.Features.Rooms.Commands;
using HotelBookingSystem.Application.Features.Rooms.Commands.CreateRoom;
using HotelBookingSystem.Application.Features.Rooms.Commands.UpdateRoom;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    { 
        private readonly IMediator _mediator;

        public RoomsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var query = new GetAllRoomsQuery();
            var rooms = await _mediator.Send(query);
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(long id)
        {
            var query = new GetRoomByIdQuery { Id = id };
            var room = await _mediator.Send(query);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpGet("hotel/{hotelId}")]
        public async Task<IActionResult> GetRoomsByHotel(long hotelId)
        {
            var query = new GetRoomsByHotelIdQuery { HotelId = hotelId };
            var rooms = await _mediator.Send(query);
            return Ok(rooms);
        }

        [HttpGet("hotel/{hotelId}/roomtype/{roomTypeId}")]
        public async Task<IActionResult> GetRoomsByHotelAndRoomType(long hotelId, long roomTypeId)
        {
            var query = new GetRoomsByHotelIdAndRoomTypeIdQuery { HotelId = hotelId, RoomTypeId = roomTypeId };
            var rooms = await _mediator.Send(query);
            return Ok(rooms);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomCommand command)
        {
            var roomId = await _mediator.Send(command);
            // Assuming successful creation returns the ID of the new room
            return CreatedAtAction(nameof(GetRoomById), new { id = roomId }, new { Id = roomId });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(long id, [FromBody] UpdateRoomCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Room ID in the URL and body do not match.");
            }
            var success = await _mediator.Send(command);
            if (!success)
            {
                return NotFound($"Room with ID {id} not found or update failed.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(long id)
        {
            var success = await _mediator.Send(new DeleteRoomCommand { RoomId = id });
            if (!success)
            {
                return NotFound($"Room with ID {id} not found or deletion failed.");
            }
            return NoContent();
        }
    }
}