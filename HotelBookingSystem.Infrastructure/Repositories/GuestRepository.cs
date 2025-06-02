csharp
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Repositories
{
    public class GuestRepository : GenericRepository<Guest>, IGuestRepository
    {
        private readonly HotelBookingSystemDbContext _dbContext;

        public GuestRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Guest>> GetGuestsByReservationRoomIdAsync(long reservationRoomId)
        {
            return await _dbContext.Guests
                .Where(g => g.ReservationRoomId == reservationRoomId)
                .ToListAsync();
        }
    }
}