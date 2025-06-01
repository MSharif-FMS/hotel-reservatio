csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Guests.Queries
{
    public record GetGuestByIdQuery(long Id) : IRequest<GuestDto>;
}