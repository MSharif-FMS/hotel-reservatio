csharp
using HotelBookingSystem.Domain.Common;
using System;

namespace HotelBookingSystem.Domain.Entities.PromotionAggregate.Events
{
    public class PromotionUpdatedEvent : BaseDomainEvent
    {
        public long PromotionId { get; }
        public string Name { get; }
        public string? Description { get; }

        public PromotionUpdatedEvent(long promotionId, string name, string? description)
        {
            PromotionId = promotionId;
            Name = name;
            Description = description;
        }
    }
}