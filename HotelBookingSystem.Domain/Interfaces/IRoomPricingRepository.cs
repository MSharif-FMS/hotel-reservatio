csharp
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Domain.Interfaces
{
    public interface IRoomPricingRepository
    {
        Task<RoomPricing> AddAsync(RoomPricing pricing);
        Task<bool> UpdateAsync(RoomPricing pricing);
        Task<bool> DeleteAsync(long pricingId);
        Task<RoomPricing> GetByIdAsync(long pricingId);
        Task<IEnumerable<RoomPricing>> GetAllAsync();
        Task<IEnumerable<RoomPricing>> GetByRoomTypeIdAndDateRangeAsync(long roomTypeId, DateTimeOffset startDate, DateTimeOffset endDate);
        Task<IEnumerable<RoomPricing>> GetByRatePlanIdAndDateRangeAsync(long ratePlanId, DateTimeOffset startDate, DateTimeOffset endDate);
    }
}