csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Reservations.Queries;

public class GetReservationByIdQuery : IRequest<ReservationDto>
{
    public long ReservationId { get; set; }
}