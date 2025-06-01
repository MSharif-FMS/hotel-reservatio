csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IHousekeepingRepository : IGenericRepository<Housekeeping>
    {
        Task<IEnumerable<Housekeeping>> GetTasksByRoomIdAsync(long roomId);
        Task<IEnumerable<Housekeeping>> GetTasksByStaffIdAsync(long staffId);
    }
}