csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IRoomTypeRepository : IGenericRepository<RoomType>
    {
        Task<IEnumerable<RoomType>> GetRoomTypesByHotelIdAsync(long hotelId);
    }
}