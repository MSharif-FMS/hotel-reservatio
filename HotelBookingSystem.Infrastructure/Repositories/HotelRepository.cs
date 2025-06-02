csharp
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Repositories
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        private readonly HotelBookingSystemDbContext _dbContext;

        public HotelRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        // Implement any hotel-specific methods defined in IHotelRepository here
        public async Task<IEnumerable<Hotel>> GetHotelsByLocationAsync(string location)
        {
            // Example implementation: Filter hotels by location (case-insensitive)
            return await _dbContext.Hotels
                .Where(h => h.Location.ToLower() == location.ToLower())
                .ToListAsync();
        }

        // You can add other hotel-specific methods as needed, e.g.:
        // Task<IEnumerable<Hotel>> GetHotelsWithAvailableRoomsAsync(DateTime checkInDate, DateTime checkOutDate);
        // Task<Hotel> GetHotelWithRoomTypesAsync(long hotelId);
    }
}