csharp
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using HotelBookingSystem.Application.DTOs.Hotel;
using HotelBookingSystem.Application.Features.Hotels.Queries.GetHotels;
using HotelBookingSystem.Application.Features.Hotels.Queries.GetHotelById;
using HotelBookingSystem.Application.Features.Hotels.Commands.CreateHotel;
using HotelBookingSystem.Application.Features.Hotels.Commands.UpdateHotel;
using HotelBookingSystem.Application.Features.Hotels.Commands.DeleteHotel;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
        {
            var query = new GetAllHotelsQuery();
            var hotels = await _mediator.Send(query);

            // Assuming getAll query always returns a list, even if empty, no NotFound check needed here
            return Ok(hotels); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(long id)
        {
            var query = new GetHotelByIdQuery { Id = id };
            var hotel = await _mediator.Send(query);

            if (hotel == null)
            {
                return NotFound($"Hotel with ID {id} not found.");
            }

            return Ok(hotel); 
        }

        [HttpPost]
        public async Task<ActionResult<HotelDto>> CreateHotel([FromBody] CreateHotelCommand command)
        {
            var hotel = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<HotelDto>> UpdateHotel(long id, [FromBody] UpdateHotelCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Hotel ID in the URL and body do not match.");
            }

            var hotel = await _mediator.Send(command);
            if (hotel == null)
            {
                return NotFound($"Hotel with ID {id} not found.");
            }
            return Ok(hotel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteHotel(long id)
        {
            var command = new DeleteHotelCommand { Id = id };
            var result = await _mediator.Send(command);
            
            // Depending on the command handler's return value for deletion, 
            // you might return NoContent() or handle specific not found cases from the handler.
            // Assuming the handler throws NotFoundException or similar if not found, 
            // or you handle it within the handler and return a boolean/status.
            // For simplicity, assuming successful deletion returns Unit and we return NoContent.
            return NoContent(); 
        }
    }
}