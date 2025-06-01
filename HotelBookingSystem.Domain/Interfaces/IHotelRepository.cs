csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Domain.Entities;


namespace HotelBookingSystem.Domain.Interfaces
{
    public interface IHotelRepository
    {
        Task AddAsync(Hotel hotel);
        Task UpdateAsync(Hotel hotel);
        Task<bool> DeleteAsync(long hotelId);
        Task<Hotel?> GetByIdAsync(long hotelId);
        Task<IEnumerable<Hotel>> GetAllAsync(int pageNumber, int pageSize);
    }
}