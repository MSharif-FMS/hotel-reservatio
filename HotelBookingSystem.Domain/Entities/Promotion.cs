csharp
using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Domain.Entities
{   
    public class Promotion
    {
        private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();

        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public DateTimeOffset ValidFrom { get; set; }
        public DateTimeOffset ValidTo { get; set; }
        public int? MinStay { get; set; }
        public decimal? MinAmount { get; set; }
        public long[] ApplicableRoomTypes { get; set; }
        public DateOnly[] BlackoutDates { get; set; } // Using DateOnly for date without time
        public int? UsageLimit { get; set; }
        public int TimesUsed { get; set; }
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
            // Logic to create the promotion
            AddDomainEvent(new PromotionCreatedEvent(Id, Code, Name));
        }

        public void Update(string name, string description, string discountType, decimal discountValue, DateTimeOffset validFrom, DateTimeOffset validTo, int? minStay, decimal? minAmount, long[] applicableRoomTypes, DateOnly[] blackoutDates, int? usageLimit, bool isActive)
        {
            // Logic to update promotion properties
            Name = name;
            Description = description;
            // ... update other properties
            AddDomainEvent(new PromotionUpdatedEvent(Id, Name, Description)); // Include relevant data
        }

        public void Delete()
        {
            // Logic to delete the promotion
            AddDomainEvent(new PromotionDeletedEvent(Id, Code));
        }

        public void Activate()
        {
            IsActive = true;
            AddDomainEvent(new PromotionActivatedEvent(Id));
        }

        public void Deactivate()
        {
            IsActive = false;
            AddDomainEvent(new PromotionDeactivatedEvent(Id));
        }
    }
}