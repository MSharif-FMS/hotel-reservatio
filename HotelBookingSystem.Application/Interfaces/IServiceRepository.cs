csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        Task<IEnumerable<Service>> GetServicesByHotelIdAsync(long hotelId);
    }
}