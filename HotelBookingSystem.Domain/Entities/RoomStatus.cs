csharp
using System;
using System.Collections.Generic;
using HotelBookingSystem.Domain.Common;
using HotelBookingSystem.Domain.Entities.RoomStatusAggregate.Events;

namespace HotelBookingSystem.Domain.Entities
{
    public class RoomStatus
    {
 private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();
        public long Id { get; set; }
        public long RoomId { get; set; }
        public string Status { get; set; }
        public string? Notes { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Navigation properties
        public Room Room { get; set; }
        public User? UpdatedByUser { get; set; }

        // Public read-only property to access domain events
        public IReadOnlyCollection<BaseDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        // Method to clear domain events
        public void ClearDomainEvents()
        {
 _domainEvents.Clear();
        }

        // Method to add a domain event
        private void AddDomainEvent(BaseDomainEvent domainEvent)
        {
 _domainEvents.Add(domainEvent);
        }

        // Method to update room status and raise event
        public void UpdateStatus(string newStatus, string? notes, long? updatedBy)
        {
 var oldStatus = Status;
            Status = newStatus;
            AddDomainEvent(new RoomStatusUpdatedEvent(RoomId, oldStatus, newStatus, updatedBy));
 }
    }
}