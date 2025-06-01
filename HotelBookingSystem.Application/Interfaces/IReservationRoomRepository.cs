csharp
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IReservationRoomRepository : IGenericRepository<ReservationRoom>
    {
        Task<IEnumerable<ReservationRoom>> GetByReservationIdAsync(long reservationId);
    }
}