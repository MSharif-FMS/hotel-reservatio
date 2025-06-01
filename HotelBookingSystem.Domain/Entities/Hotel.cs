csharp
using System;
using System.Collections.Generic;
using HotelBookingSystem.Domain.Common;
using HotelBookingSystem.Domain.Entities.HotelAggregate.Events;

namespace HotelBookingSystem.Domain.Entities
{
    public class Hotel
    {
        private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Address { get; set; } // Representing JSONB as string for now
        public string Description { get; set; }
        public decimal? Rating { get; set; } // decimal(2, 1) can be represented as decimal?
        public int? StarRating { get; set; } // integer CHECK (star_rating BETWEEN 1 AND 5) can be int?
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

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
            // Logic to create the hotel
            AddDomainEvent(new HotelCreatedEvent(Id, Name, Location));
        }

        public void Update(string name, string location, string address, string description, decimal? rating, int? starRating, TimeSpan checkInTime, TimeSpan checkOutTime, string contactEmail, string contactPhone, bool isActive)
        {
            // Logic to update hotel properties
            Name = name;
            Location = location;
            // ... update other properties
            AddDomainEvent(new HotelUpdatedEvent(Id, Name, Location)); // Include relevant data
        }

        public void Delete()
        {
            // Logic to mark hotel as deleted or handle deletion
            AddDomainEvent(new HotelDeletedEvent(Id));
        }
    }
}