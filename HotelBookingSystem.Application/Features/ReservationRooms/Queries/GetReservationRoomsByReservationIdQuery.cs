csharp
using MediatR;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.ReservationRooms.Queries
{
    public class GetReservationRoomsByReservationIdQuery : IRequest<IEnumerable<ReservationRoomDto>>
    {
        public long ReservationId { get; set; }
    }
}