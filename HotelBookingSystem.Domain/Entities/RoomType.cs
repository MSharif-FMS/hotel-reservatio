csharp
using System;
using System.Collections.Generic;
using HotelBookingSystem.Domain.Common;
using HotelBookingSystem.Domain.Entities.RoomTypeAggregate.Events;

namespace HotelBookingSystem.Domain.Entities
{
    public class RoomType
    {
        private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();
        public long Id { get; set; }
        public long HotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BaseCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public decimal BasePrice { get; set; }
        public int? SizeSqft { get; set; }
        public string BedConfiguration { get; set; }
        public string[] Amenities { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Navigation property for the related Hotel
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
        // You might use a constructor or a factory method for creation
        public RoomType(long hotelId, string name, string description, int baseCapacity, int maxCapacity, decimal basePrice, int? sizeSqft, string bedConfiguration, string[] amenities, bool isActive)
        {
            HotelId = hotelId;
            Name = name;
            Description = description;
            BaseCapacity = baseCapacity;
            MaxCapacity = maxCapacity;
            BasePrice = basePrice;
            SizeSqft = sizeSqft;
            BedConfiguration = bedConfiguration;
            Amenities = amenities;
            IsActive = isActive;
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;

            AddDomainEvent(new RoomTypeCreatedEvent(Id, HotelId, Name));
        }
    }
}