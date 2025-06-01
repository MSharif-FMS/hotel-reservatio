csharp
using MediatR;
using HotelBookingSystem.Application.Features.Users.Commands;
using HotelBookingSystem.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace HotelBookingSystem.Application.Features.Users.Handlers
{ // UpdateUserCommandHandler class
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken) 
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                // User not found
                return false;
            }

            // Update user properties
            if (!string.IsNullOrWhiteSpace(request.FirstName))
            {
 user.FirstName = request.FirstName;
            }
            if (!string.IsNullOrWhiteSpace(request.LastName))
            {
 user.LastName = request.LastName;
            }
            user.Phone = request.Phone;
            user.Role = request.Role; // Consider adding validation for roles
            user.IsActive = request.IsActive;
            user.UpdatedAt = DateTimeOffset.UtcNow; // Assuming you want to update the updated_at timestamp

            return await _userRepository.UpdateAsync(user);
        }
    }
}