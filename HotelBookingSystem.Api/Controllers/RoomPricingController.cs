csharp
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomPricingController : ControllerBase
    {
        private readonly IRoomPricingRepository _roomPricingRepository;

        public RoomPricingController(IRoomPricingRepository roomPricingRepository)
        {
            _roomPricingRepository = roomPricingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomPricing>>> GetRoomPricingEntries()
        {
            var roomPricingEntries = await _roomPricingRepository.GetAllRoomPricingAsync();
            return Ok(roomPricingEntries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomPricing>> GetRoomPricingEntry(long id)
        {
            var roomPricingEntry = await _roomPricingRepository.GetRoomPricingByIdAsync(id);

            if (roomPricingEntry == null)
            {
                return NotFound();
            }

            return Ok(roomPricingEntry);
        }

        [HttpGet("roomType/{roomTypeId}/dateRange")]
        public async Task<ActionResult<IEnumerable<RoomPricing>>> GetRoomPricingByRoomTypeAndDateRange(long roomTypeId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var roomPricingEntries = await _roomPricingRepository.GetRoomPricingByRoomTypeAndDateRangeAsync(roomTypeId, startDate, endDate);
            return Ok(roomPricingEntries);
        }

        [HttpGet("ratePlan/{ratePlanId}/dateRange")]
        public async Task<ActionResult<IEnumerable<RoomPricing>>> GetRoomPricingByRatePlanAndDateRange(long ratePlanId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var roomPricingEntries = await _roomPricingRepository.GetRoomPricingByRatePlanAndDateRangeAsync(ratePlanId, startDate, endDate);
            return Ok(roomPricingEntries);
        }

        // Add other CRUD endpoints (POST, PUT, DELETE) as needed
    }
}