csharp
using HotelBookingSystem.Domain.Common;
using System;

namespace HotelBookingSystem.Domain.Entities.ReservationAggregate.Events
{
    public class ReservationCancelledEvent : BaseDomainEvent
    {
        public long ReservationId { get; }
        public string CancellationReason { get; }

        public ReservationCancelledEvent(long reservationId, string cancellationReason)
        {
            ReservationId = reservationId;
            CancellationReason = cancellationReason;
        }
    }
}