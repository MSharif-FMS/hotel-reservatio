csharp
using System;
using System.Collections.Generic;
using HotelBookingSystem.Domain.Common;
using HotelBookingSystem.Domain.Entities.RoomServiceAggregate.Events;

namespace HotelBookingSystem.Domain.Entities
{
    public class RoomService : BaseEntity
    {
        public long Id { get; set; }
        public long ReservationRoomId { get; set; }
        public long ServiceId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset RequestedTime { get; set; }
        public string Status { get; set; } // Consider using an enum for status
        public string Notes { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Navigation Properties
        public ReservationRoom ReservationRoom { get; set; }
        public Service Service { get; set; }

        private readonly List<BaseDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<BaseDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        private void AddDomainEvent(BaseDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        // Constructor for requesting a room service
        public RoomService(long reservationRoomId, long serviceId, int quantity, DateTimeOffset requestedTime, string notes)
        {
            ReservationRoomId = reservationRoomId;
            ServiceId = serviceId;
            Quantity = quantity;
            RequestedTime = requestedTime;
            Status = "Requested"; // Initial status
            Notes = notes;
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;

            AddDomainEvent(new RoomServiceRequestedEvent(Id, ReservationRoomId, ServiceId, Quantity, RequestedTime));
        }

        // Method to mark room service as in progress
        public void MarkInProgress()
        {
            Status = "In Progress";
            UpdatedAt = DateTimeOffset.UtcNow;
            AddDomainEvent(new RoomServiceInProgressEvent(Id));
        }

        // Method to mark room service as completed
        public void MarkCompleted()
        {
            Status = "Completed";
            UpdatedAt = DateTimeOffset.UtcNow;
            AddDomainEvent(new RoomServiceCompletedEvent(Id, DateTimeOffset.UtcNow));
        }

        // Method to cancel room service
        public void Cancel(string reason)
        {
            Status = "Cancelled";
            UpdatedAt = DateTimeOffset.UtcNow;
            AddDomainEvent(new RoomServiceCancelledEvent(Id, reason));
        }
    }
}