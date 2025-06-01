csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IRatePlanRepository : IGenericRepository<RatePlan>
    {
        Task<IEnumerable<RatePlan>> GetRatePlansByHotelIdAsync(long hotelId);
    }
}