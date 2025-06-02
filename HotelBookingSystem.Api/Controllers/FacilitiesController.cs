csharp
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Application.Features.Facilities.Queries.GetAllFacilities;
using HotelBookingSystem.Application.Features.Facilities.Queries.GetFacilityById;
using HotelBookingSystem.Application.Features.Facilities.Queries.GetFacilitiesByHotelId;
using HotelBookingSystem.Application.Features.Facilities.Commands.CreateFacility;
using HotelBookingSystem.Application.Features.Facilities.Commands.UpdateFacility;
using HotelBookingSystem.Application.Features.Facilities.Commands.DeleteFacility;
using HotelBookingSystem.Application.DTOs.Facility;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacilitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FacilitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacilityDto>>> GetFacilities()
        {
            var query = new GetAllFacilitiesQuery();
            var facilities = await _mediator.Send(query);
            return Ok(facilities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacilityDto>> GetFacility(long id)
        {
            var query = new GetFacilityByIdQuery { Id = id };
            var facility = await _mediator.Send(query);

            if (facility == null)
            {
                return NotFound();
            }

            return Ok(facility);
        }

        [HttpGet("hotel/{hotelId}")]
        public async Task<ActionResult<IEnumerable<FacilityDto>>> GetFacilitiesByHotel(long hotelId)
        {
            var query = new GetFacilitiesByHotelIdQuery { HotelId = hotelId };
            var facilities = await _mediator.Send(query);
            return Ok(facilities);
        }

        [HttpPost]
        public async Task<ActionResult<FacilityDto>> CreateFacility([FromBody] CreateFacilityCommand command)
        {
            var facility = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetFacility), new { id = facility.Id }, facility);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFacility(long id, [FromBody] UpdateFacilityCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Facility ID in the URL and body do not match.");
            }
            var success = await _mediator.Send(command);
            if (!success)
            {
                return NotFound($"Facility with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFacility(long id)
        {
            var success = await _mediator.Send(new DeleteFacilityCommand { Id = id });
            if (!success)
            {
                return NotFound($"Facility with ID {id} not found.");
            }
            return NoContent();
        }
    }
}

            return Ok(facility);
        }

        [HttpGet("hotel/{hotelId}")]
        public async Task<ActionResult<IEnumerable<Facility>>> GetFacilitiesByHotel(long hotelId)
        {
            var facilities = await _facilityRepository.GetByHotelIdAsync(hotelId);
            return Ok(facilities);
        }

        // Add other CRUD operations as needed
    }
}