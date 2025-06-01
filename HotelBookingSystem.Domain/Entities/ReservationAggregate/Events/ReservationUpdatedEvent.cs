csharp
using HotelBookingSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Domain.Entities.ReservationAggregate.Events
{
    public class ReservationUpdatedEvent : BaseDomainEvent
    {
        public long ReservationId { get; }
        public Dictionary<string, object> UpdatedDetails { get; } // Consider a more specific type if needed

        public ReservationUpdatedEvent(long reservationId, Dictionary<string, object> updatedDetails)
        {
            ReservationId = reservationId;
            UpdatedDetails = updatedDetails;
        }
    }
}