csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Users.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public long UserId { get; set; } = default!;
    }
}