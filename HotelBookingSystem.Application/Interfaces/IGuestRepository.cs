csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IGuestRepository : IGenericRepository<Guest>
    {
        Task<IEnumerable<Guest>> GetGuestsByReservationRoomIdAsync(long reservationRoomId);
    }
}