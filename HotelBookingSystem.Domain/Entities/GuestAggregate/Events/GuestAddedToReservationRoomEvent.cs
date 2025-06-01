csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.GuestAggregate.Events
{
    public class GuestAddedToReservationRoomEvent : BaseDomainEvent
    {
        public long GuestId { get; }
        public long ReservationRoomId { get; }

        public GuestAddedToReservationRoomEvent(long guestId, long reservationRoomId)
        {
            GuestId = guestId;
            ReservationRoomId = reservationRoomId;
        }
    }
}