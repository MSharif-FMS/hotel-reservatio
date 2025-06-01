csharp
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Application.Models.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationsController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    /// <summary>
    /// Creates a new reservation.
    /// </summary>
    /// <param name="request">The reservation creation request.</param>
    /// <returns>The created reservation details.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateReservation([FromBody] CreateReservationRequest request)
    {
        var reservation = await _reservationService.CreateReservationAsync(request);
        return CreatedAtAction(nameof(GetReservationById), new { id = reservation.Id }, reservation);
    }

    /// <summary>
    /// Gets all reservations.
    /// </summary>
    /// <returns>A list of all reservations.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllReservations()
    {
        var reservations = await _reservationService.GetAllReservationsAsync();
        return Ok(reservations);
    }

    /// <summary>
    /// Gets a reservation by its ID.
    /// </summary>
    /// <param name="id">The ID of the reservation.</param>
    /// <returns>The reservation details.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetReservationById(long id)
    {
        var reservation = await _reservationService.GetReservationByIdAsync(id);
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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateReservation(long id, [FromBody] UpdateReservationRequest request)
    {
        var reservation = await _reservationService.UpdateReservationAsync(id, request);
        if (reservation == null)
        {
            return NotFound();
        }
        return Ok(reservation);
    }

    /// <summary>
    /// Cancels a reservation.
    /// </summary>
    /// <param name="id">The ID of the reservation to cancel.</param>
    /// <returns>A confirmation of the cancellation.</returns>
    [HttpDelete("{id}")] // Using DELETE for cancellation, or could be PUT with status update
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CancelReservation(long id)
    {
        var result = await _reservationService.CancelReservationAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}