csharp
using System;
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.RoomServiceAggregate.Events
{
    public class RoomServiceCancelledEvent : BaseDomainEvent
    {
        public long RoomServiceId { get; }
        public string Reason { get; }

        public RoomServiceCancelledEvent(long roomServiceId, string reason)
        {
            RoomServiceId = roomServiceId;
            Reason = reason;
        }
    }
}