csharp
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Repositories
{
    public class RatePlanRepository : GenericRepository<RatePlan>, IRatePlanRepository
    {
        private readonly HotelBookingSystemDbContext _dbContext;

        public RatePlanRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RatePlan>> GetRatePlansByHotelIdAsync(long hotelId)
        {
            return await _dbContext.RatePlans
                .Where(rp => rp.HotelId == hotelId)
                .ToListAsync();
        }
    }
}