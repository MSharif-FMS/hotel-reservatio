csharp
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Domain.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> AddAsync(Room room);
        Task<bool> UpdateAsync(Room room);
        Task<bool> DeleteAsync(long roomId);
        Task<Room> GetByIdAsync(long roomId);
        Task<IEnumerable<Room>> GetAllAsync();
        Task<IEnumerable<Room>> GetByHotelIdAsync(long hotelId);
        //Task<IEnumerable<Room>> GetByRoomTypeIdAsync(long roomTypeId); // This seems redundant with GetByHotelIdAndRoomTypeIdAsync
        Task<IEnumerable<Room>> GetByHotelIdAndRoomTypeIdAsync(long hotelId, long roomTypeId);
    }
}