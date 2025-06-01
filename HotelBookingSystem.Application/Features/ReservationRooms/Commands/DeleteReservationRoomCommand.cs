csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.ReservationRooms.Commands
{
    public class DeleteReservationRoomCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}