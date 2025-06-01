csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.RoomServices.Queries
{
    public class GetRoomServicesByReservationRoomIdQuery : IRequest<IEnumerable<RoomServiceDto>>
    {
        public long ReservationRoomId { get; set; }
    }
}