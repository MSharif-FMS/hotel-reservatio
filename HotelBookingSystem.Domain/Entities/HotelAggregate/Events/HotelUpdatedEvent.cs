csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.HotelAggregate.Events
{
    public class HotelUpdatedEvent : BaseDomainEvent
    {
        public long HotelId { get; }
        public string Name { get; }
        public string Location { get; }
        public string Description { get; }

        public HotelUpdatedEvent(long hotelId, string name, string location, string description)
        {
            HotelId = hotelId;
            Name = name;
            Location = location;
            Description = description;
        }
    }
}