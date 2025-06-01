csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Reservations.Commands;

public class CancelReservationCommand : IRequest<Unit>
{
    public long ReservationId { get; set; }
}