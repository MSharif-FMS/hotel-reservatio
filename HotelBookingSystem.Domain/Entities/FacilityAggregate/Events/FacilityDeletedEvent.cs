csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.FacilityAggregate.Events
{
    public class FacilityDeletedEvent : BaseDomainEvent
    {
        public long FacilityId { get; }
        public long HotelId { get; }

        public FacilityDeletedEvent(long facilityId, long hotelId)
        {
            FacilityId = facilityId;
            HotelId = hotelId;
        }
    }
}