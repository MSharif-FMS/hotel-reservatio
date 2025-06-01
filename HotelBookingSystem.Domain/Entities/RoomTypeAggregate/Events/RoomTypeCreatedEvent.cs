csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.RoomTypeAggregate.Events
{
    public class RoomTypeCreatedEvent : BaseDomainEvent
    {
        public long RoomTypeId { get; }
        public long HotelId { get; }
        public string Name { get; }

        public RoomTypeCreatedEvent(long roomTypeId, long hotelId, string name)
        {
            RoomTypeId = roomTypeId;
            HotelId = hotelId;
            Name = name;
        }
    }
}