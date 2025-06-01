csharp
using System;
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.GuestAggregate.Events
{
    public class GuestUpdatedEvent : BaseDomainEvent
    {
        public long GuestId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Phone { get; }
        public string IdType { get; }
        public string IdNumber { get; }
        public string Nationality { get; }
        public bool IsPrimary { get; }

        public GuestUpdatedEvent(long guestId, string firstName, string lastName, string email, string phone, string idType, string idNumber, string nationality, bool isPrimary)
        {
            GuestId = guestId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            IdType = idType;
            IdNumber = idNumber;
            Nationality = nationality;
            IsPrimary = isPrimary;
        }
    }
}