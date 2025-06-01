csharp
using HotelBookingSystem.Domain.Common;
using System;

namespace HotelBookingSystem.Domain.Entities.RoomAggregate.Events
{
    public class RoomUpdatedEvent : BaseDomainEvent
    {
        public long RoomId { get; }
        public string RoomNumber { get; }
        public int FloorNumber { get; }
        public string ViewType { get; }

        public RoomUpdatedEvent(long roomId, string roomNumber, int floorNumber, string viewType)
        {
            RoomId = roomId;
            RoomNumber = roomNumber;
            FloorNumber = floorNumber;
            ViewType = viewType;
        }
    }
}