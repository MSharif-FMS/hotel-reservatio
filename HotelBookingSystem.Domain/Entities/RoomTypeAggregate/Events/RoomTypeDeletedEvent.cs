csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.RoomTypeAggregate.Events
{
    public class RoomTypeDeletedEvent : BaseDomainEvent
    {
        public long RoomTypeId { get; }
        public long HotelId { get; }

        public RoomTypeDeletedEvent(long roomTypeId, long hotelId)
        {
            RoomTypeId = roomTypeId;
            HotelId = hotelId;
        }
    }
}