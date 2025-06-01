csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetPaymentsByReservationIdAsync(long reservationId);
    }
}