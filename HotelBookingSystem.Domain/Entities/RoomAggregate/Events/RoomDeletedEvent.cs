csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.RoomAggregate.Events
{
    public class RoomDeletedEvent : BaseDomainEvent
    {
        public long RoomId { get; }
        public long HotelId { get; }
        public long RoomTypeId { get; }

        public RoomDeletedEvent(long roomId, long hotelId, long roomTypeId)
        {
            RoomId = roomId;
            HotelId = hotelId;
            RoomTypeId = roomTypeId;
        }
    }
}