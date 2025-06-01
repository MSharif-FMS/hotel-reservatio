csharp
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using HotelBookingSystem.Application.Features.Rooms.Queries.GetAllRooms;
using HotelBookingSystem.Application.Features.Rooms.Queries.GetRoomById;
using HotelBookingSystem.Application.Features.Rooms.Queries.GetRoomsByHotelId;
using HotelBookingSystem.Application.Features.Rooms.Queries.GetRoomsByHotelIdAndRoomTypeId;

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
    }
}