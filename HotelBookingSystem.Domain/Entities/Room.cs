csharp
using System;
using System.Collections.Generic;
using HotelBookingSystem.Domain.Common;
using HotelBookingSystem.Domain.Entities.RoomAggregate.Events;

namespace HotelBookingSystem.Domain.Entities
{
    public class Room
    {
        private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();
        public long Id { get; set; }
        public long HotelId { get; set; }
        public long RoomTypeId { get; set; }
        public string RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public string ViewType { get; set; } // Consider using an enum for ViewType
        public bool IsSmoking { get; set; }
        public bool IsAccessible { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Navigation properties
        public Hotel Hotel { get; set; }
        public RoomType RoomType { get; set; }

        // Assuming RoomStatus is a property to track the current status
        public string Status { get; private set; } // Consider using an enum for Status

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

        // Example methods that would trigger domain events
        public void Create()
        {
            // Logic to create the room
            AddDomainEvent(new RoomCreatedEvent(Id, HotelId, RoomTypeId, RoomNumber));
        }

        public void Update(string roomNumber, int floorNumber, string viewType, bool isSmoking, bool isAccessible, bool isActive)
        {
            // Logic to update room properties
            RoomNumber = roomNumber;
            FloorNumber = floorNumber;
            ViewType = viewType;
            IsSmoking = isSmoking;
            IsAccessible = isAccessible;
            IsActive = isActive;
            AddDomainEvent(new RoomUpdatedEvent(Id, RoomNumber, FloorNumber, ViewType)); // Include relevant data
        }

        public void Delete()
        {
            // Logic to delete the room
            AddDomainEvent(new RoomDeletedEvent(Id, HotelId, RoomTypeId));
        }
    }
}