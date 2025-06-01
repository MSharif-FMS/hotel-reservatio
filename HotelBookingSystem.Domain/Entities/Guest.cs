csharp
using System;
using System.Collections.Generic;
using HotelBookingSystem.Domain.Common;
using HotelBookingSystem.Domain.Entities.GuestAggregate.Events;

namespace HotelBookingSystem.Domain.Entities
{
    public class Guest
    {
        private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();
        public long Id { get; set; }
        public long ReservationRoomId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IdType { get; set; }
        public string IdNumber { get; set; }
        public string Nationality { get; set; }
        public bool IsPrimary { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        // Navigation Property
        public ReservationRoom ReservationRoom { get; set; }

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
        public void AddToReservationRoom(long reservationRoomId)
        {
            ReservationRoomId = reservationRoomId;
            AddDomainEvent(new GuestAddedToReservationRoomEvent(Id, ReservationRoomId));
        }

        public void UpdateDetails(string firstName, string lastName, string email, string phone, string idType, string idNumber, string nationality, bool isPrimary)
        {
            AddDomainEvent(new GuestUpdatedEvent(Id)); // Include relevant updated data
        }
    }
}