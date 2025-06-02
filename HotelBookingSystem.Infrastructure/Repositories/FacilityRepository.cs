csharp
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Repositories
{
    public class FacilityRepository : GenericRepository<Facility>, IFacilityRepository
    {
        private readonly HotelBookingSystemDbContext _dbContext;

        public FacilityRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Facility>> GetByHotelIdAsync(long hotelId)
        {
            return await _dbContext.Facilities
                .Where(f => f.HotelId == hotelId)
                .ToListAsync();
        }
    }
}