csharp
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Repositories
{
    public class RoomServiceRepository : GenericRepository<RoomService>, IRoomServiceRepository
    {
        private readonly HotelBookingSystemDbContext _dbContext;

        public RoomServiceRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RoomService>> GetRoomServicesByReservationRoomIdAsync(long reservationRoomId)
        {
            return await _dbContext.RoomServices
                                   .Where(rs => rs.ReservationRoomId == reservationRoomId)
                                   .ToListAsync();
        }
    }
}