csharp
using HotelBookingSystem.Domain.Common;
using System;

namespace HotelBookingSystem.Domain.Entities.ReservationAggregate.Events
{
    public class ReservationCompletedEvent : BaseDomainEvent
    {
        public long ReservationId { get; }
        public DateTimeOffset CheckOutDate { get; }

        public ReservationCompletedEvent(long reservationId, DateTimeOffset checkOutDate)
        {
            ReservationId = reservationId;
            CheckOutDate = checkOutDate;
        }
    }
}