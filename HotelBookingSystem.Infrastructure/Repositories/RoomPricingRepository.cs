csharp
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Repositories
{
    public class RoomPricingRepository : GenericRepository<RoomPricing>, IRoomPricingRepository
    {
        private readonly HotelBookingSystemDbContext _dbContext;

        public RoomPricingRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RoomPricing>> GetRoomPricingByRoomTypeAndDateRangeAsync(long roomTypeId, DateTime startDate, DateTime endDate)
        {
            return await _dbContext.RoomPricing
                .Where(rp => rp.RoomTypeId == roomTypeId && rp.Date >= DateOnly.FromDateTime(startDate) && rp.Date <= DateOnly.FromDateTime(endDate))
                .ToListAsync();
        }

        public async Task<IEnumerable<RoomPricing>> GetRoomPricingByRatePlanAndDateRangeAsync(long ratePlanId, DateTime startDate, DateTime endDate)
        {
            return await _dbContext.RoomPricing
                .Where(rp => rp.RatePlanId == ratePlanId && rp.Date >= DateOnly.FromDateTime(startDate) && rp.Date <= DateOnly.FromDateTime(endDate))
                .ToListAsync();
        }
    }
}