csharp
using HotelBookingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionsController : ControllerBase
    {
        private readonly IPromotionRepository _promotionRepository; // Assuming IPromotionRepository exists in Application layer

        public PromotionsController(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPromotions()
        {
            // Assuming _promotionRepository.GetAllAsync() exists
            var promotions = await _promotionRepository.GetAllAsync();
            return Ok(promotions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromotionById(long id)
        {
            // Assuming _promotionRepository.GetByIdAsync(id) exists
            var promotion = await _promotionRepository.GetByIdAsync(id);

            if (promotion == null)
            {
                return NotFound();
            }

            return Ok(promotion);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActivePromotions()
        {
            // Assuming _promotionRepository.GetActiveAsync() exists
            var activePromotions = await _promotionRepository.GetActiveAsync();
            return Ok(activePromotions);
        }
    }
}