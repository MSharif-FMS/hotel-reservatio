csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Domain.Interfaces
{
    public interface ICancellationPolicyRepository
    {
        Task AddAsync(CancellationPolicy policy);
        Task<bool> UpdateAsync(CancellationPolicy policy);
        Task<bool> DeleteAsync(long policyId);
        Task<CancellationPolicy?> GetByIdAsync(long policyId);
        Task<IEnumerable<CancellationPolicy>> GetAllAsync(); 
    }
}