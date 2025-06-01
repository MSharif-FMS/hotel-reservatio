csharp
using System;
using System.Collections.Generic;
using HotelBookingSystem.Domain.Common;
using HotelBookingSystem.Domain.Entities.RefundAggregate.Events;

namespace HotelBookingSystem.Domain.Entities
{
    public class Refund
    {
        private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();
        public long Id { get; set; }
        public long PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string? Reason { get; set; }
        public long? ProcessedBy { get; set; }
        public string Status { get; set; } // e.g., 'requested', 'processing', 'completed', 'failed'
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Navigation Properties
        public Payment Payment { get; set; }
        public User? ProcessedByUser { get; set; } // Navigation property for the user who processed the refund

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
        public void RequestRefund(long paymentId, decimal amount, string? reason)
        {
            // Logic to initiate refund request
            PaymentId = paymentId;
            Amount = amount;
            Reason = reason;
            Status = "requested";
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;
            AddDomainEvent(new RefundRequestedEvent(Id, PaymentId, Amount, Reason));
        }

        // Placeholder methods for other state changes that trigger events
        public void MarkAsProcessing() => AddDomainEvent(new RefundProcessingEvent(Id));
        public void CompleteRefund() => AddDomainEvent(new RefundCompletedEvent(Id));
        public void FailRefund(string reason) => AddDomainEvent(new RefundFailedEvent(Id, reason));
    }
}