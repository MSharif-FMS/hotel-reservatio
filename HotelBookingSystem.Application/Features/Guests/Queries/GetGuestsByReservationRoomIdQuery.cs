csharp
using MediatR;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.Guests.Queries
{
    public class GetGuestsByReservationRoomIdQuery : IRequest<IEnumerable<GuestDto>>
    {
        public long ReservationRoomId { get; set; }
    }
}