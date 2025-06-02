csharp
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using HotelBookingSystem.Application.Features.Guests.Queries.GetGuestsByReservationRoomId;
using HotelBookingSystem.Application.Features.Guests.Queries.GetGuestById;
using HotelBookingSystem.Application.DTOs.Guest;
using HotelBookingSystem.Application.Features.Guests.Commands.CreateGuest;
using HotelBookingSystem.Application.Features.Guests.Commands.UpdateGuest;
using HotelBookingSystem.Application.Features.Guests.Commands.DeleteGuest;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {        private readonly IMediator _mediator;
        public GuestsController(IMediator mediator)
        {
            _guestRepository = guestRepository;
        }

        /// <summary>
        /// Gets all guests for a specific reservation room.
        /// </summary>
        /// <param name="reservationRoomId">The ID of the reservation room.</param>
        /// <returns>A list of guests.</returns>
        [HttpGet("reservationroom/{reservationRoomId}")]
        public async Task<ActionResult<IEnumerable<GuestDto>>> GetGuestsForReservationRoom(long reservationRoomId)
        {
            var guests = await _mediator.Send(new GetGuestsByReservationRoomIdQuery { ReservationRoomId = reservationRoomId });
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
        public async Task<ActionResult<GuestDto>> GetGuestById(long id)
        {
            var guest = await _mediator.Send(new GetGuestByIdQuery { Id = id });
            if (guest == null)
            {
                return NotFound();
            }
            return Ok(guest);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GuestDto>> CreateGuest([FromBody] CreateGuestCommand command)
        {
            var guestDto = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetGuestById), new { id = guestDto.Id }, guestDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateGuest(long id, [FromBody] UpdateGuestCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Guest ID in the URL and body do not match.");
            }
            var success = await _mediator.Send(command);
            if (!success)
            {
                return NotFound($"Guest with ID {id} not found or update failed.");
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteGuest(long id)
        {
            var success = await _mediator.Send(new DeleteGuestCommand { Id = id });
            if (!success)
            {
                return NotFound($"Guest with ID {id} not found or deletion failed.");
            }
            return NoContent();
        }
    }
}