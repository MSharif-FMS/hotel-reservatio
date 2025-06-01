csharp
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
// Assuming these namespaces exist in your Application layer
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Application.DTOs.ReservationRooms;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationRoomsController : ControllerBase
    {
        private readonly IReservationRoomRepository _reservationRoomRepository;

        public ReservationRoomsController(IReservationRoomRepository reservationRoomRepository)
        {
            _reservationRoomRepository = reservationRoomRepository;
        }

        [HttpGet("reservation/{reservationId}")]
        public async Task<ActionResult<IEnumerable<ReservationRoomDto>>> GetReservationRoomsForReservation(long reservationId)
        {
            var reservationRooms = await _reservationRoomRepository.GetByReservationIdAsync(reservationId);

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