csharp
using System;
using System.Collections.Generic;
using HotelBookingSystem.Domain.Common;
using HotelBookingSystem.Domain.Entities.HousekeepingAggregate.Events;

namespace HotelBookingSystem.Domain.Entities
{
    public class Housekeeping : BaseEntity
    {
        public long Id { get; set; }
        public long RoomId { get; set; }
        public long StaffId { get; set; }
        public string TaskType { get; set; }
        public string Status { get; set; }
        public DateTimeOffset ScheduledTime { get; set; }
        public DateTimeOffset? CompletedTime { get; set; }
        public string? Notes { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Navigation properties
        public Room Room { get; set; }
        public User Staff { get; set; }

        private List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();
        public IReadOnlyCollection<BaseDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        private void AddDomainEvent(BaseDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public Housekeeping(long roomId, long staffId, string taskType, DateTimeOffset scheduledTime, string status)
        {
            RoomId = roomId;
            StaffId = staffId;
            TaskType = taskType;
            ScheduledTime = scheduledTime;
            Status = status;
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;

            AddDomainEvent(new HousekeepingTaskAssignedEvent(Id, RoomId, StaffId, TaskType));
        }

        public void MarkInProgress()
        {
            Status = "InProgress";
            UpdatedAt = DateTimeOffset.UtcNow;
            AddDomainEvent(new HousekeepingTaskInProgressEvent(Id, StaffId));
        }

        // Add other methods for updating status and raising events (Completed, Delayed)
        // Example:
        // public void MarkCompleted() { /* update status, add event */ }
        // public void MarkDelayed(string reason) { /* update status, add event */ }
    }
}