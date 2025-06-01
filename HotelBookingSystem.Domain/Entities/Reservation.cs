csharp
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HotelBookingSystem.Domain.Common;
using HotelBookingSystem.Domain.Entities.ReservationAggregate.Events;

namespace HotelBookingSystem.Domain.Entities
{

    public class Reservation
    {
        public long Id { get; set; }
        public string ReservationNumber { get; set; }
        public long? UserId { get; set; }
        public string Status { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public string SpecialRequests { get; set; }
        public string PromoCode { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string Currency { get; set; }
        public string Source { get; set; }
        public string IpAddress { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public ICollection<ReservationRoom> ReservationRooms { get; set; }
        public ICollection<Payment> Payments { get; set; }

        private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();

        public IReadOnlyCollection<BaseDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        private void AddDomainEvent(BaseDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        // Example methods that would trigger domain events
        public void Create(string reservationNumber, long? userId, int adults, int children, string specialRequests, string promoCode, decimal totalAmount, decimal taxAmount, decimal netAmount, string currency, string source, string ipAddress)
        {
            // Assign properties
            ReservationNumber = reservationNumber;
            UserId = userId;
            Adults = adults;
            Children = children;
            SpecialRequests = specialRequests;
            PromoCode = promoCode;
            TotalAmount = totalAmount;
            TaxAmount = taxAmount;
            NetAmount = netAmount;
            Currency = currency;
            Source = source;
            IpAddress = ipAddress;
            Status = "Pending"; // Initial status
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;

            AddDomainEvent(new ReservationCreatedEvent(Id, UserId, ReservationNumber, TotalAmount));
        }

        public void Confirm()
        {
            Status = "Confirmed";
            UpdatedAt = DateTimeOffset.UtcNow;
            AddDomainEvent(new ReservationConfirmedEvent(Id));
        }

        public void Cancel(string reason)
        {
            Status = "Cancelled";
            UpdatedAt = DateTimeOffset.UtcNow;
            AddDomainEvent(new ReservationCancelledEvent(Id, reason));
        }
    }
}