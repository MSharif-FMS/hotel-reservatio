csharp
using MediatR;
using HotelBookingSystem.Application.Features.Users.Commands;
using HotelBookingSystem.Domain.Interfaces;

namespace HotelBookingSystem.Application.Features.Users.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        // This is where the repository would be injected.
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.DeleteAsync(request.Id);
        }
    }
}