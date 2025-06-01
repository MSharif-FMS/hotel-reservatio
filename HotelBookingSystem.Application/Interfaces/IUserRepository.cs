csharp
using HotelBookingSystem.Domain.Entities;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByEmailAsync(string email);
    }
}