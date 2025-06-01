csharp
using HotelBookingSystem.Domain.Common;
using System;

namespace HotelBookingSystem.Domain.Entities.FacilityAggregate.Events
{
    public class FacilityUpdatedEvent : BaseDomainEvent
    {
        public long FacilityId { get; }
        public string Name { get; }
        public string Description { get; }

        public FacilityUpdatedEvent(long facilityId, string name, string description)
        {
            FacilityId = facilityId;
            Name = name;
            Description = description;
        }
    }
}