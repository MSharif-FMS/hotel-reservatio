csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.ReservationAggregate.Events
{
    public class ReservationNoShowEvent : BaseDomainEvent
    {
        public long ReservationId { get; }

        public ReservationNoShowEvent(long reservationId)
        {
            ReservationId = reservationId;
        }
    }
}