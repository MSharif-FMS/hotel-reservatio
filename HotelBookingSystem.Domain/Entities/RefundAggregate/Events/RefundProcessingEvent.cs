csharp
using HotelBookingSystem.Domain.Common;
using System;

namespace HotelBookingSystem.Domain.Entities.RefundAggregate.Events
{
    public class RefundProcessingEvent : BaseDomainEvent
    {
        public long RefundId { get; }

        public RefundProcessingEvent(long refundId)
        {
            RefundId = refundId;
        }
    }
}