csharp
namespace HotelBookingSystem.Application.Features.Rooms.Queries
{
    public class GetRoomsByRoomTypeIdQuery : IRequest<IEnumerable<RoomDto>>
    {
        public long RoomTypeId { get; set; }
    }
}