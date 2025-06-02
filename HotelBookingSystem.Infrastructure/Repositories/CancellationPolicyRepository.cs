csharp
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Repositories
{
    public class CancellationPolicyRepository : GenericRepository<CancellationPolicy>, ICancellationPolicyRepository
    {
        public CancellationPolicyRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
        }

        // Implement any specific methods defined in ICancellationPolicyRepository here
        // Example:
        // public async Task<CancellationPolicy> GetPolicyByNameAsync(string name)
        // {
        //     return await _dbContext.CancellationPolicies.FirstOrDefaultAsync(cp => cp.Name == name);
        // }
    }
}