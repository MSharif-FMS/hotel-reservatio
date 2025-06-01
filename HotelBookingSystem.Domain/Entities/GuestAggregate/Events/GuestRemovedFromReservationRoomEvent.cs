csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.GuestAggregate.Events
{
    public class GuestRemovedFromReservationRoomEvent : BaseDomainEvent
    {
        public long GuestId { get; }
        public long ReservationRoomId { get; }

        public GuestRemovedFromReservationRoomEvent(long guestId, long reservationRoomId)
        {
            GuestId = guestId;
            ReservationRoomId = reservationRoomId;
        }
    }
}