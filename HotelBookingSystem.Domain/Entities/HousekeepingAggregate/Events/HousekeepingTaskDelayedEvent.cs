csharp
using System;
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.HousekeepingAggregate.Events
{
    public class HousekeepingTaskDelayedEvent : BaseDomainEvent
    {
        public long HousekeepingId { get; }
        public string? Reason { get; }
        public DateTimeOffset? ExpectedCompletionTime { get; }

        public HousekeepingTaskDelayedEvent(long housekeepingId, string? reason = null, DateTimeOffset? expectedCompletionTime = null)
        {
            HousekeepingId = housekeepingId;
            Reason = reason;
            ExpectedCompletionTime = expectedCompletionTime;
        }
    }
}