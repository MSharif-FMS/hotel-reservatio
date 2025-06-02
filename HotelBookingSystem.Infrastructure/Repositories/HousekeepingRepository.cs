csharp
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Repositories
{
    public class HousekeepingRepository : GenericRepository<Housekeeping>, IHousekeepingRepository
    {
        private readonly HotelBookingSystemDbContext _dbContext;

        public HousekeepingRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Housekeeping>> GetHousekeepingTasksByRoomIdAsync(long roomId)
        {
            return await _dbContext.Housekeeping
                .Where(ht => ht.RoomId == roomId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Housekeeping>> GetHousekeepingTasksByStaffIdAsync(long staffId)
        {
            return await _dbContext.Housekeeping
                .Where(ht => ht.StaffId == staffId)
                .ToListAsync();
        }
    }
}