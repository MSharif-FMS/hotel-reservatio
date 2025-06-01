csharp
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Features.RoomServices.Commands.CreateRoomService;
using HotelBookingSystem.Application.Features.RoomServices.Queries.GetRoomServiceById;
using HotelBookingSystem.Application.Features.RoomServices.Queries.GetRoomServicesForReservationRoom;
using MediatR; // Assuming you will use MediatR

namespace HotelBookingSystem.Api.Controllers
{
    [Route("api/reservationrooms/{reservationRoomId}/roomservices")]
    [ApiController]
    public class RoomServicesController : ControllerBase
    {
        private readonly IMediator _mediator; // Using MediatR

        public RoomServicesController(IMediator mediator) // Inject IMediator
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new room service request for a reservation room.
        /// </summary>
        /// <param name="reservationRoomId">The ID of the reservation room.</param>
        /// <param name="command">The command containing the room service request details.</param>
        /// <returns>The created room service request.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateRoomServiceRequest(Guid reservationRoomId, [FromBody] CreateRoomServiceCommand command)
        {
            if (command.ReservationRoomId != reservationRoomId)
            {
                return BadRequest("Reservation Room ID in the route and body must match.");
            }
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRoomServiceRequestById), new { reservationRoomId = result.ReservationRoomId, id = result.Id }, result);
        }

        /// <summary>
        /// Gets all room service requests for a specific reservation room.
        /// </summary>
        /// <param name="reservationRoomId">The ID of the reservation room.</param>
        /// <returns>A list of room service requests.</returns>
        [HttpGet]
        public async Task<IActionResult> GetRoomServiceRequestsForReservationRoom(Guid reservationRoomId)
        {
            var query = new GetRoomServicesForReservationRoomQuery { ReservationRoomId = reservationRoomId };
            var roomServices = await _mediator.Send(query);
            return Ok(roomServices);
        }

        /// <summary>
        /// Gets a single room service request by ID.
        /// </summary>
        /// <param name="reservationRoomId">The ID of the reservation room.</param>
        /// <param name="id">The ID of the room service request.</param>
        /// <returns>The room service request.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomServiceRequestById(Guid reservationRoomId, Guid id)
        {
            var query = new GetRoomServiceByIdQuery { Id = id, ReservationRoomId = reservationRoomId };
            var roomService = await _mediator.Send(query);

            if (roomService == null)
            {
                return NotFound();
            }

            return Ok(roomService);
        }
    }
}