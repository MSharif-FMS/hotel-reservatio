csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.PromotionAggregate.Events
{
    public class PromotionDeactivatedEvent : BaseDomainEvent
    {
        public long PromotionId { get; }

        public PromotionDeactivatedEvent(long promotionId)
        {
            PromotionId = promotionId;
        }
    }
}