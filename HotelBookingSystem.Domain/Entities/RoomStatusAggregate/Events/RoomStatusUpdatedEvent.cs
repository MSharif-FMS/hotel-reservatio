csharp
using HotelBookingSystem.Domain.Common;
using System;

namespace HotelBookingSystem.Domain.Entities.RoomStatusAggregate.Events
{
    public class RoomStatusUpdatedEvent : BaseDomainEvent
    {
        public long RoomId { get; }
        public string OldStatus { get; }
        public string NewStatus { get; }
        public long? UpdatedByUserId { get; }

        public RoomStatusUpdatedEvent(long roomId, string oldStatus, string newStatus, long? updatedByUserId)
        {
            RoomId = roomId;
            OldStatus = oldStatus;
            NewStatus = newStatus;
            UpdatedByUserId = updatedByUserId;
        }
    }
}