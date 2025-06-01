csharp
using MediatR;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.Reservations.Queries
{
    public class GetReservationsByUserIdQuery : IRequest<IEnumerable<ReservationDto>>
    {
        public long UserId { get; set; }

        public GetReservationsByUserIdQuery(long userId)
        {
            UserId = userId;
        }
    }
}