csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.ReservationAggregate.Events
{
    public class ReservationConfirmedEvent : BaseDomainEvent
    {
        public long ReservationId { get; }

        public ReservationConfirmedEvent(long reservationId)
        {
            ReservationId = reservationId;
        }
    }
}