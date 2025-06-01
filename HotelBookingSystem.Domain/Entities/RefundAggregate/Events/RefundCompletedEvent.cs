csharp
using HotelBookingSystem.Domain.Common;
using System;

namespace HotelBookingSystem.Domain.Entities.RefundAggregate.Events
{
    public class RefundCompletedEvent : BaseDomainEvent
    {
        public long RefundId { get; }
        // Add properties for completion details if needed, e.g.:
        // public DateTimeOffset CompletionDate { get; }
        // public string TransactionId { get; }


        public RefundCompletedEvent(long refundId)
        {
            RefundId = refundId;
        }
    }
}