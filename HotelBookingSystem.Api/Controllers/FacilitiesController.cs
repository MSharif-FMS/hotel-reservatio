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
    public class FacilitiesController : ControllerBase
    {
        private readonly IFacilityRepository _facilityRepository;

        public FacilitiesController(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facility>>> GetFacilities()
        {
            var facilities = await _facilityRepository.GetAllAsync();
            return Ok(facilities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Facility>> GetFacility(long id)
        {
            var facility = await _facilityRepository.GetByIdAsync(id);

            if (facility == null)
            {
                return NotFound();
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