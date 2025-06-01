csharp
using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IRoomPricingRepository : IGenericRepository<RoomPricing>
    {
        Task<IEnumerable<RoomPricing>> GetByRoomTypeAndDateRangeAsync(long roomTypeId, DateTimeOffset startDate, DateTimeOffset endDate);
        Task<IEnumerable<RoomPricing>> GetByRatePlanAndDateRangeAsync(long ratePlanId, DateTimeOffset startDate, DateTimeOffset endDate);
    }
}