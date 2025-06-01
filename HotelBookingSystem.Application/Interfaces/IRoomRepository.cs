csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<IEnumerable<Room>> GetRoomsByHotelIdAsync(long hotelId);
        Task<IEnumerable<Room>> GetRoomsByHotelAndRoomTypeIdAsync(long hotelId, long roomTypeId);
    }
}