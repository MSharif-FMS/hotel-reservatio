csharp
using System;
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.HousekeepingAggregate.Events
{
    public class HousekeepingTaskCompletedEvent : BaseDomainEvent
    {
        public long HousekeepingId { get; }
        public DateTimeOffset CompletedTime { get; }

        public HousekeepingTaskCompletedEvent(long housekeepingId, DateTimeOffset completedTime)
        {
            HousekeepingId = housekeepingId;
            CompletedTime = completedTime;
        }
    }
}