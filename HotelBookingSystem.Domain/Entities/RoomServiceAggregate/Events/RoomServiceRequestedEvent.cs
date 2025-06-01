csharp
using System;
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.RoomServiceAggregate.Events
{
    public class RoomServiceRequestedEvent : BaseDomainEvent
    {
        public long RoomServiceId { get; }
        public long ReservationRoomId { get; }
        public long ServiceId { get; }
        public int Quantity { get; }
        public DateTimeOffset RequestedTime { get; }

        public RoomServiceRequestedEvent(long roomServiceId, long reservationRoomId, long serviceId, int quantity, DateTimeOffset requestedTime)
        {
            RoomServiceId = roomServiceId;
            ReservationRoomId = reservationRoomId;
            ServiceId = serviceId;
            Quantity = quantity;
            RequestedTime = requestedTime;
        }
    }
}