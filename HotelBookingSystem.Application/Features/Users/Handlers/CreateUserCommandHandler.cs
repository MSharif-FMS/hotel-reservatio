csharp
using HotelBookingSystem.Application.Features.Users.Commands;
using HotelBookingSystem.Domain.Entities;
using MediatR;
using HotelBookingSystem.Domain.Interfaces; // Assuming the interface is in the Domain.Interfaces folder
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long> // Assuming it returns the ID of the created user
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // In a real application, you would hash the password and generate a salt here.
            // This is a simplified example.
            var newUser = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = request.Password, // Hashing should happen here
                Salt = "dummy_salt", // Salt generation should happen here
                FirstName = request.FirstName,
                LastName = request.LastName,
                Role = "guest", // Default role
                IsActive = true,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow,
                PasswordUpdatedAt = DateTimeOffset.UtcNow
            };

            await _userRepository.AddAsync(newUser);

            return newUser.Id;
        }
    }

}