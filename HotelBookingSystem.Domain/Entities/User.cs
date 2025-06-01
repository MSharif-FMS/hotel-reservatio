csharp
using System;
using System.Collections.Generic;
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.UserAggregate
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; } = "guest"; // Default value
        public bool IsActive { get; set; } = true; // Default value
        public DateTimeOffset? LastLogin { get; set; }
        public DateTimeOffset PasswordUpdatedAt { get; set; } = DateTimeOffset.UtcNow; // Default value
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow; // Default value
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow; // Default value

        private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();
        public IReadOnlyCollection<BaseDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(BaseDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        // Consider adding a constructor or factory method to add UserCreatedEvent
    }
}