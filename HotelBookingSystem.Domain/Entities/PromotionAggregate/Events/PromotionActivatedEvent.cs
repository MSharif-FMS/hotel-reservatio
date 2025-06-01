csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.PromotionAggregate.Events
{
    public class PromotionActivatedEvent : BaseDomainEvent
    {
        public long PromotionId { get; }

        public PromotionActivatedEvent(long promotionId)
        {
            PromotionId = promotionId;
        }
    }
}