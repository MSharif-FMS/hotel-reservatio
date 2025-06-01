csharp
using System;
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.RoomServiceAggregate.Events
{
    public class RoomServiceCompletedEvent : BaseDomainEvent
    {
        public long RoomServiceId { get; }
        public DateTimeOffset CompletedTime { get; }

        public RoomServiceCompletedEvent(long roomServiceId, DateTimeOffset completedTime)
        {
            RoomServiceId = roomServiceId;
            CompletedTime = completedTime;
        }
    }
}