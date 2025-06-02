csharp
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Repositories
{
    public class ReservationRoomRepository : GenericRepository<ReservationRoom>, IReservationRoomRepository
    {
        private readonly HotelBookingSystemDbContext _dbContext;

        public ReservationRoomRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ReservationRoom>> GetByReservationIdAsync(long reservationId)
        {
            return await _dbContext.ReservationRooms
                                   .Where(rr => rr.ReservationId == reservationId)
                                   .ToListAsync();
        }
    }
}