csharp
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Repositories
{
    public class PromotionRepository : GenericRepository<Promotion>, IPromotionRepository
    {
        private readonly HotelBookingSystemDbContext _dbContext;

        public PromotionRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Promotion>> GetActiveAsync()
        {
            var now = DateTimeOffset.UtcNow;
            return await _dbContext.Promotions
                                   .Where(p => p.IsActive && p.ValidFrom <= now && p.ValidTo >= now)
                                   .ToListAsync();
        }

        public async Task<Promotion?> GetByCodeAsync(string code)
        {
            return await _dbContext.Promotions
                                   .FirstOrDefaultAsync(p => p.Code == code);
        }
    }
}