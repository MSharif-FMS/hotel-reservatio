csharp
using HotelBookingSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Domain.Entities.HotelAggregate.Events
{
    public class HotelCreatedEvent : BaseDomainEvent
    {
        public long HotelId { get; }
        public string Name { get; }
        public string Location { get; }

        public HotelCreatedEvent(long hotelId, string name, string location)
        {
            HotelId = hotelId;
            Name = name;
            Location = location;
        }
    }
}