csharp
using HotelBookingSystem.Domain.Common;
using System;

namespace HotelBookingSystem.Domain.Entities.HousekeepingAggregate.Events
{
    public class HousekeepingTaskInProgressEvent : BaseDomainEvent
    {
        public long HousekeepingId { get; }
        public long StaffId { get; }

        public HousekeepingTaskInProgressEvent(long housekeepingId, long staffId)
        {
            HousekeepingId = housekeepingId;
            StaffId = staffId;
        }
    }
}