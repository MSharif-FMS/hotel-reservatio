csharp
using HotelBookingSystem.Domain.Common;
using System;

namespace HotelBookingSystem.Domain.Entities.PromotionAggregate.Events
{
    public class PromotionCreatedEvent : BaseDomainEvent
    {
        public long PromotionId { get; }
        public string Code { get; }
        public string Name { get; }

        public PromotionCreatedEvent(long promotionId, string code, string name)
        {
            PromotionId = promotionId;
            Code = code;
            Name = name;
        }
    }
}