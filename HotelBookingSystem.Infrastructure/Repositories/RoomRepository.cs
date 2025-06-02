csharp
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        private readonly HotelBookingSystemDbContext _dbContext;

        public RoomRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Room>> GetRoomsByHotelIdAsync(long hotelId)
        {
            return await _dbContext.Rooms
                .Where(r => r.HotelId == hotelId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetRoomsByHotelIdAndRoomTypeIdAsync(long hotelId, long roomTypeId)
        {
            return await _dbContext.Rooms
                .Where(r => r.HotelId == hotelId && r.RoomTypeId == roomTypeId)
                .ToListAsync();
        }
    }
}