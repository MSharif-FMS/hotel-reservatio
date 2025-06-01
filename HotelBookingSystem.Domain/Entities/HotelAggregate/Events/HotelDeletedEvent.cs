csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.HotelAggregate.Events;

public class HotelDeletedEvent : BaseDomainEvent
{
    public long HotelId { get; }

    public HotelDeletedEvent(long hotelId)
    {
        HotelId = hotelId;
    }
}