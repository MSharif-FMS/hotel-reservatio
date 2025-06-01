csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.PromotionAggregate.Events
{
    public class PromotionDeletedEvent : BaseDomainEvent
    {
        public long PromotionId { get; }
        public string Code { get; }

        public PromotionDeletedEvent(long promotionId, string code)
        {
            PromotionId = promotionId;
            Code = code;
        }
    }
}