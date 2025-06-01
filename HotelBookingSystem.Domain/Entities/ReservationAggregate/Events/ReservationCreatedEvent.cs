csharp
using System;
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.ReservationAggregate.Events
{
    public class ReservationCreatedEvent : BaseDomainEvent
    {
        public long ReservationId { get; }
        public long? UserId { get; }
        public string ReservationNumber { get; }
        public decimal TotalAmount { get; }

        public ReservationCreatedEvent(long reservationId, long? userId, string reservationNumber, decimal totalAmount)
        {
            ReservationId = reservationId;
            UserId = userId;
            ReservationNumber = reservationNumber;
            TotalAmount = totalAmount;
        }
    }
}