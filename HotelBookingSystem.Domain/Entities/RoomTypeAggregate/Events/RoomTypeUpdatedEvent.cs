csharp
using System;
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.RoomTypeAggregate.Events
{
    public class RoomTypeUpdatedEvent : BaseDomainEvent
    {
        public long RoomTypeId { get; }
        public string Name { get; }
        public string Description { get; }

        public RoomTypeUpdatedEvent(long roomTypeId, string name, string description)
        {
            RoomTypeId = roomTypeId;
            Name = name;
            Description = description;
        }
    }
}