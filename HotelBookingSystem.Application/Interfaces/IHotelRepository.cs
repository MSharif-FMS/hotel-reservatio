csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        Task<IEnumerable<Hotel>> GetHotelsByLocationAsync(string location);
        // Add other hotel-specific methods here if needed
    }
}