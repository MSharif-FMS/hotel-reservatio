csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HotelBookingSystem.Domain.Interfaces
{
    public interface IRoomTypeRepository
    {
        Task<RoomType> AddAsync(RoomType roomType);
        Task<bool> UpdateAsync(RoomType roomType);
        Task<bool> DeleteAsync(long roomTypeId);
        Task<RoomType> GetByIdAsync(long roomTypeId);
        Task<IEnumerable<RoomType>> GetAllAsync();
        Task<IEnumerable<RoomType>> GetByHotelIdAsync(long hotelId);
    }
}