csharp
using HotelBookingSystem.Application.Features.Users.Queries;
using HotelBookingSystem.Application.DTOs.User; // Assuming UserDto is in this namespace
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Users.Handlers
{

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                return null; // Or throw a specific exception
            }

            // Map the User entity to a UserDto
            // This mapping can be improved using a library like AutoMapper
            var userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                Role = user.Role,
                IsActive = user.IsActive,
                LastLogin = user.LastLogin,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };

            return userDto;
        }
    }
}