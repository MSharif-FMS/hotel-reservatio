csharp
using System;
using System.Collections.Generic;
using HotelBookingSystem.Domain.Common;
using HotelBookingSystem.Domain.Entities.FacilityAggregate.Events;

namespace HotelBookingSystem.Domain.Entities
{
    public class Facility
    {
        private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();

        public long Id { get; set; }
        public long HotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsChargeable { get; set; }
        // Assuming OperatingHours is a JSONB column, represent as a string for now
        public string OperatingHours { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Navigation Property
        public Hotel Hotel { get; set; }

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
        public void Create(long hotelId, string name, string description, string category, bool isChargeable, string operatingHours, bool isActive)
        {
            HotelId = hotelId;
            Name = name;
            Description = description;
            Category = category;
            IsChargeable = isChargeable;
            OperatingHours = operatingHours;
            IsActive = isActive;
            AddDomainEvent(new FacilityCreatedEvent(Id, HotelId, Name));
        }

        public void Delete()
        {
            AddDomainEvent(new FacilityDeletedEvent(Id, HotelId));
        }
    }
}