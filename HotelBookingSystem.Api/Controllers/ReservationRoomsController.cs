csharp
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
// Assuming these namespaces exist in your Application layer
using HotelBookingSystem.Application.DTOs.ReservationRooms;
using MediatR;
using HotelBookingSystem.Application.Features.ReservationRooms.Queries.GetReservationRoomsByReservationId;
using HotelBookingSystem.Application.Features.ReservationRooms.Queries.GetReservationRoomById;
using HotelBookingSystem.Application.Features.ReservationRooms.Commands.CreateReservationRoom;
using HotelBookingSystem.Application.Features.ReservationRooms.Commands.UpdateReservationRoom;
using HotelBookingSystem.Application.Features.ReservationRooms.Commands.DeleteReservationRoom;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationRoomsController : ControllerBase
    {   private readonly IMediator _mediator;

        public ReservationRoomsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("reservation/{reservationId}")]
        public async Task<ActionResult<IEnumerable<ReservationRoomDto>>> GetReservationRoomsForReservation(long reservationId)
        {
            var query = new GetReservationRoomsByReservationIdQuery { ReservationId = reservationId };
            var reservationRooms = await _mediator.Send(query);

            if (reservationRooms == null)
            {
                return NotFound();
            }

            return Ok(reservationRooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationRoomDto>> GetReservationRoomById(long id)
        {
            var reservationRoom = await _reservationRoomRepository.GetByIdAsync(id);
            var query = new GetReservationRoomByIdQuery { Id = id };
            var reservationRoom = await _mediator.Send(query);
            if (reservationRoom == null)
            {
                return NotFound();
            }

            return Ok(reservationRoom);
        }

        // You might want to add endpoints for creating, updating, or deleting reservation rooms
        // depending on your business logic and how reservation rooms are managed.
        // Typically, reservation rooms are managed as part of the reservation creation/update process.
    }
}