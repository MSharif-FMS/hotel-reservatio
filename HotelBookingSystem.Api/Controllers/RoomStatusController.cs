csharp
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Application.Features.RoomStatus.Queries.GetRoomStatusHistory;
using HotelBookingSystem.Application.Features.RoomStatus.Queries.GetCurrentRoomStatus;
using HotelBookingSystem.Application.Features.RoomStatus.Commands.AddRoomStatus;
using MediatR;

namespace HotelBookingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{roomId}/current")]
        public async Task<ActionResult<RoomStatusDto>> GetCurrentRoomStatus(long roomId)
        {
            var query = new GetCurrentRoomStatusQuery { RoomId = roomId };
            var roomStatus = await _mediator.Send(query);

            if (roomStatus == null)
            {
                return NotFound();
            }

            return Ok(roomStatus);
        }

        [HttpGet("{roomId}/history")]
        public async Task<ActionResult<IEnumerable<RoomStatusDto>>> GetRoomStatusHistory(long roomId)
        {
            var query = new GetRoomStatusHistoryQuery { RoomId = roomId };
            var history = await _mediator.Send(query);

            return Ok(history);
        }

        [HttpPost]
        public async Task<ActionResult<RoomStatusDto>> AddRoomStatus([FromBody] AddRoomStatusCommand command)
        {
            var roomStatus = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCurrentRoomStatus), new { roomId = roomStatus.RoomId }, roomStatus);
        }
    }
}