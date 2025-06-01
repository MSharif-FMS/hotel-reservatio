csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Domain.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservation> AddAsync(Reservation reservation);
        Task<bool> UpdateAsync(Reservation reservation);
        Task<bool> DeleteAsync(long reservationId);
        Task<Reservation> GetByIdAsync(long reservationId);
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<IEnumerable<Reservation>> GetByUserIdAsync(long userId);
        Task<bool> UpdateStatusAsync(long reservationId, string status);
    }
}