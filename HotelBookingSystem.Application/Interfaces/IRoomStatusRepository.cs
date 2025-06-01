csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IRoomStatusRepository : IGenericRepository<RoomStatus>
    {
        Task<RoomStatus> GetCurrentStatusByRoomIdAsync(long roomId);
        Task<IEnumerable<RoomStatus>> GetStatusHistoryByRoomIdAsync(long roomId);
    }
}