csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Domain.Interfaces
{
    public interface IRatePlanRepository
    {
        Task<RatePlan> AddAsync(RatePlan ratePlan);
        Task<bool> UpdateAsync(RatePlan ratePlan);
        Task<bool> DeleteAsync(long ratePlanId);
        Task<RatePlan> GetByIdAsync(long ratePlanId);
        Task<IEnumerable<RatePlan>> GetAllAsync();
        Task<IEnumerable<RatePlan>> GetByHotelIdAsync(long hotelId);    
    }
}