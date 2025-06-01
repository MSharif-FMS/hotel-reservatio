csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Rooms.Queries
{
    public class GetRoomsByHotelIdAndRoomTypeIdQuery : IRequest<IEnumerable<RoomDto>>
    {
        public long HotelId { get; set; }
        public long RoomTypeId { get; set; }
    }
}