csharp
using Microsoft.AspNetCore.Mvc;
using MediatR;
using HotelBookingSystem.Application.Features.Reservations.Commands.CreateReservation;
using HotelBookingSystem.Application.Features.Reservations.Queries.GetAllReservations;
using HotelBookingSystem.Application.Features.Reservations.Queries.GetReservationById;
using HotelBookingSystem.Application.Features.Reservations.Commands.UpdateReservation;
using HotelBookingSystem.Application.Features.Reservations.Commands.CancelReservation;
using HotelBookingSystem.Application.Features.Reservations.Queries; // Assuming ReservationDto is here
using System.Collections.Generic;
using HotelBookingSystem.Application.Features.Reservations.Queries.GetReservationsByUserId;
using System.Threading.Tasks;
using HotelBookingSystem.Application.DTOs.Reservation;

namespace HotelBookingSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReservationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Creates a new reservation.
    /// </summary>
    /// <param name="request">The reservation creation request.</param>
    /// <returns>The created reservation details.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReservationDto>> CreateReservation([FromBody] CreateReservationCommand command)
    {
        var reservation = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetReservationById), new { id = reservation.Id }, reservation);
    }

    /// <summary>
    /// Gets all reservations.
    /// </summary>
    /// <returns>A list of all reservations.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ReservationDto>>> GetAllReservations()
    {
        var reservations = await _mediator.Send(new GetAllReservationsQuery());
        return Ok(reservations);
    }

    /// <summary>
    /// Gets a reservation by its ID.
    /// </summary>
    /// <param name="id">The ID of the reservation.</param>
    /// <returns>The reservation details.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)] // Assuming the handler returns null if not found
    public async Task<ActionResult<ReservationDto>> GetReservationById(long id)
    {
        var reservation = await _mediator.Send(new GetReservationByIdQuery { Id = id });
        if (reservation == null)
        {
            return NotFound();
        }
        return Ok(reservation);
    }

    /// <summary>
    /// Updates an existing reservation.
    /// </summary>
    /// <param name="id">The ID of the reservation to update.</param>
    /// <param name="request">The reservation update request.</param>
    /// <returns>The updated reservation details.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)] // For bad input
    [ProducesResponseType(StatusCodes.Status404NotFound)] // If reservation to update is not found
    public async Task<ActionResult<ReservationDto>> UpdateReservation(long id, [FromBody] UpdateReservationCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("Reservation ID in the URL and body do not match.");
        }
    {
        var reservation = await _reservationService.UpdateReservationAsync(id, request);
        if (reservation == null)
        {
            return NotFound();
        }
        return Ok(reservation);
    }

    /// <summary>
    /// Gets reservations for a specific user by their ID.
    /// </summary>
    /// <param name=\"userId\">The ID of the user.</param>
    /// <returns>A list of reservations for the user.</returns>
    [HttpGet(\"user/{userId}\")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservationsByUserId(long userId)
    {
        var reservations = await _mediator.Send(new GetReservationsByUserIdQuery { UserId = userId });
        return Ok(reservations);
    }

    /// <summary>
    /// Cancels a reservation.
    /// </summary>
    /// <param name="id">The ID of the reservation to cancel.</param>
    /// <returns>A confirmation of the cancellation.</returns>
    [HttpDelete("{id}")] // Using DELETE for cancellation, or could be PUT with status update
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)] // If reservation to cancel is not found
    public async Task<IActionResult> CancelReservation(long id)
    {
        var success = await _mediator.Send(new CancelReservationCommand { Id = id });
        if (!success) // Assuming the handler returns a boolean indicating success
        {
            return NotFound();
        }
        return NoContent();
    }
}