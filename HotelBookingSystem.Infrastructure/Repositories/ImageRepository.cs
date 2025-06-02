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
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        private readonly HotelBookingSystemDbContext _dbContext;

        public ImageRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Image>> GetByEntityAsync(string entityType, long entityId)
        {
            return await _dbContext.Images
                .Where(i => i.EntityType == entityType && i.EntityId == entityId)
                .OrderBy(i => i.SortOrder)
                .ToListAsync();
        }
    }
}