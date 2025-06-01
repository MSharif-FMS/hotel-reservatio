csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviewsByHotelIdAsync(long hotelId);
        Task<IEnumerable<Review>> GetReviewsByUserIdAsync(long userId);
    }
}