csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.RoomAggregate.Events
{
    public class RoomCreatedEvent : BaseDomainEvent
    {
        public long RoomId { get; }
        public long HotelId { get; }
        public long RoomTypeId { get; }
        public string RoomNumber { get; }

        public RoomCreatedEvent(long roomId, long hotelId, long roomTypeId, string roomNumber)
        {
            RoomId = roomId;
            HotelId = hotelId;
            RoomTypeId = roomTypeId;
            RoomNumber = roomNumber;
        }
    }
}