csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IRefundRepository : IGenericRepository<Refund>
    {
        Task<IEnumerable<Refund>> GetRefundsByPaymentIdAsync(long paymentId);
    }
}