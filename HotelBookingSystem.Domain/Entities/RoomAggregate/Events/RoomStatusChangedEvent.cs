csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.RoomAggregate.Events
{
    public class RoomStatusChangedEvent : BaseDomainEvent
    {
        public long RoomId { get; }
        public string OldStatus { get; }
        public string NewStatus { get; }

        public RoomStatusChangedEvent(long roomId, string oldStatus, string newStatus)
        {
            RoomId = roomId;
            OldStatus = oldStatus;
            NewStatus = newStatus;
        }
    }
}