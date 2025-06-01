csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Guests.Commands
{
    public class DeleteGuestCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}