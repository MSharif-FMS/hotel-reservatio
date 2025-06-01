csharp
using HotelBookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IImageRepository : IGenericRepository<Image>
    {
        Task<IEnumerable<Image>> GetImagesByEntityAsync(string entityType, long entityId);
    }
}