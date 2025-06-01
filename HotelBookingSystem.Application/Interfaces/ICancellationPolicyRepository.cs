csharp
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface ICancellationPolicyRepository : IGenericRepository<CancellationPolicy>
    {
        // Add any cancellation policy specific methods here if needed
    }
}