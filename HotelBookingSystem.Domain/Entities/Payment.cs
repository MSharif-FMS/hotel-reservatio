csharp
using System;
using System.Collections.Generic;
using HotelBookingSystem.Domain.Common;
using HotelBookingSystem.Domain.Entities.PaymentAggregate.Events;

namespace HotelBookingSystem.Domain.Entities
{
    public class Payment
    {
        private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();
        public long Id { get; set; }
        public long ReservationId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentGateway { get; set; }
        public string TransactionId { get; set; }
        public string Status { get; set; }
        public string CardLast4 { get; set; }
        public string CardBrand { get; set; }
        public string ReceiptUrl { get; set; }
        public DateTimeOffset? CapturedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Navigation properties
        public Reservation Reservation { get; set; }
        public User ProcessedBy { get; set; } // Mapping to 'processed_by' which references users(id)

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
        // This constructor is for EF Core and should not be used directly
        private Payment() { }

        public Payment(long reservationId, decimal amount, string currency, string paymentMethod, string paymentGateway)
        {
            ReservationId = reservationId;
            Amount = amount;
            Currency = currency;
            PaymentMethod = paymentMethod;
            PaymentGateway = paymentGateway;
            Status = "Pending"; // Initial status
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;

            AddDomainEvent(new PaymentCreatedEvent(Id, ReservationId, Amount, Currency));
        }

        // You would add methods like CompletePayment, FailPayment, RefundPayment, PartialRefundPayment
        // that update the Status and add the corresponding domain events.
    }
}