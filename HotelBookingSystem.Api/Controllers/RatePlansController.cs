csharp
using HotelBookingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatePlansController : ControllerBase
    {
        private readonly IRatePlanRepository _ratePlanRepository; // Assuming this exists in Application.Interfaces

        public RatePlansController(IRatePlanRepository ratePlanRepository)
        {
            _ratePlanRepository = ratePlanRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRatePlans()
        {
            var ratePlans = await _ratePlanRepository.GetAllAsync();
            return Ok(ratePlans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRatePlanById(long id)
        {
            var ratePlan = await _ratePlanRepository.GetByIdAsync(id);
            if (ratePlan == null)
            {
                return NotFound();
            }
            return Ok(ratePlan);
        }

        [HttpGet("hotel/{hotelId}")]
        public async Task<IActionResult> GetRatePlansByHotelId(long hotelId)
        {
            var ratePlans = await _ratePlanRepository.GetByHotelIdAsync(hotelId);
            return Ok(ratePlans);
        }
    }
}