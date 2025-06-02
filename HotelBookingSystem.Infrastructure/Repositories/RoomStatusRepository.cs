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
    public class RoomStatusRepository : GenericRepository<RoomStatus>, IRoomStatusRepository
    {
        private readonly HotelBookingSystemDbContext _dbContext;

        public RoomStatusRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RoomStatus> GetCurrentRoomStatusAsync(long roomId)
        {
            return await _dbContext.RoomStatuses
                .Where(rs => rs.RoomId == roomId)
                .OrderByDescending(rs => rs.CreatedAt)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RoomStatus>> GetRoomStatusHistoryAsync(long roomId)
        {
            return await _dbContext.RoomStatuses
                .Where(rs => rs.RoomId == roomId)
                .OrderByDescending(rs => rs.CreatedAt)
                .ToListAsync();
        }
    }
}