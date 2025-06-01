csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IPromotionRepository : IGenericRepository<Promotion>
    {
        Task<IEnumerable<Promotion>> GetActivePromotionsAsync();
        Task<Promotion> GetPromotionByCodeAsync(string code);
    }
}