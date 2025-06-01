csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.HousekeepingAggregate.Events
{
    public class HousekeepingTaskAssignedEvent : BaseDomainEvent
    {
        public long HousekeepingId { get; }
        public long RoomId { get; }
        public long StaffId { get; }
        public string TaskType { get; }

        public HousekeepingTaskAssignedEvent(long housekeepingId, long roomId, long staffId, string taskType)
        {
            HousekeepingId = housekeepingId;
            RoomId = roomId;
            StaffId = staffId;
            TaskType = taskType;
        }
    }
}