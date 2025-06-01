csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.RoomServiceAggregate.Events
{
    public class RoomServiceInProgressEvent : BaseDomainEvent
    {
        public long RoomServiceId { get; }

        public RoomServiceInProgressEvent(long roomServiceId)
        {
            RoomServiceId = roomServiceId;
        }
    }
}