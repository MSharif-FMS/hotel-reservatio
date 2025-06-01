csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IRoomServiceRepository : IGenericRepository<RoomService>
    {
        Task<IEnumerable<RoomService>> GetByReservationRoomIdAsync(long reservationRoomId);
    }
}