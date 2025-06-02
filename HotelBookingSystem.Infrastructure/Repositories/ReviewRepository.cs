csharp
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        private readonly HotelBookingSystemDbContext _dbContext;

        public ReviewRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Review>> GetByHotelIdAsync(long hotelId)
        {
            return await _dbContext.Reviews
                .Where(r => r.HotelId == hotelId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetByUserIdAsync(long userId)
        {
            return await _dbContext.Reviews
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }
    }
}