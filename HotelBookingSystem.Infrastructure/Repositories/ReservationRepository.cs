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
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        private readonly HotelBookingSystemDbContext _dbContext;

        public ReservationRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByUserIdAsync(long userId)
        {
            return await _dbContext.Reservations
                                   .Where(r => r.UserId == userId)
                                   .ToListAsync();
        }

        // Implement any other specific methods defined in IReservationRepository here
    }
}