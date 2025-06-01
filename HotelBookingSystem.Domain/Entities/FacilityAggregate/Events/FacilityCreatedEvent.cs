csharp
using HotelBookingSystem.Domain.Common;
using System;

namespace HotelBookingSystem.Domain.Entities.FacilityAggregate.Events
{
    public class FacilityCreatedEvent : BaseDomainEvent
    {
        public long FacilityId { get; }
        public long HotelId { get; }
        public string Name { get; }

        public FacilityCreatedEvent(long facilityId, long hotelId, string name)
        {
            FacilityId = facilityId;
            HotelId = hotelId;
            Name = name;
        }
    }
}