csharp
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Repositories
{
    public class RoomTypeRepository : GenericRepository<RoomType>, IRoomTypeRepository
    {
        private readonly HotelBookingSystemDbContext _dbContext;

        public RoomTypeRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RoomType>> GetRoomTypesByHotelIdAsync(long hotelId)
        {
            return await _dbContext.RoomTypes
                                   .Where(rt => rt.HotelId == hotelId)
                                   .ToListAsync();
        }
    }
}