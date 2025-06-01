csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IFacilityRepository : IGenericRepository<Facility>
    {
        Task<IEnumerable<Facility>> GetFacilitiesByHotelIdAsync(long hotelId);
    }
}