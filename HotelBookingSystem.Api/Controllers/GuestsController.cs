csharp
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestRepository _guestRepository; // Assuming an interface like this exists in Application

        public GuestsController(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        /// <summary>
        /// Gets all guests for a specific reservation room.
        /// </summary>
        /// <param name="reservationRoomId">The ID of the reservation room.</param>
        /// <returns>A list of guests.</returns>
        [HttpGet("reservationroom/{reservationRoomId}")]
        public async Task<ActionResult<IEnumerable<Guest>>> GetGuestsForReservationRoom(long reservationRoomId)
        {
            var guests = await _guestRepository.GetGuestsByReservationRoomIdAsync(reservationRoomId);
            if (guests == null)
            {
                return NotFound();
            }
            return Ok(guests);
        }

        /// <summary>
        /// Gets a guest by their ID.
        /// </summary>
        /// <param name="id">The ID of the guest.</param>
        /// <returns>The guest with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Guest>> GetGuestById(long id)
        {
            var guest = await _guestRepository.GetByIdAsync(id);
            if (guest == null)
            {
                return NotFound();
            }
            return Ok(guest);
        }

        // Additional endpoints for Create, Update, Delete would be added here
    }
}