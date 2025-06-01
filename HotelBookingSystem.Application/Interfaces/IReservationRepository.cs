csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetReservationsByUserIdAsync(long userId);
        // Add other reservation-specific query methods here if needed
    }
}